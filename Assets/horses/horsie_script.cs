using UnityEngine;

public class horsie_script : MonoBehaviour
{
    //private int distance = 10;
    public float impulse = 10f;
    public float max_speed = 15f;
    public float horsie_goes_totree = 0.0f;
    private float timer;
    public float sit_timer;
    public float run_timer;
    public bool is_sitting;
    public bool is_running;
    public float clicked_timer;
    public colours_with_shader colours_With_Shader;
    public Material material;
    //public on_terrain on_Terrain;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        is_running = true;
    }

    // Update is called once per frame
    void Update()
    {


        run_timer += Time.deltaTime;
        timer += Time.deltaTime;
        sit_timer += Time.deltaTime;
        clicked_timer += Time.deltaTime;
        //Vector3 crab_impulse = Random.onUnitSphere * impulse;
        Vector3 horsie_impulse = new Vector3(Random.Range(0, 5), 0, Random.Range(0, 5)) * impulse;
        if (timer > 1f)
        {
            GetComponent<Rigidbody>().AddForce(horsie_impulse, ForceMode.Impulse);
            timer = 0;
        }

        Vector3 horsie_velocity = GetComponent<Rigidbody>().linearVelocity;

        if (Vector3.Magnitude(horsie_velocity) > max_speed)
        {
            GetComponent<Rigidbody>().linearVelocity = (horsie_velocity / Vector3.Magnitude(horsie_velocity)) * max_speed;
        }

        if (is_sitting == true && sit_timer > Random.Range(3, 8))
        {
            HorsieWalk();
        }
        if (is_running == true && run_timer > Random.Range(5, 12))
        {
            HorsieSit();
        }

        if (colours_With_Shader.just_clicked == true)
        {
            HorsieWalk();
        }
        if (clicked_timer > 5)
        {
            colours_With_Shader.just_clicked = false;
        }
    }
    
    public void HorsieWalk()
    {
        //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        //GetComponent<Rigidbody>().constraints &= RigidbodyConstraints.FreezePositionX;
        //GetComponent<Rigidbody>().constraints &= RigidbodyConstraints.FreezePositionY;
        //GetComponent<Rigidbody>().constraints &= RigidbodyConstraints.FreezePositionZ;
        max_speed = 10; //10;
        impulse = 5; //5;
        material.SetFloat("_speedG", -3f);
        material.SetFloat("_speedB", 3f);
        is_sitting = false;
        is_running = true;
        run_timer = 0;
    }
    public void HorsieSit()
    {
        sit_timer = 0;
        max_speed = 0;
        impulse = 0;
        //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        material.SetFloat("_speedG", 0f);
        material.SetFloat("_speedB", 0f);
        is_running = false;
        is_sitting = true;
    }
}
