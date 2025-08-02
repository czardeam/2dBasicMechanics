using System;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class Player : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    [Header("Movement Details")]
    float xInput;
    bool facingRight = true;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 8f;

    [Header("Collision Details")]
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask whatIsGround;
     bool isGrounded;


    



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        HandleInput();
        HandleCollision();
        HandleMovement();
        HandleAnimations();
        HandleFlip();
    }


    private void HandleAnimations()
    {
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.linearVelocityY);
        anim.SetFloat("xVelocity", rb.linearVelocityX);
    }

    private void HandleInput()
    {

        xInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }


    private void HandleMovement()
    {
        rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
    }

    private void HandleCollision()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void Jump()
    {
        if (isGrounded)
        { rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); }
    }


    private void HandleFlip()
    {
        if (rb.linearVelocityX > 0 && facingRight == false)
            Flip();
        else if (rb.linearVelocityX < 0 && facingRight == true)
            Flip();

    }
    private void Flip()
    {
        transform.Rotate(0, -180, 0);
        facingRight = !facingRight;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3 (0, -groundCheckDistance));
    }






}