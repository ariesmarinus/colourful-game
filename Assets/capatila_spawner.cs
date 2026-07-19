using System;
using UnityEngine;

public class capatila_spawner : MonoBehaviour
{
    public GameObject capatila;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i =0; i < 10; i++)
        {
            Vector3 position = new Vector3(UnityEngine.Random.Range(transform.position.x, transform.position.x + 1), 50, UnityEngine.Random.Range(transform.position.z, transform.position.z + 1));
            foreach(colours_with_shader.Colours colours in Enum.GetValues(typeof(colours_with_shader.Colours)))
            { 
                Instantiate(capatila, position, Quaternion.identity);
                capatila.GetComponent<colours_with_shader>().colour = colours;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
