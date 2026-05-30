using UnityEngine;

[CreateAssetMenu(fileName = "alternative_colour_functions", menuName = "Scriptable Objects/alternative_colour_functions")]
public class alternative_colour_functions : ScriptableObject
{
        public static void Red(GameObject gameObject)
    {
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", new Color(0, 225 / 225f, 225 / 225f));
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", new Color(225 / 225, 0, 0));
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", Color.mintCream);

 

    }
    public static void Orange(GameObject gameObject)
    {
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", new Color(1f, 0.3f, 0.8f));
        //Vector3 red_in_orange = gameObject.GetComponent<MeshRenderer>().material.GetColor("_colour2");
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", new Color(225 / 225, 183 / 225f, 0));
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", Color.mintCream);

 

    }
    public static void Yellow(GameObject gameObject)
    {
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", new Color(1f, 0.3f, 0.8f));
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", new Color(225 / 225f, 225 / 225f, 0));
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", Color.mintCream);

 

    }
    public static void Green(GameObject gameObject)
    {
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", new Color(1f, 0.3f, 0.8f));
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", new Color(0, 225/225, 0));
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", Color.mintCream);
    }
    public static void Cyan(GameObject gameObject)
    {
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", new Color(1f, 0.3f, 0.8f));
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", new Color(0, 225 / 225f, 225 / 225f));
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", Color.mintCream);

 

    }
    public static void Blue(GameObject gameObject)
    {
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", new Color(1f, 0.3f, 0.8f));
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", new Color(0, 0, 225 / 225f));
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", Color.mintCream);

 

    }
    public static void Violet(GameObject gameObject)
    {
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", new Color(1f, 0.3f, 0.8f));
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", new Color(225 / 225f, 0, 225 / 225f));
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", Color.mintCream);

 

    }
    public static void OrangeChange(GameObject gameObject)
    {
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour1", new Color(1f, 0.3f, 0.8f));
        //Vector3 red_in_orange = gameObject.GetComponent<MeshRenderer>().material.GetColor("_colour2");
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour2", new Color(0, 183/225f, 0));
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_colour3", Color.mintCream);
        
    }
    
}
 
 
