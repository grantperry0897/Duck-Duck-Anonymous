using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // SerializeField tag exposes the attribute to the inspector in Unity
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float fallSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private int[] lateralPositionArray = new int[3];
    private int lateralPositionIndex;
    private Vector3 velocity;
    private Vector3 position;
    private bool isGrounded;
    

    // Start is called before the first frame update
    void Start()
    {
        lateralPositionIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        velocity.z = 0;
        
        // lateral movement
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (lateralPositionIndex <2)
            {
                lateralPositionIndex++;
                Debug.Log(lateralPositionIndex);
            }

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (lateralPositionIndex >0)
            {
                lateralPositionIndex--;
                Debug.Log(lateralPositionIndex);
            }
            

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity.x -= speed;
            if (velocity.x < -maxSpeed)
            {
                velocity.x = -maxSpeed;
            }
        }
        if (Math.Abs(rb.position.z - lateralPositionArray[lateralPositionIndex]) >.1)
        {
            if (rb.position.z > lateralPositionArray[lateralPositionIndex])
            {
                velocity.z -= speed;
            }
            if (rb.position.z < lateralPositionArray[lateralPositionIndex])
            {
                velocity.z += speed;
            }
        }
       
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (!isGrounded)
            {
                velocity.y -= speed * fallSpeed * Time.deltaTime;
            }
        } 
        
		

        rb.velocity = velocity;
        // ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.5f, whatIsGround);
        if (!isGrounded)
        { // delta time is an internal number that tracks the time between frames
            velocity.y -= fallSpeed * Time.deltaTime;
        }

        // jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = jumpSpeed;
        }

        rb.velocity = velocity;
        // to set new vectors -> new Vector(0,0,0)
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {

            Debug.Log("I hit the obstacle");
        }
       
    }
}

