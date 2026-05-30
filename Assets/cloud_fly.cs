using UnityEngine;

public class cloud_fly : MonoBehaviour
{
    public float speed;
    public float timer;
    private Vector3 fly_direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        fly_direction = Random.onUnitSphere;
        transform.position = fly_direction * speed;
        if (timer > 10)
        {
            fly_direction = Random.onUnitSphere;
            transform.position = fly_direction * speed;
        }
    }
}
