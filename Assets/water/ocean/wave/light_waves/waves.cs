
using Unity.Mathematics;
using UnityEngine;

 

public class wave : MonoBehaviour
{
    public Material material;
    public GameObject wave_e;
    private float wave_length;
    private Color colour;
    //public List<GameObject> waves = new List<GameObject>();
    public float speed;
    //public float direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //direction = 1;
        for (var i = 0; i < 4000; i++)
        {
                {
                    wave_length = GetWaveLength();
                    colour = GetColour(wave_length);

 

                    GameObject new_wave_e = Instantiate(wave_e, new Vector3(UnityEngine.Random.Range(-15.0f, 15.0f), UnityEngine.Random.Range(-15.0f, 15.0f), UnityEngine.Random.Range(-15.0f, 15.0f)), quaternion.identity);
                    GameObject new_wave_b = Instantiate(wave_e, new_wave_e.transform.position, Quaternion.Euler(90, 0, 0));
                    new_wave_b.transform.SetParent(new_wave_e.transform);
                    new_wave_e.transform.localScale = new Vector3(wave_length/1000, new_wave_e.transform.localScale.y, new_wave_e.transform.localScale.z);
                    new_wave_e.GetComponent<Renderer>().material.SetColor("_Colour", colour);
                    new_wave_b.GetComponent<Renderer>().material.SetColor("_Colour", colour);
                    new_wave_b.GetComponent<Rigidbody>().isKinematic = true;
                    //waves.Add(new_wave_e);
                    //waves.Add(new_wave_b);
                }
        }
        
    }

 

    // Update is called once per frame void Update()
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    for (var i = 0; i<waves.Count; i++)
        //    {
        //        waves[i].GetComponent<Rigidbody>().AddForce(Vector3.right*direction*speed, ForceMode.Impulse);
        //    }
        //}
    }

 

    float GetWaveLength()
    {
        wave_length = UnityEngine.Random.Range(380, 750);
        return wave_length;
    }

 

    Color GetColour(float wave_length)
        {
            if (wave_length >= 625)
            {
                colour = Color.red;
            }

 

            else if (wave_length >= 590 && wave_length<625)
            {
                colour = Color.orange;
            }

 

            else if (wave_length >= 565 && wave_length<590)
            {
                colour = Color.yellow;
            }

 

            else if (wave_length >= 500 && wave_length<565)
            {
                colour = Color.green;
            }

 

            else if (wave_length >= 485 && wave_length<500)
            {
                colour = Color.cyan;
            }

 

            else if (wave_length >= 450 && wave_length<485)
            {
                colour = Color.blue;
            }

 

            else if (wave_length<450)
            {
                colour = Color.violet;
            }
            return colour;
        }
}
