using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    public float speed = 15.0f;
    public string horizontalInputName = "Horizontal";
    public string verticalInputName = "Vertical";
    private float horizontalInput;
    private float verticalInput;

    // Update is called once per frame
    void Update()
    {
        // Check user input.
        horizontalInput = Input.GetAxis(horizontalInputName);
        verticalInput = Input.GetAxis(verticalInputName);

        // Move the player according to user input.
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        // Lock player rotation.
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
}
