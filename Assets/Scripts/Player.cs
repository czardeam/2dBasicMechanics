using System;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class Player : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    float xInput;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 8f;

    bool facingRight = true;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }




    void Update()
    {
        HandleInput();
        HandleMovement();
        HandleAnimations();
        HandleFlip();
    }


    private void HandleAnimations()
    {
        bool isMoving = rb.linearVelocity.x != 0;

        anim.SetBool("isMoving", isMoving);
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

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
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






}