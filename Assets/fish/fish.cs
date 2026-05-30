using UnityEngine;

public class fish : MonoBehaviour
{
    public float timer;
    public float magnitude = 15f;
    public GameObject water;
    public bool rotated;
    private Vector3 random_direction;
    public float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(random_direction * magnitude, ForceMode.Force);
        timer += Time.deltaTime;
        if (timer > 5)
        {
            //if (rotated == false)
            {
                random_direction = Random.onUnitSphere;

                //if (transform.position.y > water.transform.position.y)
                //{
                //    GetComponent<Rigidbody>().AddForce(Random.Range(1, 5), -5f, Random.Range(1, 5) * magnitude, ForceMode.Force);
                //}
            }
            timer = 0;
        }
        Vector3 velocity = GetComponent<Rigidbody>().linearVelocity;
        float current_speed = Vector3.Magnitude(velocity);
        if (current_speed > speed)
        {
            velocity *= speed / current_speed;
        }
        transform.LookAt(transform.position + velocity);
        transform.Rotate(0, -90, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("land"))
        {
            random_direction = Random.onUnitSphere;
            //Debug.Log("fish collide");
            
        }
    }
    
}
