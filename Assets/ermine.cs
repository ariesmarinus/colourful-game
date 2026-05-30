using UnityEditor;
using UnityEngine;

public class ermine : MonoBehaviour
{
    public GameObject tree;
    private int distance = 10;
    public float impulse = 10f;
    public float max_speed = 15f;
    public float moth_goes_totree = 0.0f;
    private float timer;
    public ermine_timer sit_timer;
    public GameObject ermine_sit;
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
        timer += Time.deltaTime;
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
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("land"))
        {
            sit_timer.timer = 0;
            Debug.Log("he sit");
            GetComponent<Collider>().isTrigger = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            gameObject.SetActive(false);
            ermine_sit.gameObject.SetActive(true);
            ermine_sit.transform.position = transform.position;
        }
    }
}
