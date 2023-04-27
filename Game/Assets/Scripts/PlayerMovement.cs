using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private int damage;


    private float dirX;
    [SerializeField] private float moveSpeed = 8;
    [SerializeField] private float jumpForce = 14;
    
    public MushroomEnemy MushroomEnemy;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float range;


    private enum MovementState { idle, running, jumping, falling, fight1, fight2, hurt }

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
        if (!PlayerLife.isDead)
        {
            dirX = Input.GetAxisRaw("Horizontal");
            if (Input.GetKey(KeyCode.K) || Input.GetButton("Fire1") ||
                Input.GetKey(KeyCode.O) || Input.GetButton("Fire2") ||
                PlayerLife.isHurt)
                rb.velocity = new Vector2(dirX * moveSpeed / 2, rb.velocity.y);
            else rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0); // Load the start screen scene
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
            state = MovementState.fight1;
        }

        if (Input.GetKey(KeyCode.O) || Input.GetButton("Fire2"))
        {
            state = MovementState.fight2;
        }

        if (PlayerLife.isHurt)
        {
            state = MovementState.hurt;
            PlayerLife.isHurt = false;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsEnemyInSight()
    {
        var hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * (range * transform.localScale.x * colliderDistance), 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, enemyLayer);
        if (hit.collider != null)
            MushroomEnemy = hit.transform.GetComponent<MushroomEnemy>();
        return hit.collider != null;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * (range * transform.localScale.x * colliderDistance), 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    
    private void DamageEnemy()
    {
        if (MushroomEnemy.health <= 0) return;
        if (IsEnemyInSight())
            MushroomEnemy.TakeDamage(damage);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
