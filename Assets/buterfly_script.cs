using UnityEngine;

public class buterfly_script : MonoBehaviour
{
    public GameObject tree;
    private int distance = 10;
    public float impulse = 10f;
    public float max_speed = 15f;
    public float butterfly_goes_totree = 0.0f;
    private float timer;
    public float sit_timer;
    public float fly_timer;
    public bool is_sitting;
    public float clicked_timer;
    public colours_with_shader colours_With_Shader;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3
        (Random.Range(tree.transform.position.x - distance, tree.transform.position.x + distance),
        Random.Range(tree.transform.position.y - distance, tree.transform.position.y + distance),
        Random.Range(tree.transform.position.z - distance, tree.transform.position.z + distance));
    }

    // Update is called once per frame
    void Update()
    {
        fly_timer += Time.deltaTime;
        timer += Time.deltaTime;
        sit_timer += Time.deltaTime;
        clicked_timer += Time.deltaTime;
        Vector3 butterfly_impulse = Random.onUnitSphere * impulse;
        Vector3 butterfly_to_tree = tree.transform.position - transform.position;
        float butterfly_dot = Vector3.Dot(butterfly_to_tree, butterfly_impulse) / (Vector3.Magnitude(butterfly_to_tree) * Vector3.Magnitude(butterfly_impulse));
        if (butterfly_dot < 0)
        {
            float random_number = Random.Range(0.0f, 1.0f);
            if (random_number < butterfly_goes_totree)
            {
                butterfly_impulse = -butterfly_impulse;
            }
        }
        if (timer > 0.1f)
        {
            GetComponent<Rigidbody>().AddForce(butterfly_impulse, ForceMode.Impulse);
            timer = 0;
        }

        Vector3 butterfly_velocity = GetComponent<Rigidbody>().linearVelocity;

        if (Vector3.Magnitude(butterfly_velocity) > max_speed)
        {
            GetComponent<Rigidbody>().linearVelocity = (butterfly_velocity / Vector3.Magnitude(butterfly_velocity)) * max_speed;
        }

        if (is_sitting == true && sit_timer > 5)
        {
            ButterflyFlying();
        }

        if (colours_With_Shader.just_clicked == true)
        {
            ButterflyFlying();
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
            ButterflySitting();
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
    public void ButterflyFlying()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<MeshRenderer>().material.SetFloat("_speed", 20f);
        is_sitting = false;
        fly_timer = 0;
    }
    public void ButterflySitting()
    {
        sit_timer = 0;
        transform.rotation = Quaternion.Euler(90, Random.Range(0, 90), 0);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        GetComponent<MeshRenderer>().material.SetFloat("_speed", 2);
        is_sitting = true;
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
