using UnityEngine;

public class trees : MonoBehaviour
{
    public GameObject tree;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (var x = 0; x < 300; x++)
        {
            Instantiate(tree, new Vector3(x * 50, 1, 100), Quaternion.identity);
            Debug.Log("tree");
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
