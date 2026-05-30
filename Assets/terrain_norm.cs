using UnityEngine;

public class terrain_norm : MonoBehaviour
{
    public Vector3 interpolated_norm;
    public GameObject animal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Terrain the_terrain = Terrain.activeTerrain;
        TerrainData terrainData = the_terrain.terrainData;
        Vector3 animal_position = animal.transform.position;
        Vector3 terrain_position = animal_position - the_terrain.transform.position;
        float norm_x = Mathf.InverseLerp(0, terrainData.size.x, terrain_position.x);
        float norm_z = Mathf.InverseLerp(0, terrainData.size.z, terrain_position.z);
        norm_x = Mathf.Clamp01(norm_x);
        norm_z = Mathf.Clamp01(norm_z);
        interpolated_norm = terrainData.GetInterpolatedNormal(norm_x, norm_z);
//        Debug.Log(interpolated_norm);
    }
}
