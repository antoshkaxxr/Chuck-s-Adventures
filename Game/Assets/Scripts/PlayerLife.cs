using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private AudioSource damageSound;
    [SerializeField] private AudioSource takeHeal;
    [SerializeField] private AudioSource useHeal;
    [SerializeField] private Text HealingPotion;
    public int maxHealth = 5;
    public int playerHealth;
    public static bool isDead = false;
    public static bool isHurt = false;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
	
	public Image[] hearts;
	public Sprite fullHearts;
	public Sprite emptyHearts;
	public int numberHealthNow = 4;
    private int healCounter;
    public TextMeshProUGUI healingText;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        playerHealth = maxHealth;
		for (var i = 0; i < 5; i++)
		{
			hearts[i].sprite = fullHearts;
		}
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && healCounter > 0 && playerHealth != maxHealth)
        {
            hearts[playerHealth].sprite = fullHearts;
            playerHealth++;
            numberHealthNow++;
            healCounter--;
            HealingPotion.text = $"x{healCounter}";
            useHeal.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            if (!isDead)
                Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HealingPotion"))
        {
            Destroy(collision.gameObject);
            healCounter++;
            HealingPotion.text = $"x{healCounter}";
            takeHeal.Play();
            healingText.enabled = false;
        }
    }

    public void TakeDamage(int damage)
    {
		damageSound.Play();
        isHurt = true;
        playerHealth -= damage;
		hearts[numberHealthNow].sprite = emptyHearts;
        numberHealthNow--;
        if (playerHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
		damageSound.Play();
        isDead = true;
        for (var i = 0; i < 5; i++)
        {
            hearts[i].sprite = emptyHearts;
        }
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
