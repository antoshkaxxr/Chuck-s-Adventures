using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damage;

    public MushroomEnemy mushroomEnemy;
    public SkeletonEnemy skeletonEnemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag($"MushroomEnemy"))
            mushroomEnemy.TakeDamage(damage);
        else if (collision.gameObject.CompareTag($"SkeletonEnemy"))
            skeletonEnemy.TakeDamage(damage);
    }
}
