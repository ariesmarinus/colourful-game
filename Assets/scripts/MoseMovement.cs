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
    public float vertical_travel;
    public bool water;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        water = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        //if (Input.GetKeyDown(KeyCode.Space))
        if (Input.GetButton("Jump"))
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
        if (water == true)
        {
            Vector3 v = transform.rotation*Vector3.forward;
            vertical_travel = Mathf.Atan2(v.y, Mathf.Sqrt(v.z*v.z+v.x*v.x));
            //if (Input.GetKeyDown(KeyCode.UpArrow))
            //{
            //    vertical_travel = Mathf.Atan2(v.y, Mathf.Sqrt(v.z*v.z+v.x*v.x));
            //}
            //else
            //{
            //    vertical_travel = -0.5f;
            //}
        }
        else
        {
            vertical_travel = 0;
        }
        
        vertical_travel = Mathf.Clamp(vertical_travel, -0.1f, 0.1f);
        if (velocity.x == 0 && vertical_travel > 0)
        {
            vertical_travel = -vertical_travel;
        }


        Vector3 local_direction = new Vector3(Input.GetAxis("Horizontal")*force, vertical_travel, Input.GetAxis("Vertical"));
        player.GetComponent<Rigidbody>().AddForce(-velocity*damping+player.transform.rotation*local_direction*force, ForceMode.Impulse);
        velocity.y = player.GetComponent<Rigidbody>().linearVelocity.y;
        player.GetComponent<Rigidbody>().linearVelocity = velocity;
    }

}
