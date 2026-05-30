//using UnityEditor.ShaderGraph;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Rendering;
using Unity.VisualScripting;
using Unity.Mathematics;

public class dayandnight : MonoBehaviour
{
    public Vector3 degrees = Vector3.zero;
    public float degrees_x;
    public float degrees_per_sec = 0.6f;
    public GameObject moths;
    public Material night_sky;
    public Material day_sky;
    public GameObject rain;
    public PlayerScript playerScript;
    public Material rain_sky;
    public float the_time;
    public bool is_raining;
    public GameObject butterflies;
    public GameObject ocean;
    public GameObject lake;
    public GameObject lake2;
    public bool night;
    public float days = 7;
    public GameObject calendar;
    public TMP_Text date;
    public GameObject stars;
    public Gradient top_sky;
    public Gradient middle_sky;
    public Gradient bottom_sky;
    public Gradient fog;
    public Gradient sun;
    public AnimationCurve sun_curve;
    public float night_timer = 3;
    public GameObject moon;
    private float sun_intencity;
    public GameObject clock;
    public GameObject mins;
    public GameObject hours;
    public Image hours1;
    public float stars_transparency;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hours.transform.Rotate(0, 0, -transform.rotation.eulerAngles.x+180, Space.World);
        //mins.transform.Rotate(0, 0, -transform.rotation.x, Space.World);
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
        //Debug.Log(Time.deltaTime%60 + " " + Time.deltaTime);
        //Debug.Log(transform.rotation.eulerAngles + "degrees");
        //Debug.Log(degrees.x + "degrees.x");
        transform.rotation = Quaternion.Euler(degrees);
        float dot_sky = Mathf.Clamp01(Vector3.Dot(transform.forward, Vector3.down)+0.4f);
        float dot_sun = Mathf.Clamp01(Vector3.Dot(transform.forward, Vector3.down)+0.1f);
        Debug.Log(dot_sky);
        //Debug.Log(dot_sky);
        float smooth_night = Mathf.Clamp(2, 0, 2);
        //float colour_number = Mathf.Clamp01(degrees)
        RenderSettings.fogColor = fog.Evaluate(dot_sky);
        //RenderSettings.fogColor = horizon.Evaluate(dot_sky);
        //RenderSettings.skybox.SetColor("_SkyTint", day_night.Evaluate(dot_sky));    //for procesdural skybox
        //RenderSettings.skybox.SetColor("_GroundColor", horizon.Evaluate(dot_sky));  //for procesdural skybox
        day_sky.SetFloat("_power", dot_sky*10+25);
        day_sky.SetColor("_top_colour", top_sky.Evaluate(dot_sky));    
        day_sky.SetColor("_bottom_colour", bottom_sky.Evaluate(dot_sky));
        day_sky.SetColor("_middle_colour", middle_sky.Evaluate(dot_sky));
        gameObject.GetComponent<Light>().color = sun.Evaluate(dot_sun);
        if (transform.rotation.eulerAngles.x <8)
        {
            day_sky.SetFloat("_Exposure", Mathf.Clamp(-transform.rotation.eulerAngles.x+10, 3, 8));
        }
        
        if (transform.rotation.eulerAngles.x <355 && transform.rotation.eulerAngles.x > 350)
        {
            
        }
        else
        {
            //gameObject.GetComponent<Light>().intensity = Mathf.Clamp(-dot_sun+3, 0.1f, 3);
        }
        if (transform.rotation.eulerAngles.x < 90)
        {
            //RenderSettings.skybox.SetFloat("_AtmosphereThickness", Mathf.Clamp(-dot_sky+1.5f, 0.8f, 1.1f));
        }
        if (transform.rotation.eulerAngles.x > 90)
        {
            //RenderSettings.skybox.SetFloat("_AtmosphereThickness", 0.1f);
        }

        if (transform.rotation.eulerAngles.x < 15 || transform.rotation.eulerAngles.x > 90)
            {
                RenderSettings.skybox.SetFloat("_AtmosphereThickness", Mathf.Clamp(dot_sky, 0.1f, 0.8f));
                //gameObject.GetComponent<Light>().intensity = Mathf.Clamp(dot_sky, 0, 2);
            }
            else
            {
                //gameObject.GetComponent<Light>().intensity = 2;
            }
        //Debug.Log(transform.rotation.eulerAngles.x);
        //if (transform.rotation.eulerAngles.x > 70)
        //{
        //    day_sky.SetFloat("_Exposure", Mathf.Clamp(-smooth_night+8, 3, 8));
        //}
        if (transform.rotation.eulerAngles.x > 90)
            {
                night = true;
                //Debug.Log("night");
                //moon.SetActive(true); // moom appear
                day_sky.SetFloat("_Exposure", 8);
                sun_intencity = (transform.rotation.eulerAngles.x - 340)/10;
                gameObject.GetComponent<Light>().intensity = sun_intencity;
                gameObject.GetComponent<LensFlareComponentSRP>().intensity = sun_intencity;

                //day_sky.SetFloat("_Exposure", 8);
                moths.SetActive(true);
                butterflies.SetActive(false);
                stars.SetActive(true);
                //RenderSettings.skybox = night_sky;
                if (playerScript.underwater == false)
                {
                    //RenderSettings.fogColor = Color.darkBlue;
                }
                else
                {
                    RenderSettings.fogColor = new Color(0, 0, 69 / 255f);
                }
                ocean.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0, 14 / 255f, 111 / 255f));
                lake.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0, 31 / 255f, 190 / 255f));
                lake2.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0, 31 / 255f, 190 / 255f));
            }
            else
            {
                night = false;
                //Debug.Log("day");
                //moon.SetActive(false);
                moths.SetActive(false);
                butterflies.SetActive(true);
                stars.SetActive(false);
                //RenderSettings.skybox = day_sky;
                if (playerScript.underwater == true)
                {
                    RenderSettings.fogColor = Color.turquoise;
                }
                if (rain.activeSelf == true)
                {
                    RenderSettings.skybox = rain_sky;
                }
                ocean.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0, 254 / 255f, 255 / 255f));
                lake.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0, 227 / 255f, 255 / 255f));
                lake2.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0, 227 / 255f, 255 / 255f));
            }
        //if (transform.rotation.eulerAngles.x > 350)
        //{
        //    gameObject.GetComponent<LensFlareComponentSRP>().enabled = false;
        //}
        //if (transform.rotation.eulerAngles.x <90)
//
        //{
        //    gameObject.GetComponent<LensFlareComponentSRP>().enabled = true;
//
        //}
        //Debug.Log(transform.rotation.eulerAngles.x);
        //if (the_time > degrees_per_sec * 100 * 7)
        //{
        //    rain.SetActive(true);
        //    is_raining = true;
        //}
        //if (is_raining == false)
        //{
        //    rain.SetActive(false);
        //    RenderSettings.skybox = day_sky;
        //}
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
        //hours.transform.rotation = Quaternion.AngleAxis(transform.rotation.eulerAngles.x*2+180, Vector3.forward);
        hours.transform.rotation = Quaternion.AngleAxis(-degrees.x*2, Vector3.forward);
        mins.transform.rotation = Quaternion.AngleAxis(-degrees.x*24, Vector3.forward);
    }

    void StarsSpin()
    {
        day_sky.SetFloat("_rotation", -degrees.x);
    }
}
