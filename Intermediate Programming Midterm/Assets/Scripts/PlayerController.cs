using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables:
    public float moveSpeed, jumpForce, increaseValue, horizontalMoveSpeed;
    private float groundDist;
    private Rigidbody rb;
    private Collider collider;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();

        //Get the distance to the ground from the player
        groundDist = collider.bounds.extents.y;
    }

    void Update()
    {
        //Print the speed:
        Debug.Log("Current Speed: " + moveSpeed);
        Debug.Log("Grounded: " + isGrounded);

        Physics.Raycast(transform.position, -Vector3.up, groundDist + 0.1f);
        Debug.DrawRay(transform.position, -Vector3.up, Color.red);
    }

    public void IncreaseSpeed()
    {
        moveSpeed += increaseValue;
    }

    void FixedUpdate()
    {
        //Always moving forward at the move speed
        transform.position += transform.forward * Time.deltaTime * moveSpeed;

        //The player can move horizontal and jump to avoid obstacles:
        if (Input.GetAxis("Horizontal") > 0.0f)
        {
            rb.velocity = Vector3.right * horizontalMoveSpeed;
        }
        else if (Input.GetAxis("Horizontal") < 0.0f)
        {
            rb.velocity = Vector3.left * horizontalMoveSpeed;
        }
        else
        {
            //Make sure when the player isn't moving Kanye stops moving horizontally
            Vector3 v = rb.velocity;
            v.x = 0;
            rb.velocity = v;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = new Vector3(0, jumpForce, 0);
        }
    }
}
