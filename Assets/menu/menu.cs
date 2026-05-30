using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Play()
    {
        SceneManager.LoadScene(1);
        Cursor.visible = false;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
