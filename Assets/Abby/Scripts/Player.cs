using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    // SerializeField tag exposes the attribute to the inspector in Unity
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField] private float fallSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private int[] lateralPositionArray = new int[3];
    private int lateralPositionIndex;
    private Vector3 velocity;
    private bool isGrounded;
    private float time;
    private float stopTime;
    private float collisionTime; 
    private int collisionCount; 
    public static float playerScore;


    // Start is called before the first frame update
    void Start()
    {
        lateralPositionIndex = 1;
        velocity.x = -speed;
        collisionCount = 0;
        collisionTime = 0;
        playerScore = 0;        
    }

    // Update is called once per frame
    void Update()
    {
        velocity.z = 0;
        // lateral movement
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (lateralPositionIndex <2)
            {
                lateralPositionIndex++;
            }

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (lateralPositionIndex >0)
            {
                lateralPositionIndex--;
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
       
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (!isGrounded)
            {
                velocity.y -= speed * fallSpeed * Time.deltaTime;
            }
        } 
        time += Time.deltaTime;
        
        if (time > 20)
        {
            time = 0;
            velocity.x *= acceleration;
            
        }
        collisionTime += Time.deltaTime;
        if (collisionTime > 10)
        {
            collisionCount --;
            if (collisionCount < 0)
            {
                collisionCount = 0;
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
        //Debug.Log(velocity);
        if (collisionCount > 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        if (rb.position.y < 0)
        {
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        playerScore += Time.deltaTime;
        
        // to set new vectors -> new Vector(0,0,0)
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            collisionTime = 0;
            collisionCount++;
        }       
    }
}

