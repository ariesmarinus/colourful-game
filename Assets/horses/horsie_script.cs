
using UnityEngine;

public class horsie_script : MonoBehaviour
{
    //private int distance = 10;
    public float impulse = 10f;
    public float max_speed = 15f;
    public float horsie_goes_totree = 0.0f;
    public float timer;
    public float run_timer;
    public float clicked_timer;
    public colours_with_shader colours_With_Shader;
    public Material material;
    public enum State
    {
        walk,
        stand
    }
    public State state;
    public Vector3 horsie_impulse;
    private float horsie_impulse_x;
    private float horsie_impulse_z;
    private Vector3 horsies_velocity;
    void Start()
    {
        state = State.stand;
    }

    // Update is called once per frame
    void Update()
    {


        run_timer += Time.deltaTime;
        timer += Time.deltaTime;
        clicked_timer += Time.deltaTime;

        StateChange();
    
        horsie_impulse = new Vector3(horsie_impulse_x, 0, horsie_impulse_z) * impulse;
        horsies_velocity = GetComponent<Rigidbody>().linearVelocity;//*Time.deltaTime;
        
        Vector3 horsie_velocity = GetComponent<Rigidbody>().linearVelocity;//*Time.deltaTime;
        GetComponent<Rigidbody>().AddForce(horsie_impulse, ForceMode.Force);

        Debug.Log("velocity" + horsie_velocity);
        Debug.Log("rotation" + transform.position);
        //GetComponent<Rigidbody>().AddTorque(50*Time.smoothDeltaTime* (horsie_velocity-transform.position).normalized);


        if (Vector3.Magnitude(horsie_velocity) > max_speed)
        {
            GetComponent<Rigidbody>().linearVelocity = horsie_velocity / Vector3.Magnitude(horsie_velocity) * max_speed;
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
        max_speed = 10;
        impulse = 10;
        horsie_impulse_x = Random.Range(-3f, 3f);
        horsie_impulse_z = Random.Range(-3f, 3f);
        GetComponent<Rigidbody>().AddTorque(Vector3.up*(horsies_velocity.y-transform.position.y), ForceMode.VelocityChange);
        material.SetFloat("_speedG", -5f);
        material.SetFloat("_speedB", 5f);
        state = State.walk;
        run_timer = 0;
    }
    public void HorsieSit()
    {
        max_speed = 0;
        impulse = 0;
        material.SetFloat("_speedG", 0f);
        material.SetFloat("_speedB", 0f);
        state = State.stand;
        run_timer = 0;
    }

    void StateChange()
    {
        switch (state)
        {
            case State.walk:
                if (run_timer > Random.Range(5, 180))
                    {
                        HorsieSit();
                    }
                break;
            case State.stand:
                if (run_timer > Random.Range(5, 10))
                    {
                        HorsieWalk();
                    }
                break;
        }
    }
}
