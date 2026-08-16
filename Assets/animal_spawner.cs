using System;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class animal_spawner : MonoBehaviour
{
    public GameObject capatila;
    public GameObject[] capatila_spots;
    public GameObject moff;
    public GameObject[] moff_spots;
    public GameObject butterfly;
    public GameObject[] butterfly_spots;
    public GameObject fish;
    public GameObject[] fish_spots;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i =0; i < 10; i++)
        {
            PlaceAnimal(capatila, capatila_spots);
            PlaceAnimal(moff, moff_spots);
            PlaceAnimal(fish, fish_spots);
            PlaceAnimal(butterfly, butterfly_spots);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAnimal(GameObject animal, Vector3 position, GameObject parent)
    {
        foreach(colours_with_shader.Colours colours in Enum.GetValues(typeof(colours_with_shader.Colours)))
        {
            var new_animal = Instantiate(animal, position, Quaternion.identity);
            animal.GetComponent<colours_with_shader>().colour = colours; 
            new_animal.transform.SetParent(parent.transform);
        }
    }

    void PlaceAnimal(GameObject animal, GameObject[] place)
    {
        foreach (var spot in place)
            {
                SpawnAnimal(animal, spot.transform.position, spot);
            }
    }
}
