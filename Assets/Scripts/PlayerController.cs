using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public variables
    [Tooltip("CharacterController component")]
    public CharacterController controller;

    [Tooltip("Camera Transform component")]
    public Transform cam;

    [Tooltip("Player's movement speed")]
    public float speed = 15.0f;

    [Tooltip("Player's turn speed")]
    public float smoothTime = 0.1f;
    
    [Tooltip("Horizontal input axis")]
    public string horizontalInputName = "Horizontal";

    [Tooltip("Vertical input axis")]
    public string verticalInputName = "Vertical";


    // Private variables
    float turnSmoothVelocity; // Used to smooth out the player's turning

    // Update is called once per frame
    void Update()
    {
        // Check user input.
        float horizontalInput = Input.GetAxisRaw(horizontalInputName);
        float verticalInput = Input.GetAxisRaw(verticalInputName);

        // Calculate the direction the player is moving.
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Check if the player is moving.
        if (direction.magnitude >= 0.1f)
        {
            // Calculate the angle the player should be facing.
            float facingAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            // Smooth the angle.
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, facingAngle, ref turnSmoothVelocity, smoothTime);

            // Rotate the player to face the correct direction.
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Move the player.
            Vector3 moveDirection = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
    }
}
