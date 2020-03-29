using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;

    public float runSpeed = 12f;
    private float curSpeed;
    public float sprintMultiplier = 1.5f;
    public float gravityMultiplier = 2f;
    public float jumpHeight = 3f;
    public float groundDistance = 0.2f;
    
    Vector3 velocity;
    bool isGrounded;
    bool isSprinting;
    
    void Update()
    {
        // Checks if the player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        // If you're on the ground stay there
        if(isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        // Variables for moving
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Checks if you're sprinting
        if (Input.GetKey(KeyCode.LeftShift)) {
            isSprinting = true;
            curSpeed = runSpeed * sprintMultiplier;
        } else {
            isSprinting = false;
            curSpeed = runSpeed;
        }

        // Moves the character
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * curSpeed * Time.deltaTime);

        // Character jump implementation
        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityMultiplier * -9.81f);
        }

        // gravity moves you downwards
        velocity.y += gravityMultiplier * -9.81f * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}