using UnityEngine;

public class MushroomEnemy : MonoBehaviour
{
    [SerializeField] public AudioSource attackMushroom;
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] public float range;
    [SerializeField] public int damage = 1;
    
    [Header ("Collider Parameters")]
    [SerializeField]
    public float colliderDistance;
    [SerializeField] public BoxCollider2D boxCollider;
    
    [Header ("Player Layer")]
    [SerializeField]
    public LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    public Animator anim;
    public PlayerLife PlayerLife;
    
    [Header ("Health")]
    public int maxHealth = 6;
    public int enemyHealth;
    public float deathDelay = 1;

    private void Awake()
    {
        enemyHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (IsPlayerInSight())
        {
            if (PlayerLife.playerHealth <= 0) return;
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("attack");
            }
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private bool IsPlayerInSight()
    {
        var hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * (range * transform.localScale.x * colliderDistance), 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);
        if (hit.collider != null)
            PlayerLife = hit.transform.GetComponent<PlayerLife>();
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * (range * transform.localScale.x * colliderDistance), 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    public void DamagePlayer()
    {
        attackMushroom.Play();
        if (PlayerLife.playerHealth <= 0) return;
        if (IsPlayerInSight())
            PlayerLife.TakeDamage(damage);
    }
    
    public void TakeDamage(int damage)
    {
        anim.SetTrigger("hurt");
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            anim.SetTrigger("die");
            Invoke(nameof(DestroyEnemy), deathDelay);
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
