using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody player;
    [SerializeField] Rigidbody rb;

    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        velocity.x = -5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(rb.position.x- player.position.x) > 10)
        {
            transform.position= new Vector3(player.position.x+10,0,0);
        }
        if (player.velocity.x < rb.velocity.x)
        {
            velocity.x = player.velocity.x+2;
        }
        rb.velocity = velocity;
        Debug.Log(rb.velocity.x);
        if (Math.Abs(rb.position.x- player.position.x) < .5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        
    }
}
}
