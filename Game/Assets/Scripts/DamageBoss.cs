using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoss : MonoBehaviour
{
    [SerializeField] private AudioSource attackBoss;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;

    [Header("Boss")] 
    public BossEnemy bossEnemy;
    [SerializeField] private int damage1 = 1;
    [SerializeField] private int damage2 = 2;
    

    private bool IsBossInSight()
    {
        var hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * (range * transform.localScale.x * colliderDistance), 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, enemyLayer);
        if (hit.collider != null)
            bossEnemy = hit.transform.GetComponent<BossEnemy>();
        return hit.collider != null;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * (range * transform.localScale.x * colliderDistance), 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    public void DamageBossEnemy()
    {
        if (IsBossInSight())
        {
            attackBoss.Play();
            if (bossEnemy.bossHealth <= 0) return;
            if (Input.GetKey(KeyCode.K) || Input.GetButton("Fire1"))
                bossEnemy.TakeDamage(damage1);
            if (Input.GetKey(KeyCode.O) || Input.GetButton("Fire2"))
                bossEnemy.TakeDamage(damage2);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("BossHead"))
        {
            bossEnemy.TakeDamage(damage1);
            var playerRb = GetComponent<Rigidbody2D>();
            if (bossEnemy.isFlipped)
                playerRb.AddForce(new Vector2(-7000f, 1000f));
            else playerRb.AddForce(new Vector2(7000f, 1000f));
        }
    }*/
}
