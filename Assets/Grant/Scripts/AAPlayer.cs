using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAPlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveAcceleration;
    [SerializeField]private Rigidbody rb;
    private float moveX;
    private float moveZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        moveX = Mathf.Lerp(moveX, moveDirection.x, Time.deltaTime * moveAcceleration);
        moveZ = Mathf.Lerp(moveZ, moveDirection.z, Time.deltaTime * moveAcceleration);

        rb.velocity = (transform.forward * moveZ + transform.right * moveX) * moveSpeed;
    }
}