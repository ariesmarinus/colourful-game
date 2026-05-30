using UnityEngine;

[CreateAssetMenu(fileName = "colours_functions", menuName = "Scriptable Objects/colours_functions")]
public class colours_functions : ScriptableObject
{
    public static void Red(GameObject gameObject, TheTree theTree, Material material)
    {
        //gameObject.GetComponent<MeshRenderer>().material = material;
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", Color.orange);
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", Color.yellow);
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", Color.lightPink);

        theTree.red += 1;
        if (theTree.get_colour == 0)
        {
            theTree.the_colour += 1;
        }
    }

 

    public static void Orange(GameObject gameObject, TheTree theTree, Material material)
    {
        gameObject.GetComponent<MeshRenderer>().material = material;
        theTree.orange += 1;
        if (theTree.get_colour == 1)
        {
            theTree.the_colour += 1;
        }
    }

 

    public static void Yellow(GameObject gameObject, TheTree theTree, Material material)
    {
        gameObject.GetComponent<MeshRenderer>().material = material;
        theTree.yellow += 1;
        if (theTree.get_colour == 2)
        {
            theTree.the_colour += 1;
        }
    }
    public static void Green(GameObject gameObject, TheTree theTree, Material material)
    {
        gameObject.GetComponent<MeshRenderer>().material = material;
        theTree.green += 1;
        if (theTree.get_colour == 3)
        {
            theTree.the_colour += 1;
        }
    }

 

    public static void Cyan(GameObject gameObject, TheTree theTree, Material material)
    {
        gameObject.GetComponent<MeshRenderer>().material = material;
        theTree.cyan += 1;
        if (theTree.get_colour == 4)
        {
            theTree.the_colour += 1;
        }
    }

 

    public static void Blue(GameObject gameObject, TheTree theTree, Material material)
    {
        gameObject.GetComponent<MeshRenderer>().material = material;
        theTree.blue += 1;
        if (theTree.get_colour == 5)
        {
            theTree.the_colour += 1;
        }
    }
    public static void Violet(GameObject gameObject, TheTree theTree, Material material)
    {
        gameObject.GetComponent<MeshRenderer>().material = material;
        theTree.violet += 1;
        if (theTree.get_colour == 6)
        {
            theTree.the_colour += 1;
        }
    }
}
