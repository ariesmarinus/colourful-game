using UnityEngine;

public class flower_spawner : MonoBehaviour
{
    public GameObject flower;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (var x = 0; x < 20; x++)
        {
            var position = new Vector3(Random.Range(x * 50, x * 300), 200, Random.Range(x * 50, x * 300));
            Instantiate(flower, position, Quaternion.Euler(90, 200, 0));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
