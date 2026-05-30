using Unity.Mathematics;
using UnityEngine;

public class colours_with_shader : MonoBehaviour
{
    public GameObject tree;
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
    public bool just_clicked;
    public bool clicked;
    public float recharging_time;
    public bool charged;
    public Material second_mat;
    //public Material first_mat;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetColour();
        Glow();
        charged = true;
    }

    // Update is called once per frame
    void Update()
    {
        recharging_time += Time.deltaTime;
        if (recharging_time > 600 && charged == false)
        {
            Glow();
            charged = true;
        }
    }
    //void OnMouseDown()
    //{
    //    ColourCollect();
    //}

    public void SetColour()
    {
        Material material = gameObject.GetComponent<MeshRenderer>().material;
        switch (colour)
        {
            case Colours.red:
                colours_functions1.Red(gameObject, material);
                break;
            case Colours.orange:
                colours_functions1.Orange(gameObject, material);
                break;
            case Colours.yellow:
                colours_functions1.Yellow(gameObject, material);
                break;
            case Colours.green:
                colours_functions1.Green(gameObject, material);
                break;
            case Colours.cyan:
                colours_functions1.Cyan(gameObject, material);
                break;
            case Colours.blue:
                colours_functions1.Blue(gameObject, material);
                break;
            case Colours.violet:
                colours_functions1.Violet(gameObject, material);
                break;
        }
        if (second_mat != null)
        {
            Debug.Log("second colour");
            switch (colour)
            {
                case Colours.red:
                    colours_functions1.Red(gameObject, second_mat);
                    break;
                case Colours.orange:
                    colours_functions1.Orange(gameObject, second_mat);
                    break;
                case Colours.yellow:
                    colours_functions1.Yellow(gameObject, second_mat);
                    break;
                case Colours.green:
                    colours_functions1.Green(gameObject, second_mat);
                    break;
                case Colours.cyan:
                    colours_functions1.Cyan(gameObject, second_mat);
                    break;
                case Colours.blue:
                    colours_functions1.Blue(gameObject, second_mat);
                    break;
                case Colours.violet:
                    colours_functions1.Violet(gameObject, second_mat);
                    break;
            }
        }
    }

    public void Glow()
    {
        float glowing_r = gameObject.GetComponent<MeshRenderer>().material.GetColor("_colour3").r;
        float glowing_g = gameObject.GetComponent<MeshRenderer>().material.GetColor("_colour3").g;
        float glowing_b = gameObject.GetComponent<MeshRenderer>().material.GetColor("_colour3").b;
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", new Vector4(glowing_r + 1.5f, glowing_g + 1.5f, glowing_b + 1.5f, 1));
        if (second_mat != null)
        {
            second_mat.SetColor("_colour3", new Vector4(glowing_r + 1.5f, glowing_g + 1.5f, glowing_b + 1.5f, 1));
        }
    }
    public void RGBCollect()
    {
        theTree.R += gameObject.GetComponent<MeshRenderer>().material.GetColor("_colour2").r;
        theTree.G += gameObject.GetComponent<MeshRenderer>().material.GetColor("_colour2").g;
        theTree.B += gameObject.GetComponent<MeshRenderer>().material.GetColor("_colour2").b;
    }

    public void ColourCollect()
    {
        if (charged == true)
        {
            RGBCollect();
            Material material = gameObject.GetComponent<MeshRenderer>().material;
            switch (colour)
            {
                case Colours.red:
                    colours_functions1.Orange(gameObject, material);
                    colour = Colours.orange;
                    theTree.red += 1;
                    if (theTree.get_colour == 0)
                    {
                        theTree.the_colour += 1;
                    }
                    break;

                case Colours.orange:
                    colours_functions1.Yellow(gameObject, material);
                    colour = Colours.yellow;
                    theTree.orange += 1;
                    if (theTree.get_colour == 1)
                    {
                        theTree.the_colour += 1;
                    }
                    break;

                case Colours.yellow:
                    colours_functions1.Green(gameObject, material);
                    colour = Colours.green;
                    theTree.yellow += 1;
                    if (theTree.get_colour == 2)
                    {
                        theTree.the_colour += 1;
                    }
                    break;

                case Colours.green:
                    colours_functions1.Cyan(gameObject, material);
                    colour = Colours.cyan;
                    theTree.green += 1;
                    if (theTree.get_colour == 3)
                    {
                        theTree.the_colour += 1;
                    }
                    break;
                case Colours.cyan:
                    colours_functions1.Blue(gameObject, material);
                    colour = Colours.blue;
                    theTree.cyan += 1;
                    if (theTree.get_colour == 4)
                    {
                        theTree.the_colour += 1;
                    }
                    break;

                case Colours.blue:
                    colours_functions1.Violet(gameObject, material);
                    colour = Colours.violet;
                    theTree.blue += 1;
                    if (theTree.get_colour == 5)
                    {
                        theTree.the_colour += 1;
                    }
                    break;

                case Colours.violet:
                    colours_functions1.Red(gameObject, material);
                    colour = Colours.red;
                    theTree.violet += 1;
                    if (theTree.get_colour == 6)
                    {
                        theTree.the_colour += 1;
                    }
                    break;
            }
            if (second_mat != null)
            {
                switch (colour)
                {
                    case Colours.red:
                        colours_functions1.Orange(gameObject, second_mat);
                        break;

                    case Colours.orange:
                        colours_functions1.Yellow(gameObject, second_mat);
                        break;

                    case Colours.yellow:
                        colours_functions1.Green(gameObject, second_mat);
                        break;

                    case Colours.green:
                        colours_functions1.Cyan(gameObject, second_mat);
                        break;
                    case Colours.cyan:
                        colours_functions1.Blue(gameObject, second_mat);
                        break;

                    case Colours.blue:
                        colours_functions1.Violet(gameObject, second_mat);
                        break;

                    case Colours.violet:
                        colours_functions1.Red(gameObject, second_mat);
                        break;
                }
        }
        }

        theTree.Complete();
        just_clicked = true;
        clicked = true;
        recharging_time = 0;
        charged = false;
    }

    
}
