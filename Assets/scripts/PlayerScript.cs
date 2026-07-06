using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 90.0f;
    public float timer;
    public bool underwater;
    public GameObject water;
    public GameObject the_camera;
    public bool sliding_on_waterfall;
    public bool moving_to_top_of_rainbow;
    public bool moving_to_new_island;
    public bool on_new_island;
    public GameObject tree;
    public GameObject rainbow;
    public GameObject new_tree;
    public GameObject rain;
    public bool rain_pause;
    public dayandnight dayandnight;
    public Camera cam;
    public float range;
    public GameObject center;
    public MoseMovement moseMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            colours_with_shader colours_With_Shader = hit.transform.GetComponent<colours_with_shader>();
            if (colours_With_Shader != null && colours_With_Shader.charged == true)
            {
                center.SetActive(true);
            }
            else
            {
                center.SetActive(false);
            }
        }
        else
        {
            center.SetActive(false);
        }
        //RaycastHit talk;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            TheTree theTree = hit.transform.GetComponent<TheTree>();
            if (theTree != null)
            {
                if (theTree.start.activeSelf == true)
        {
            theTree.start.SetActive(false);
        }
        if (theTree.R >= 225 && theTree.G >= 225 && theTree.B >= 225)
            {
                theTree.HappyTree();
            }
            else
            {
                theTree.tree_speech.SetActive(true);
                Cursor.visible = true;
            }
            }
        }
        if (Input.GetMouseButtonDown(0))
            {
                Touch();
            }
        if (Input.GetMouseButton(1))
        {
            center.SetActive(true);
        }
        

        if (water != null)
        {
            if (transform.position.y < water.transform.position.y-0.5f && underwater == false)
            {
                Underwater();
            }
            else if (transform.position.y > water.transform.position.y-0.5f && underwater == true)
            {
                AboveWater();
            }
        }

        if (sliding_on_waterfall == true)
        {
            var waterfall_bottom = GameObject.FindGameObjectWithTag("waterfall_bottom");
            transform.position = Vector3.MoveTowards(transform.position, waterfall_bottom.transform.position, 100 * Time.deltaTime);
        }

        if (moving_to_top_of_rainbow == true)
        {
            Debug.Log("rainbow top");
            GetComponent<Rigidbody>().useGravity = false;
            var rainbow_top = GameObject.FindGameObjectWithTag("rainbow_top");
            transform.position = Vector3.MoveTowards(transform.position, rainbow_top.transform.position, 100 * Time.deltaTime);
        }
        var new_island = GameObject.FindGameObjectWithTag("new_island");
        if (moving_to_new_island == true)
        {
            Debug.Log("new island");
            transform.position = Vector3.MoveTowards(transform.position, new_island.transform.position, 100 * Time.deltaTime);
        }
        if (on_new_island == true)
        {
            Debug.Log("tree time");
            if (timer > 3)
            {
                var tree_place = GameObject.FindGameObjectWithTag("tree_place");
                Debug.Log("now tree");
                rainbow.SetActive(false);
                new_tree.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
            Cursor.visible = true;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ocean"))
        {
            water = collision.gameObject;
            Debug.Log("in water");
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
        }
        else if (collision.gameObject.CompareTag("lake"))
        {
            water = collision.gameObject;
            Debug.Log("in water");
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
        }
    }


    void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("waterfall"))
            {
                Debug.Log("waterfall collide");
                sliding_on_waterfall = true;
            }
            else if (other.CompareTag("waterfall_bottom"))
            {
                Debug.Log("waterfal bottom collided");
                sliding_on_waterfall = false;
            }
            else if (other.CompareTag("rainbow"))
            {
                Debug.Log("rainbow collided");
                moving_to_top_of_rainbow = true;
            }
            else if (other.CompareTag("rainbow_top"))
            {
                Debug.Log("top");
                moving_to_top_of_rainbow = false;
                moving_to_new_island = true;
            }
            else if (other.CompareTag("new_island"))
            {
                Debug.Log("new island");
                moving_to_new_island = false;
                GetComponent<Rigidbody>().useGravity = true;
                on_new_island = true;
                timer = 0;
            }
        }

    void Touch()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            colours_with_shader colours_With_Shader = hit.transform.GetComponent<colours_with_shader>();
            if (colours_With_Shader != null && colours_With_Shader.charged == true)
            {
                colours_With_Shader.ColourCollect();
            }
        }
        
    }

    void RainPause()
    {
        if (rain.activeSelf == true)
        {
            rain.SetActive(false);
            rain_pause = true;
            //timer = 0;
        }
    }

    void RainUnpause()
    {
        if (rain_pause == true)
        {
            rain.SetActive(true);
            rain_pause = false;
        }
    }

    void Underwater()
    {
        RenderSettings.fogDensity = 0.03f;
        GetComponent<Rigidbody>().linearDamping = 9;
        moseMovement.force = 1f;
        underwater = true;
        RainPause();
    }

    void AboveWater()
    {
        Debug.Log("above water");
        RenderSettings.fogDensity = 0.0008f;
        GetComponent<Rigidbody>().linearDamping = 0;
        moseMovement.force = 8;
        underwater = false;
        RainUnpause();
    }
}
