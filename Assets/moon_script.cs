using UnityEngine;

public class moon_script : MonoBehaviour
{
    private Vector3 degrees = Vector3.zero;
    public float degrees_per_sec = 0.6f;
    public Gradient moon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        degrees.x = degrees_per_sec * Time.deltaTime;
        transform.Rotate(degrees, Space.World);
        float dot_moon = Mathf.Clamp01(Vector3.Dot(transform.forward, Vector3.down) + 0.1f);
        //Debug.Log(transform.rotation.eulerAngles.x);
        gameObject.GetComponent<Light>().color = moon.Evaluate(dot_moon);


        gameObject.GetComponent<Light>().intensity = Mathf.Clamp(-dot_moon + 3f, 1, 3f);
        if (transform.rotation.eulerAngles.x > 90)
        {
            gameObject.GetComponent<Light>().intensity = (transform.rotation.eulerAngles.x - 340)/10;
        }
    }
}
