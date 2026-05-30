using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MoseMovement : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = 5f;
    public GameObject player;
    public float force;
    public float jump;
    public float speed;
    public float damping;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0)*jump, ForceMode.Impulse);
        }

    }
    void FixedUpdate()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        player.transform.localRotation = Quaternion.AngleAxis(turn.x, new Vector3(0.0f, 1.0f, 0.0f));
        transform.localRotation = Quaternion.AngleAxis(-turn.y, new Vector3(1.0f, 0.0f, 0.0f));
        Vector3 velocity = player.GetComponent<Rigidbody>().linearVelocity;
        velocity.y = 0.0f;
        float current_speed = Vector3.Magnitude(velocity);
        if (current_speed > speed)
        {
            velocity *= speed / current_speed;
        }
        player.GetComponent<Rigidbody>().AddForce(-velocity*damping+player.transform.localRotation*new Vector3(Input.GetAxis("Horizontal")*force, 0, Input.GetAxis("Vertical")*force), ForceMode.Impulse);
        velocity.y = player.GetComponent<Rigidbody>().linearVelocity.y;
        player.GetComponent<Rigidbody>().linearVelocity = velocity;
    }

}
