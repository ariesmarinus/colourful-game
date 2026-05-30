using UnityEngine;

public class alternative_colours : MonoBehaviour
{
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
    public int red_in_orange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetRandomColour();
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
                alternative_colour_functions.Red(gameObject);
                //moth_colour = Colours.orange;
                theTree.red += 1;
                if (theTree.get_colour == 0)
                {
                    theTree.the_colour += 1;
                }
                break;
            case Colours.orange:
                alternative_colour_functions.Green(gameObject);
                colour = Colours.green;
                theTree.red += red_in_orange;
                if (theTree.get_colour == 0)
                {
                    theTree.the_colour += 1;
                }
                break;
            case Colours.yellow:
                alternative_colour_functions.Red(gameObject);
                colour = Colours.red;
                theTree.green += 225;
                if (theTree.get_colour == 0)
                {
                    theTree.the_colour += 1;
                }
                break;
            case Colours.green:
                alternative_colour_functions.Green(gameObject);
                colour = Colours.green;
                theTree.red += 1;
                if (theTree.get_colour == 0)
                {
                    theTree.the_colour += 1;
                }
                break;
            case Colours.cyan:
                alternative_colour_functions.Blue(gameObject);
                colour = Colours.blue;
                theTree.green += 225;
                if (theTree.get_colour == 0)
                {
                    theTree.the_colour += 1;
                }
                break;
            case Colours.blue:
                alternative_colour_functions.Blue(gameObject);
                colour = Colours.blue;
                theTree.red += 1;
                if (theTree.get_colour == 0)
                {
                    theTree.the_colour += 1;
                }
                break;
            case Colours.violet:
                alternative_colour_functions.Red(gameObject);
                colour = Colours.red;
                theTree.blue += 225;
                if (theTree.get_colour == 0)
                {
                    theTree.the_colour += 1;
                }
                break;
        }
    }
    public void SetColour()
    {
        switch (colour)
        {
            case Colours.red:
                alternative_colour_functions.Red(gameObject);
                break;
            case Colours.orange:
                alternative_colour_functions.Orange(gameObject);
                break;
            case Colours.yellow:
                alternative_colour_functions.Yellow(gameObject);
                break;
            case Colours.green:
                alternative_colour_functions.Green(gameObject);
                break;
            case Colours.cyan:
                alternative_colour_functions.Cyan(gameObject);
                break;
            case Colours.blue:
                alternative_colour_functions.Blue(gameObject);
                break;
            case Colours.violet:
                alternative_colour_functions.Violet(gameObject);
                break;
        }
    }
    public void SetRandomColour()
    {
        switch (colour)
        {
            case Colours.red:
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", new Color(Random.Range(225, 200), Random.Range(225, 200),Random.Range(225, 200)));
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", new Color(Random.Range(225, 200), Random.Range(225, 200),Random.Range(225, 200)));
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", new Color(Random.Range(225, 200), Random.Range(225, 200),Random.Range(225, 200)));
                break;
            case Colours.orange:
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", Color.softYellow);
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", Color.orange);
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", Color.lawnGreen);
                break;
            case Colours.yellow:
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", Color.seashell);
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", Color.yellow);
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", Color.lightGreen);
                break;
            case Colours.green:
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", Color.peachPuff);
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", Color.limeGreen);
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", Color.hotPink);
                break;
            case Colours.cyan:
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", Color.lavender);
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", Color.cyan);
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", Color.springGreen);
                break;
            case Colours.blue:
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", Color.seashell);
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", Color.blue);
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", Color.mediumSpringGreen);
                break;
            case Colours.violet:
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", Color.peachPuff);
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", Color.magenta);
                gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", Color.green);
                break;
        }
    }
}
