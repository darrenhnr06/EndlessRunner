using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float speed = 100;
    public CharacterController characterController;
    public Rigidbody rb;
    private float turnSpeed = 10;

    private void FixedUpdate()
    {
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.velocity = new Vector3(turnSpeed, 0, speed);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.velocity = new Vector3(-turnSpeed, 0, speed);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }
}
