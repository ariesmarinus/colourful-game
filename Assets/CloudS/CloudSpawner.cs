using System.IO.Compression;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloud;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (var x = 0; x < 30; x++)
        {
            for (var y = 15; y < 16; y++)
            {
                for (var z = 0; z < 30; z++)
                {
                    Instantiate(cloud, new Vector3(x * 100, y * 10, z * 100), quaternion.Euler(90, 0, 0));
                }
                
            }
            
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
