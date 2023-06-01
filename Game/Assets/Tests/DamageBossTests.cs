using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageBossTests : MonoBehaviour
{
    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("Scenes/Level3");
    }

    [Test]
    public void TestBossTakesNoDamageWhenPlayerIsNotNear()
    {
        var boss = new GameObject { tag = "BossEnemy" };
        var bossEnemy = boss.AddComponent<BossEnemy>();
        
        var damageBoss = boss.AddComponent<DamageBoss>();
        damageBoss.bossEnemy = bossEnemy;
        damageBoss.attackBoss = boss.AddComponent<AudioSource>();
        damageBoss.boxCollider = boss.AddComponent<BoxCollider2D>();
        damageBoss.enemyLayer = new LayerMask();
        damageBoss.range = 1f;
        damageBoss.colliderDistance = 2f;
        
        var player = new GameObject("Player") { tag = "Player" };
        player.AddComponent<BoxCollider2D>();

        bossEnemy.bossHealth = 25;
        bossEnemy.anim = boss.AddComponent<Animator>();
        
        damageBoss.DamageBossEnemy();
        
        Assert.AreEqual(25, bossEnemy.bossHealth);
    }
    
    [Test]
    public void TestBossTakesDamageType1FromPlayer()
    {
        var boss = new GameObject { tag = "BossEnemy" };
        var bossEnemy = boss.AddComponent<BossEnemy>();
        
        var damageBoss = boss.AddComponent<DamageBoss>();
        damageBoss.bossEnemy = bossEnemy;
        damageBoss.attackBoss = boss.AddComponent<AudioSource>();
        damageBoss.boxCollider = boss.AddComponent<BoxCollider2D>();
        damageBoss.enemyLayer = new LayerMask();
        damageBoss.range = 1f;
        damageBoss.colliderDistance = 2f;
        
        var player = new GameObject("Player") { tag = "Player" };
        player.AddComponent<BoxCollider2D>();

        bossEnemy.bossHealth = 25;
        bossEnemy.anim = boss.AddComponent<Animator>();
        
        bossEnemy.transform.position = player.transform.position;
        damageBoss.DamageBossEnemy();
        bossEnemy.TakeDamage(damageBoss.damage1);
        
        Assert.AreEqual(24, bossEnemy.bossHealth);
    }

    [Test]
    public void TestBossTakesDamageType2FromPlayer()
    {
        var boss = new GameObject { tag = "BossEnemy" };
        var bossEnemy = boss.AddComponent<BossEnemy>();
        
        var damageBoss = boss.AddComponent<DamageBoss>();
        damageBoss.bossEnemy = bossEnemy;
        damageBoss.attackBoss = boss.AddComponent<AudioSource>();
        damageBoss.boxCollider = boss.AddComponent<BoxCollider2D>();
        damageBoss.enemyLayer = new LayerMask();
        damageBoss.range = 1f;
        damageBoss.colliderDistance = 2f;
        
        var player = new GameObject("Player") { tag = "Player" };
        player.AddComponent<BoxCollider2D>();

        bossEnemy.bossHealth = 25;
        bossEnemy.anim = boss.AddComponent<Animator>();
        
        bossEnemy.transform.position = player.transform.position;
        damageBoss.DamageBossEnemy();
        bossEnemy.TakeDamage(damageBoss.damage2);
        
        Assert.AreEqual(23, bossEnemy.bossHealth);
    }
}

