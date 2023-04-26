using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomHealth : MonoBehaviour
{
    public int maxHealth = 6;
    public int health;
    private Rigidbody2D myBody;
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        health = maxHealth;
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        anim.SetTrigger("hurt");
        health -= damage;
        if (health <= 0)
        {
            anim.SetTrigger("death");
        }
    }
}
