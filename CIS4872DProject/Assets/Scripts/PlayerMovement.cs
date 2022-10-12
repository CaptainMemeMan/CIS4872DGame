using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed; // movement speed
    public Rigidbody2D rb;  //forces to player 

    public float jumpForce = 10f;
    public int extraJump = 1;
    public Transform feet;
    public LayerMask groundLayers;


    private float mx; //movement on the x-axis 
    private bool doubleJumpAllowed;


    private bool Walljumping;
    private float touchingLeftorRight = 1;

   // public Animator anim;

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal"); //

        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
        rb.velocity = movement;


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump(); //calls the jump function  
            doubleJumpAllowed = true;
        }
        else if (Input.GetButtonDown("Jump") && doubleJumpAllowed) //will allow the player to double jump
        {
            Jump();
            doubleJumpAllowed = false;
        }
        if (Walljumping)
        {
            rb.velocity = new Vector2(movementSpeed * touchingLeftorRight, jumpForce);
        }

    }
    void SetJumpingToFalse()
    {
        Walljumping = false;
    }

    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce); //this will allows us to jump
        rb.velocity = movement;



    }
    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);


        if (groundCheck != null)
        {

            return true;
        }
        return false;
    }
}
