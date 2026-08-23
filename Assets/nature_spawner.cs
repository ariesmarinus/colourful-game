using UnityEngine;

public class nature_spawner : MonoBehaviour
{
    public GameObject cloud;
    public GameObject tree;
    public GameObject tree_spot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        for (var x = 0; x < 20; x++)
        {
            var position = new Vector3(Random.Range(x * 50, x * 300), 200, Random.Range(x * 50, x * 300));
            Instantiate(cloud, position, Quaternion.Euler(90, 0, 0), this.transform);
        }
        
        for (var x = 0; x < 20; x++)
        {
            var position = new Vector3(tree_spot.transform.position.x +Random.Range(10, 30), 50, tree_spot.transform.position.z +Random.Range(10, 30));
            //float float_x = position.x;
            //float float_y = position.z;
            //int t_x = Mathf.RoundToInt(float_x);
            //int t_y = Mathf.RoundToInt(float_y);
            //Terrain terrain = GetComponent<Terrain>();
            //TerrainData terrain_y = terrain.terrainData;
            //int terrain_height = terrain_y.GetHeight(t_x, t_y);
            var new_tree = Instantiate(tree, position, Quaternion.Euler(tree.transform.rotation.x, Random.Range(1, 360), tree.transform.rotation.z), tree_spot.transform);
            //new_tree.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
