using Unity.Mathematics;
using UnityEngine;

public class rainbow_wave_script : MonoBehaviour
{
    public Material material;
    private float t;
    private float max = 1;
    private float min = -1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        material.SetFloat("_lerp", Mathf.Lerp(max, min, t));
        t += 0.5f*Time.deltaTime;
        if (t > 1)
        {
            float temp = max;
            max = min;
            min = temp;
            t = 0;
        }

        material.SetFloat("_lerp1", Mathf.Lerp(max, min, t));
        t += 0.5f*Time.deltaTime;
        if (t > 1)
        {
            float temp = max;
            max = min;
            min = temp;
            t = 0;
        }
    }
}
