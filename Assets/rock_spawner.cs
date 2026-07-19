using UnityEngine;

public class rock_spawner : MonoBehaviour
{
    public GameObject rock;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int x = 0; x < 50; x++)
        {
            Vector3 position = new Vector3(Random.Range(x * 50, x * 300), 50, Random.Range(x * 50, x * 300));
            //colours_with_shader new_rock = 
            Instantiate(rock, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
