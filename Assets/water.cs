using UnityEngine;

public class water : MonoBehaviour
{
    public float timer;
    public bool underwater;
    public GameObject water_surface;
    public GameObject the_camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (underwater == true && timer > 5)
        {
            if (transform.position.y > water_surface.transform.position.y + 20)
            {
                Debug.Log("above water");
                RenderSettings.fogColor = Color.lightSkyBlue;
                RenderSettings.fogDensity = 0.0008f;
                GetComponent<Rigidbody>().linearDamping = 3;
                underwater = false;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("water"))
        {
            Debug.Log("water");
            RenderSettings.fogColor = Color.turquoise;
            RenderSettings.fogDensity = 0.009f;
            GetComponent<Rigidbody>().linearDamping = 9;
            underwater = true;
            timer = 0;
        }
    }

}
