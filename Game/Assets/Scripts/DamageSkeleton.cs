using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSkeleton : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    
    [Header("Skeleton Enemies")]
    public SkeletonEnemy skeletonEnemy1;
    public SkeletonEnemy skeletonEnemy2;
    public SkeletonEnemy skeletonEnemy3;
    public SkeletonEnemy skeletonEnemy4;
    public SkeletonEnemy skeletonEnemy5;
    public SkeletonEnemy[] skeletonEnemies;
    public int skeletonCounter;
    [SerializeField] private int damage;
    
    public void Awake()
    {
        skeletonEnemies = new []
        {
            skeletonEnemy1, skeletonEnemy2, skeletonEnemy3, skeletonEnemy4, skeletonEnemy5
        };
    }

    private bool IsEnemyInSight()
    {
        var hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * (range * transform.localScale.x * colliderDistance), 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, enemyLayer);
        if (hit.collider != null)
            skeletonEnemies[skeletonCounter] = hit.transform.GetComponent<SkeletonEnemy>();
        return hit.collider != null;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * (range * transform.localScale.x * colliderDistance), 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    public void DamageSkeletonEnemy()
    {
        if (IsEnemyInSight())
        {
            if (skeletonEnemies[skeletonCounter].enemyHealth <= 0) return;
            skeletonEnemies[skeletonCounter].TakeDamage(damage);
            if (skeletonEnemies[skeletonCounter].enemyHealth == 0)
                skeletonCounter++;
        }
    }
}
