
using UnityEditor;
using UnityEngine;

public class moff_script : MonoBehaviour
{
    public GameObject tree;
    //private int distance = 10;
    public float impulse = 10f;
    public float max_speed = 15f;
    public float moth_goes_totree = 0.0f;
    private float timer;
    public Material fly;
    public Material sit;
    public float sit_timer;
    public float fly_timer;
    public bool is_sitting;
    public float clicked_timer;
    public colours_with_shader colours_With_Shader;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //transform.position = new Vector3
        //(Random.Range(tree.transform.position.x - distance, tree.transform.position.x + distance),
        //Random.Range(tree.transform.position.y - distance, tree.transform.position.y + distance),
        //Random.Range(tree.transform.position.z - distance, tree.transform.position.z + distance));
    }

    // Update is called once per frame
    void Update()
    {
        fly_timer += Time.deltaTime;
        timer += Time.deltaTime;
        sit_timer += Time.deltaTime;
        clicked_timer += Time.deltaTime;
        Vector3 moth_impulse = Random.onUnitSphere * impulse;
        Vector3 moth_to_tree = tree.transform.position - transform.position;
        float moth_dot = Vector3.Dot(moth_to_tree, moth_impulse) / (Vector3.Magnitude(moth_to_tree) * Vector3.Magnitude(moth_impulse));
        if (moth_dot < 0)
        {
            float random_number = Random.Range(0.0f, 1.0f);
            if (random_number < moth_goes_totree)
            {
                moth_impulse = -moth_impulse;
            }
        }
        if (timer > 0.1f)
        {
            GetComponent<Rigidbody>().AddForce(moth_impulse, ForceMode.Impulse);
            timer = 0;
        }

        Vector3 moth_velocity = GetComponent<Rigidbody>().linearVelocity;

        if (Vector3.Magnitude(moth_velocity) > max_speed)
        {
            GetComponent<Rigidbody>().linearVelocity = (moth_velocity / Vector3.Magnitude(moth_velocity)) * max_speed;
        }

        if (is_sitting == true && sit_timer > 5)
        {
            Flying();
        }

        if (colours_With_Shader.just_clicked == true)
        {
            Flying();
        }
        if (clicked_timer > 5)
        {
            colours_With_Shader.just_clicked = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("land") && fly_timer > 5)
        {
            Sitting();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("water"))
        {
            //Debug.Log("moff water");
            transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        }
    }
    public void Flying()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<MeshRenderer>().material.SetFloat("_speed", 25f);
        is_sitting = false;
        fly_timer = 0;
    }
    public void Sitting()
    {
        sit_timer = 0;
        transform.rotation = Quaternion.Euler(90, Random.Range(0, 90), 0);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        GetComponent<MeshRenderer>().material.SetFloat("_speed", 0);
        is_sitting = true;
        //Terrain the_terrain = Terrain.activeTerrain;
        //TerrainData terrainData = the_terrain.terrainData;
        //Vector3 tree_position = gameObject.transform.position;
        //Vector3 terrain_position = tree_position - the_terrain.transform.position;
        //float norm_x = Mathf.InverseLerp(0, terrainData.size.x, terrain_position.x);
        //float norm_z = Mathf.InverseLerp(0, terrainData.size.z, terrain_position.z);
        //norm_x = Mathf.Clamp01(norm_x);
        //norm_z = Mathf.Clamp01(norm_z);
        //Vector3 interpolated_norm = terrainData.GetInterpolatedNormal(norm_x, norm_z);
        //Debug.Log(interpolated_norm);
        //transform.rotation *= Quaternion.FromToRotation(transform.up, interpolated_norm);
        //transform.rotation *= Quaternion.FromToRotation(transform.forward, interpolated_norm);
    }
}
