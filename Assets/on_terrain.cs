using UnityEngine;

public class on_terrain : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SitRight()
    {
        Terrain the_terrain = Terrain.activeTerrain;
        TerrainData terrainData = the_terrain.terrainData;
        Vector3 animal_position = gameObject.transform.position;
        Vector3 terrain_position = animal_position - the_terrain.transform.position;
        float norm_x = Mathf.InverseLerp(0, terrainData.size.x, terrain_position.x);
        float norm_z = Mathf.InverseLerp(0, terrainData.size.z, terrain_position.z);
        norm_x = Mathf.Clamp01(norm_x);
        norm_z = Mathf.Clamp01(norm_z);
        Vector3 interpolated_norm = terrainData.GetInterpolatedNormal(norm_x, norm_z);
        //Debug.Log(interpolated_norm);
        transform.rotation *= Quaternion.FromToRotation(transform.up, interpolated_norm);
        transform.rotation *= Quaternion.FromToRotation(transform.forward, interpolated_norm);
    }
}
