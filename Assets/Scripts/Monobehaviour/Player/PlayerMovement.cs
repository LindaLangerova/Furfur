using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    public bool canJump;
    public bool grounded;
    public float jumpForce = 23.0f;

    [SerializeField] protected LayerMask layerMask;

    public float moveSpeed = 12.0F;
    private BoxCollider2D myCollider;

    public Vector2 originalOffset;
    public bool pushed;
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;


    protected void Awake()
    {
        myCollider = GetComponent<BoxCollider2D>();
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

        grounded = Physics2D.Raycast(rigidBody.position + myCollider.offset, Vector2.down, 0.62f, layerMask)
                   && Math.Abs(rigidBody.velocity.y) < 0.1;
    }

    protected void FixedUpdate()
    {
        Movement();

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

        rigidBody.velocity = pushed
            ? new Vector2(rigidBody.velocity.x, rigidBody.velocity.y)
            : new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rigidBody.velocity.y);

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