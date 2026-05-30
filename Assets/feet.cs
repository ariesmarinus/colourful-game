using UnityEngine;

public class feet : MonoBehaviour
{
    public PlayerScript playerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("underwater"))
        {
            Debug.Log("underwater collided");
            if (playerScript.underwater == true && playerScript.timer > 5)
            {
                Debug.Log("above water");
                RenderSettings.fogColor = Color.lightSkyBlue;
                RenderSettings.fogDensity = 0.0008f;
                playerScript.GetComponent<Rigidbody>().linearDamping = 3;
                playerScript.underwater = false;
            }
        }
        //else if (other.CompareTag("water"))
        //{
       //     return;
        //}
    }
    
}
