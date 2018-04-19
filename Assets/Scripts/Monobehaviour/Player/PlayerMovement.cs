using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Collider2D myCollider;
    private Rigidbody2D rigidBody;
    public bool grounded = false;
    public bool canJump = false;
    public float jumpForce = 23.0f;
    public bool pushed;

    public Vector2 originalOffset;
    private Animator animator;

    [SerializeField] protected LayerMask layerMask;

    public float moveSpeed = 12.0F;

    private SpriteRenderer spriteRenderer;

    protected void Awake()
    {
        myCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();

        rigidBody = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        originalOffset = myCollider.offset;

    }

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("spacePressed", true);
            if (canJump) Jump();
        }
        else
        {
            animator.SetBool("spacePressed", false);
        }
    }

    protected void FixedUpdate()
    {
        Movement();

        grounded = Math.Abs(Math.Abs(rigidBody.velocity.y)) < 0.01;

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Math.Abs(rigidBody.velocity.x));
        animator.SetFloat("velocityY", rigidBody.velocity.y);

        if (grounded)
        {
            pushed = false;
            canJump = true;
        }
    }

    public void Jump()
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        canJump = false;
    }


    private void Movement()
    {
        var move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        rigidBody.velocity = pushed ? 
            new Vector2(rigidBody.velocity.x, rigidBody.velocity.y) : 
            new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rigidBody.velocity.y);

        if (move.x < 0)
        {
            myCollider.offset = new Vector2(-originalOffset.x, originalOffset.y);
            spriteRenderer.flipX = true;
        }
        else if (move.x > 0)
        {
            myCollider.offset = new Vector2(originalOffset.x, originalOffset.y);
            spriteRenderer.flipX = false;
        }
    }

    public void Stop()
    {
        animator.SetFloat("velocityX", 0);
        animator.SetFloat("velocityY", 0);
        animator.SetBool("grounded", true);
        enabled = false;
    }

    public void PushAway(Vector2 vec)
    {
        rigidBody.velocity = vec;
    }
}