using UnityEngine;

[CreateAssetMenu(fileName = "colours_functions1", menuName = "Scriptable Objects/colours_functions1")]
public class colours_functions1 : ScriptableObject
{
    public static void Orange(GameObject gameObject, Material material)
    {
        gameObject.GetComponent<MeshRenderer>().material = material;
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", Color.softYellow);
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", Color.orange);
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", Color.lawnGreen);
    }



    public static void Yellow(GameObject gameObject, Material material)
    {
        gameObject.GetComponent<MeshRenderer>().material = material;
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", Color.seashell);
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", Color.yellow);
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", Color.lightGreen);
    }



    public static void Green(GameObject gameObject, Material material)
    {
        gameObject.GetComponent<MeshRenderer>().material = material;
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", Color.peachPuff);
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", Color.limeGreen);
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", Color.hotPink);
        
    }
    public static void Cyan(GameObject gameObject, Material material)
    {
        gameObject.GetComponent<MeshRenderer>().material = material;
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", Color.lavender);
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", Color.cyan);
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", Color.springGreen);
    }



    public static void Blue(GameObject gameObject, Material material)
    {
        gameObject.GetComponent<MeshRenderer>().material = material;
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", Color.seashell);
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", Color.blue);
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", Color.mediumSpringGreen);
    }



    public static void Violet(GameObject gameObject, Material material)
    {
        gameObject.GetComponent<MeshRenderer>().material = material;
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", Color.peachPuff);
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", Color.magenta);
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", Color.green);   
    }
    public static void Red(GameObject gameObject, Material material)
    {
        gameObject.GetComponent<MeshRenderer>().material = material;
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", Color.peachPuff);
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", Color.red);
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", Color.green);
    }

    //public static void
}
