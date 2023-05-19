using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeEnemy : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;
    
    [Header ("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    
    [Header ("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    private Animator anim;
    private PlayerLife PlayerLife;
    public Transform player;
    public bool isFlipped = false;
    
    [Header ("Health")]
    public int maxHealth = 4;
    public int eyeHealth;
    public float deathDelay = 1;

    private void Awake()
    {
        eyeHealth = maxHealth;
        anim = GetComponent<Animator>();
    }
    
    private bool IsPlayerInSight()
    {
        var hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * (range * transform.localScale.x * colliderDistance), 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);
        if (hit.collider != null)
            PlayerLife = hit.transform.GetComponent<PlayerLife>();
        return hit.collider != null;
    }
    
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (IsPlayerInSight())
        {
            if (PlayerLife.playerHealth <= 0) return;
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("Attack");
            }
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * (range * transform.localScale.x * colliderDistance), 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    
    public void LookAtPlayer()
    {
        var flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
    
    public void DamagePlayer()
    {
        if (PlayerLife.playerHealth <= 0) return;
        if (IsPlayerInSight())
            PlayerLife.TakeDamage(damage);
    }
    
    public void TakeDamage(int damage)
    {
        anim.SetTrigger("Hurt");
        eyeHealth -= damage;
        if (eyeHealth <= 0)
        {
            anim.SetTrigger("Die");
            Invoke(nameof(DestroyEnemy), deathDelay);
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
