using UnityEngine;

public class otherMothScript : MonoBehaviour
{
    public GameObject tree;
    //private int distance = 10;
    public float speed = 20.0f;
    public float moth_goes_totree = 0.1f;
    public GameObject moth;
    public Material blue;
    public Material green;
    public Material red;
    public Material orange;
    public Material yellow;
    public Material cyan;
    public Material violet;
    public enum Colours
    {
        blue,
        green,
        red,
        orange,
        yellow,
        cyan,
        violet
    }
    public Colours Colour;
    public TheTree theTree;
    public float timer;
    public float impulse = 10f;
    public float max_speed = 15f;
    public float sit_timer;
    public bool sitting;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        sit_timer += Time.deltaTime;
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
        if (sit_timer > 5 && sitting == true)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            sitting = false;
        }


    }
    void OnMouseDown()
    {
        switch (Colour)
        {
            case Colours.red:
                moth.GetComponent<SkinnedMeshRenderer>().material = orange;
                Colour = Colours.orange;
                theTree.red += 1;
                if (theTree.get_colour == 0)
                {
                    theTree.the_colour += 1;
                }
                break;
            case Colours.orange:
                moth.GetComponent<SkinnedMeshRenderer>().material = yellow;
                Colour = Colours.yellow;
                theTree.orange += 1;
                if (theTree.get_colour == 1)
                {
                    theTree.the_colour += 1;
                }
                break;
            case Colours.yellow:
                moth.GetComponent<SkinnedMeshRenderer>().material = green;
                Colour = Colours.green;
                theTree.yellow += 1;
                if (theTree.get_colour == 2)
                {
                    theTree.the_colour += 1;
                }
                break;
            case Colours.green:
                moth.GetComponent<SkinnedMeshRenderer>().material = cyan;
                Colour = Colours.cyan;
                theTree.green += 1;
                if (theTree.get_colour == 3)
                {
                    theTree.the_colour += 1;
                }
                break;
            case Colours.cyan:
                moth.GetComponent<SkinnedMeshRenderer>().material = blue;
                Colour = Colours.blue;
                theTree.cyan += 1;
                if (theTree.get_colour == 4)
                {
                    theTree.the_colour += 1;
                }
                break;
            case Colours.blue:
                moth.GetComponent<SkinnedMeshRenderer>().material = violet;
                Colour = Colours.violet;
                theTree.blue += 1;
                if (theTree.get_colour == 5)
                {
                    theTree.the_colour += 1;
                }
                break;
            case Colours.violet:
                moth.GetComponent<SkinnedMeshRenderer>().material = red;
                Colour = Colours.red;
                theTree.violet += 1;
                if (theTree.get_colour == 6)
                {
                    theTree.the_colour += 1;
                }
                break;
        }
        theTree.Complete();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("land"))
        {
            sit_timer = 0;
            //Debug.Log("he sit");
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            sitting = true;
        }
    }
}
