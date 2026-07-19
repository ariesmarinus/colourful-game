using UnityEngine;

public class capatila : MonoBehaviour
{
    public float impulse = 10f;
    public float max_speed = 15f;
    public float capatila_goes_totree = 0.0f;
    public float timer;
    public float run_timer;
    public float clicked_timer;
    public colours_with_shader colours_With_Shader;
    public Material material;
    public enum State
    {
        walk,
        sit
    }
    public State state;
    public Vector3 goal;
    private float capatila_impulse_x;
    private float capatila_impulse_z;
    public Material change_mat;
    public Material base_mat;
    private float random_walk;
    private float random_sit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = State.sit;
    }

    // Update is called once per frame
    void Update()
    {
        run_timer += Time.deltaTime;
        clicked_timer += Time.deltaTime;

        StateChange();

        goal = new Vector3(capatila_impulse_x, 0, capatila_impulse_z).normalized;
        
        Vector3 capatila_velocity = GetComponent<Rigidbody>().linearVelocity;//*Time.deltaTime;
        Vector3 torque = -Vector3.Cross(goal, transform.forward)*1000;
        GetComponent<Rigidbody>().AddTorque(Limit(torque, 0.3f), ForceMode.VelocityChange);
        GetComponent<Rigidbody>().AddForce(transform.forward*impulse, ForceMode.Force);

        GetComponent<Rigidbody>().linearVelocity = Limit(capatila_velocity, max_speed);

      
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        



        if (colours_With_Shader.just_clicked == true)
        {
            CapatilaWalk();
            colours_With_Shader.just_clicked = false;
        }
    }

    public void CapatilaWalk()
    {
        state = State.walk;
        max_speed = 1;
        impulse = 100;
        capatila_impulse_x = Random.Range(-3f, 3f);
        capatila_impulse_z = Random.Range(-3f, 3f);
        random_walk = Random.Range(10, 50);
        random_sit = Random.Range(5, 10);
        material.SetFloat("_wiggle_speed", 2.5f);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
        run_timer = 0;

    }
    public void CapatilaSit()
    {
        state = State.sit;
        max_speed = 0;
        impulse = 0;
        material.SetFloat("_wiggle_speed", 0f);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        run_timer = 0;
    }

    void StateChange()
    {
        switch (state)
        {
            case State.walk:
                if (run_timer > random_walk)
                    {
                        CapatilaSit();
                    }
                break;
            case State.sit:
                if (run_timer > random_sit)
                    {
                        CapatilaWalk();
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
