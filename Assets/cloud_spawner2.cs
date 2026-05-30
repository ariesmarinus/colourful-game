using System.IO.Compression;
using Unity.Collections;
using UnityEngine;

public class cloud_spawner2 : MonoBehaviour
{
    public GameObject cloud;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        for (var x = 0; x < 20; x++)
        {
            var position = new Vector3(Random.Range(x * 50, x * 300), 200, Random.Range(x * 50, x * 300));
            Instantiate(cloud, position, Quaternion.Euler(90, 0, 0));
        }
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
