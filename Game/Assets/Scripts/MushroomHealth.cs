using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomHealth : MonoBehaviour
{
    public int maxHealth = 6;
    public int health;
    private Rigidbody2D myBody;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
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
