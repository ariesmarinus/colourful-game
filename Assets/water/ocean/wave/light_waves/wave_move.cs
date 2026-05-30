
using UnityEngine;

public class wave_move : MonoBehaviour
{
    public wave wave;
    public float direction;
    public Material material;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right*direction*wave.speed, ForceMode.Impulse);
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("wave"))
        {
            Physics.IgnoreCollision(gameObject.GetComponent<MeshCollider>(), other.gameObject.GetComponent<MeshCollider>(), true);
        }
        else if (other.gameObject.CompareTag("wall"))
        {
            //if (material.color == Color.azure)
            //{
            //    material.color = Color.blue;
            //}
            //else
            //{
            //material.color = Color.azure;
            //}
            direction *= -1;
            Debug.Log("collided");
        }

    }
}
