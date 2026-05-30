using UnityEngine;

public class ermine_timer : MonoBehaviour
{
    public float timer;
    public GameObject ermine_sit;
    public GameObject ermine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (ermine_sit.gameObject.activeSelf == true && timer > 5)
        {
                Debug.Log("he fly");
                ermine.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                ermine.gameObject.SetActive(true);
                ermine_sit.gameObject.SetActive(false);
        }
    }
}
