using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform playerBody;

    public float mouseSensitivity = 100f;

    float xRotation = 0f;

    void Start()
    {
        // Locks the cursor in place
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Variables for retrieving mouse data
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // For looking up and down, clamp so you can't go past a certain point
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Camera Rotation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}