//using UnityEditor.ShaderGraph;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering;
using Unity.Mathematics;

public class dayandnight : MonoBehaviour
{
    public Vector3 degrees = Vector3.zero;
    public float degrees_per_sec = 0.6f;
    public GameObject moths;
    public Material day_sky;
    public GameObject rain;
    public PlayerScript playerScript;
    public Material rain_sky;
    public bool is_raining;
    public GameObject butterflies;
    public GameObject ocean;
    public GameObject lake;
    public GameObject lake2;
    public bool night;
    public float days = 7;
    public GameObject calendar;
    public GameObject stars;
    public Gradient top_sky;
    public Gradient middle_sky;
    public Gradient bottom_sky;
    public Gradient fog;
    public Gradient underwater_fog;
    //public Gradient underwater_surface;
    public Gradient sun;
    private float sun_intencity;
    public GameObject mins;
    public GameObject hours;
    public GameObject edge;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hours.transform.Rotate(0, 0, -transform.rotation.eulerAngles.x+180, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        StarsSpin();
        Clock();
//        date.text = days.ToString() + " days till rain";  //  LATER
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Calendar();
        }
        degrees.x += degrees_per_sec * Time.deltaTime; // sun rotate
        degrees.x = math.fmod(degrees.x, 360.0f);
        transform.rotation = Quaternion.Euler(degrees);
        float dot_sky = Mathf.Clamp01(Vector3.Dot(transform.forward, Vector3.down)+0.4f);
        float dot_sun = Mathf.Clamp01(Vector3.Dot(transform.forward, Vector3.down)+0.1f);
        
        float smooth_night = Mathf.Clamp(2, 0, 2);

        RenderSettings.fogColor = fog.Evaluate(dot_sky);

        day_sky.SetFloat("_power", dot_sky*10+25);
        day_sky.SetColor("_top_colour", top_sky.Evaluate(dot_sky));    
        day_sky.SetColor("_bottom_colour", bottom_sky.Evaluate(dot_sky));
        day_sky.SetColor("_middle_colour", middle_sky.Evaluate(dot_sky));
        gameObject.GetComponent<Light>().color = sun.Evaluate(dot_sun);
        if (playerScript.underwater == true)
        {
            RenderSettings.fogColor = underwater_fog.Evaluate(dot_sky);
            ocean.GetComponent<MeshRenderer>().material.SetColor("_Color", underwater_fog.Evaluate(dot_sky));
            edge.GetComponent<MeshRenderer>().material.SetColor("_Color", underwater_fog.Evaluate(dot_sky));
        }


        if (transform.rotation.eulerAngles.x <8)
        {
            day_sky.SetFloat("_Exposure", Mathf.Clamp(-transform.rotation.eulerAngles.x+10, 3, 8));
        }
        
        
        if (transform.rotation.eulerAngles.x < 15 || transform.rotation.eulerAngles.x > 90)
            {
                //RenderSettings.skybox.SetFloat("_AtmosphereThickness", Mathf.Clamp(dot_sky, 0.1f, 0.8f));
                //gameObject.GetComponent<Light>().intensity = Mathf.Clamp(dot_sky, 0, 2);
            }
            else
            {
                //gameObject.GetComponent<Light>().intensity = 2;
            }
        
        if (transform.rotation.eulerAngles.x > 90)
            {
                night = true;
                //day_sky.SetFloat("_Exposure", 8);
                sun_intencity = (transform.rotation.eulerAngles.x - 340)/10;
                gameObject.GetComponent<Light>().intensity = sun_intencity;
                gameObject.GetComponent<LensFlareComponentSRP>().intensity = sun_intencity;

                moths.SetActive(true);
                butterflies.SetActive(false);
                stars.SetActive(true);


                lake.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0, 31 / 255f, 190 / 255f));
                lake2.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0, 31 / 255f, 190 / 255f));
            }
            else
            {
                night = false;
                moths.SetActive(false);
                butterflies.SetActive(true);
                stars.SetActive(false);
                if (rain.activeSelf == true)
                {
                    RenderSettings.skybox = rain_sky;
                }
                
                lake.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0, 227 / 255f, 255 / 255f));
                lake2.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0, 227 / 255f, 255 / 255f));
            }
        

    }
    public void Calendar()
    {
        if (calendar.activeSelf == true)
        {
            calendar.SetActive(false);
        }
        else
        {
            calendar.SetActive(true);
        }
    }
    public void Day()
    {
        days -= 1;
    }

    public void Clock()
    {
        hours.transform.rotation = Quaternion.AngleAxis(-degrees.x*2, Vector3.forward);
        mins.transform.rotation = Quaternion.AngleAxis(-degrees.x*24, Vector3.forward);
    }

    void StarsSpin()
    {
        day_sky.SetFloat("_rotation", -degrees.x);
    }

    void NorthernLights()
    {
        
    }
}
