using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public int maxHealth = 5;
    public int playerHealth;
	public int nuboOfHeart;
    public static bool isDead = false;
    public static bool isHurt = false;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
	
	public Image[] hearts;
	public Sprite fullHearts;
	public Sprite emptyHearts;
	public int numberHelthNow = 4;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        playerHealth = maxHealth;
		for (var i=0; i < 5; i++)
		{
			hearts[i].sprite = fullHearts;
		}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        isHurt = true;
        playerHealth -= damage;
		hearts[numberHelthNow].sprite = emptyHearts;
		numberHelthNow -= 1;
        if (playerHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead)
        {
            return;
        }
        isDead = true;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
