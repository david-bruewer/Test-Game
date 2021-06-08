using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D body;
    public float speed;
    public float jumpForce;

    public float initialGravity; 

    Vector2 movement;



    bool isGrounded; 


    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false; 
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            movement.y = jumpForce; 

            isGrounded = false; 
        }
        if(!isGrounded)
        {
            movement.y = movement.y -0.01f;
            body.gravityScale ++; 
        }

        body.velocity= movement;

    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true; 
            body.gravityScale = initialGravity;
            movement.y = 0f;  
        }
    }


}
