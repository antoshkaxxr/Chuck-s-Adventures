    using System;
    using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private AudioSource missAttack;
    

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 8;
    [SerializeField] private float jumpForce = 14;
    [SerializeField] private AudioSource jumpSound;
    private float dirX;
    
    private enum MovementState { idle, running, jumping, falling, fight1, fight2, hurt }

    private bool isAttacking;
    

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        PlayerLife.isDead = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!PlayerLife.isDead && !PauseMenu.PauseGame)
        {
            dirX = Input.GetAxisRaw("Horizontal");
            if (Input.GetKey(KeyCode.K) || Input.GetButton("Fire1") ||
                Input.GetKey(KeyCode.O) || Input.GetButton("Fire2") ||
                PlayerLife.isHurt)
            {
                rb.velocity = new Vector2(dirX * moveSpeed / 2, rb.velocity.y);
                if (!isAttacking)
                {
                    missAttack.Play();
                    isAttacking = true;
                }
            }
            else
            {
                rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
                isAttacking = false;
            }
            if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && IsGrounded())
            {
                jumpSound.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            UpdateAnimationState();
        }
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        //movement
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        //jump
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        if (Input.GetKey(KeyCode.K) || Input.GetButton("Fire1"))
        {
            state = MovementState.fight2;
        }

        if (Input.GetKey(KeyCode.O) || Input.GetButton("Fire2"))
        {
            state = MovementState.fight1;
        }

        if (PlayerLife.isHurt)
        {
            state = MovementState.hurt;
            PlayerLife.isHurt = false;
        }

        anim.SetInteger("state", (int)state);
    }
    
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Platform"))
            this.transform.parent = col.transform;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
            this.transform.parent = null;
    }
}
