using UnityEngine;

public class colours_chang : MonoBehaviour
{
    public GameObject tree;
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
    public Colours colour;
    public TheTree theTree;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        switch (colour)
        {
            case Colours.red:
                colours_functions.Red(gameObject, theTree, orange);
                colour = Colours.orange;
                break;
            case Colours.orange:
                colours_functions.Orange(gameObject, theTree, yellow);
                colour = Colours.yellow;
                break;
            case Colours.yellow:
                colours_functions.Yellow(gameObject, theTree, green);
                colour = Colours.green;
                break;
            case Colours.green:
                colours_functions.Green(gameObject, theTree, cyan);
                colour = Colours.cyan;
                break;
            case Colours.cyan:
                colours_functions.Cyan(gameObject, theTree, blue);
                colour = Colours.blue;
                break;
            case Colours.blue:
                colours_functions.Blue(gameObject, theTree, violet);
                colour = Colours.violet;
                break;
            case Colours.violet:
                colours_functions.Violet(gameObject, theTree, red);
                colour = Colours.red;
                break;
        }
        theTree.Complete();
    }
}
