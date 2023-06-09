using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSkeleton : MonoBehaviour
{
    [SerializeField] public AudioSource attackSkeleton;
    [SerializeField] public BoxCollider2D boxCollider;
    [SerializeField] public LayerMask enemyLayer;
    [SerializeField] public float range;
    [SerializeField] public float colliderDistance;
    
    [Header("Skeleton Enemies")]
    public SkeletonEnemy skeletonEnemy1;
    public SkeletonEnemy skeletonEnemy2;
    public SkeletonEnemy skeletonEnemy3;
    public SkeletonEnemy skeletonEnemy4;
    public SkeletonEnemy skeletonEnemy5;
    public SkeletonEnemy skeletonEnemy6;
    public SkeletonEnemy skeletonEnemy7;
    public SkeletonEnemy[] skeletonEnemies;
    public int skeletonCounter;
    [SerializeField] public int damage1 = 1;
    [SerializeField] public int damage2 = 3;


    public void Awake()
    {
        skeletonEnemies = new []
        {
            skeletonEnemy1, skeletonEnemy2, skeletonEnemy3, skeletonEnemy4, 
            skeletonEnemy5, skeletonEnemy6, skeletonEnemy7
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
            attackSkeleton.Play();
            if (skeletonEnemies[skeletonCounter].enemyHealth <= 0) return;
            if (Input.GetKey(KeyCode.K) || Input.GetButton("Fire1"))
            {
                skeletonEnemies[skeletonCounter].TakeDamage(damage1);
            }
            if (Input.GetKey(KeyCode.O) || Input.GetButton("Fire2"))
            {
                skeletonEnemies[skeletonCounter].TakeDamage(damage2);
            }
            if (skeletonEnemies[skeletonCounter].enemyHealth == 0)
                skeletonCounter++;
        }
    }
}
