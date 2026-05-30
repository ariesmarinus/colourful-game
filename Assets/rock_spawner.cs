using UnityEngine;

public class rock_spawner : MonoBehaviour
{
    public colours_with_shader rock;
    public GameObject tree;
    public TheTree theTree;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (var x = 0; x < 50; x++)
        {
            var position = new Vector3(Random.Range(x * 50, x * 300), 50, Random.Range(x * 50, x * 300));
            colours_with_shader new_rock = Instantiate(rock, position, Quaternion.identity);
            new_rock.tree = tree;
            new_rock.theTree = theTree;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
