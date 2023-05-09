using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMushroom : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    
    [Header("Mushroom Enemies")]
    public MushroomEnemy mushroomEnemy1;
    public MushroomEnemy mushroomEnemy2;
    public MushroomEnemy mushroomEnemy3;
    public MushroomEnemy mushroomEnemy4;
    public MushroomEnemy mushroomEnemy5;
    public MushroomEnemy[] mushroomEnemies;
    public int mushroomCounter;
    [SerializeField] private int damage1 = 1;
    [SerializeField] private int damage2 = 2;


    public void Awake()
    {
        mushroomEnemies = new []
        {
            mushroomEnemy1, mushroomEnemy2, mushroomEnemy3, mushroomEnemy4, mushroomEnemy5
        };
    }

    public bool IsEnemyInSight()
    {
        var hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * (range * transform.localScale.x * colliderDistance), 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, enemyLayer);
        if (hit.collider != null)
            mushroomEnemies[mushroomCounter] = hit.transform.GetComponent<MushroomEnemy>();
        return hit.collider != null;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * (range * transform.localScale.x * colliderDistance), 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    public void DamageMushroomEnemy()
    {
        if (IsEnemyInSight())
        {
            if (mushroomEnemies[mushroomCounter].enemyHealth <= 0) return;
            {
                if (Input.GetKey(KeyCode.K) || Input.GetButton("Fire1"))
                {
                    mushroomEnemies[mushroomCounter].TakeDamage(damage1);
                }

                if (Input.GetKey(KeyCode.O) || Input.GetButton("Fire2"))
                {
                    mushroomEnemies[mushroomCounter].TakeDamage(damage2);
                }

            }
            if (mushroomEnemies[mushroomCounter].enemyHealth == 0)
                mushroomCounter++;
        }
    }
}
