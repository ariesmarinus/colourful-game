
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
    public Vector3 goal;
    private float horsie_impulse_x;
    private float horsie_impulse_z;
    void Start()
    {
        state = State.stand;
    }

    // Update is called once per frame
    void Update()
    {


        run_timer += Time.deltaTime;
        clicked_timer += Time.deltaTime;

        StateChange();
    
        goal = new Vector3(horsie_impulse_x, 0, horsie_impulse_z).normalized;
        
        Vector3 horsie_velocity = GetComponent<Rigidbody>().linearVelocity;//*Time.deltaTime;
        Vector3 torque = -Vector3.Cross(goal, transform.forward)*1000;
        GetComponent<Rigidbody>().AddTorque(Limit(torque, 1.0f), ForceMode.VelocityChange);
        GetComponent<Rigidbody>().AddForce(transform.forward*impulse, ForceMode.Force);

        GetComponent<Rigidbody>().linearVelocity = Limit(horsie_velocity, max_speed);





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
        impulse = 50;
        horsie_impulse_x = Random.Range(-3f, 3f);
        horsie_impulse_z = Random.Range(-3f, 3f);
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

    Vector3 Limit(Vector3 vector3, float max_magnitude)
    {
        if (vector3.magnitude > max_magnitude)
        {
            vector3 *= max_magnitude/vector3.magnitude;
        }
        return vector3;
    }
}
