using UnityEngine;

public class flowers : MonoBehaviour
{
    public enum Colours
    {
        blue,
        green,
        red,
        orange,
        yellow,
        lightblue,
        purple
    }
    public Colours Colour;
    public TheTree theTree;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("land"))
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
    }
    void OnMouseDown()
    {
        switch (Colour)
        {
            case Colours.red:
                Colour = Colours.red;
                theTree.red += 1;
                if (theTree.get_colour == 0)
                {
                    theTree.the_colour += 1;
                }
                break;
        }
    }
}
