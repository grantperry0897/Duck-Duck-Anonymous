using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float lookSpeed;
    [SerializeField] private Transform mainCamera;
    private float lookX;
    private float lookY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  
        Cursor.visible = false;
    }

    void Update()
    {
        lookX += Input.GetAxis("Mouse X") * lookSpeed;
        lookY -= Input.GetAxis("Mouse Y") * lookSpeed;
        lookY = Mathf.Clamp(lookY, -90f, 90f);
        mainCamera.localRotation = Quaternion.Euler(lookY, 0, 0);
        transform.localRotation = Quaternion.Euler(0, lookX, 0);
    }
}
