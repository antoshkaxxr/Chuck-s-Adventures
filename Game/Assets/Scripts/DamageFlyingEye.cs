using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlyingEye : MonoBehaviour
{
    [SerializeField] public AudioSource attackFlyingEye;
    [SerializeField] public BoxCollider2D boxCollider;
    [SerializeField] public LayerMask enemyLayer;
    [SerializeField] public float range;
    [SerializeField] public float colliderDistance;

    [Header("FlyingEye")] 
    public FlyingEyeEnemy flyingEyeEnemy;
    [SerializeField] public int damage1 = 1;
    [SerializeField] public int damage2 = 2;

    private bool IsEyeInSight()
    {
        var hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * (range * transform.localScale.x * colliderDistance), 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, enemyLayer);
        if (hit.collider != null)
            flyingEyeEnemy = hit.transform.GetComponent<FlyingEyeEnemy>();
        return hit.collider != null;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * (range * transform.localScale.x * colliderDistance), 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    public void DamageFlyingEyeEnemy()
    {
        if (IsEyeInSight())
        {
            attackFlyingEye.Play();
            if (flyingEyeEnemy.eyeHealth <= 0) return;
            if (Input.GetKey(KeyCode.K) || Input.GetButton("Fire1"))
                flyingEyeEnemy.TakeDamage(damage1);
            if (Input.GetKey(KeyCode.O) || Input.GetButton("Fire2"))
                flyingEyeEnemy.TakeDamage(damage2);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("EyeHead"))
        {
            var playerRb = GetComponent<Rigidbody2D>();
            playerRb.AddForce(new Vector2(0, 2000f));
        }
    }
}
