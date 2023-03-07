using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Declaramos una variabale de tipo Rigidbody para poder utilizarlo en el movimiento del jugador
    private Rigidbody2D rb;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded;

    //[SerializeField] private bool manaHack;
    //[SerializeField] private bool hasMana = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded || Input.GetKeyDown(KeyCode.W) && isGrounded || Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            isGrounded = false;
        }

        /*if (Input.GetKeyDown(KeyCode.T) && manaHack)
        {
            hasMana = true;
            Debug.Log("Unlimited...PooooOOOOoooweeeer! >:D");
        }
        else
        {
            hasMana = false;
            Debug.Log("No mana ;-;");
        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("I'm on the ground!");
            isGrounded = true;
        }
    }
}
