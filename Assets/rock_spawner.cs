using UnityEngine;
using System;

public class rock_spawner : MonoBehaviour
{
    public GameObject rock;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int x = 0; x < 50; x++)
        {
            foreach(colours_with_shader.Colours colours in Enum.GetValues(typeof(colours_with_shader.Colours)))
            { 
                Vector3 position = new Vector3(UnityEngine.Random.Range(x * 50, x * 300), 50, UnityEngine.Random.Range(x * 50, x * 300));
                Instantiate(rock, position, Quaternion.identity, this.transform);
                rock.GetComponent<colours_with_shader>().colour = colours;
                rock.transform.localScale = new Vector3(UnityEngine.Random.Range(0.1f, 2), UnityEngine.Random.Range(0.1f, 2), UnityEngine.Random.Range(0.1f, 2));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
