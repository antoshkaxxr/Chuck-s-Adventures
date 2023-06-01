using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageFlyingEyeTests : MonoBehaviour
{
    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("Scenes/Level3");
    }

    [Test]
    public void TestFlyingEyeDoesNotRespondToAttackWhenPlayerIsNotNear()
    {
        var flyingEye = new GameObject { tag = "FlyingEyeEnemy" };
        var flyingEyeEnemy = flyingEye.AddComponent<FlyingEyeEnemy>();
        
        var damageFlyingEye = flyingEye.AddComponent<DamageFlyingEye>();
        damageFlyingEye.flyingEyeEnemy = flyingEyeEnemy;
        damageFlyingEye.attackFlyingEye = flyingEye.AddComponent<AudioSource>();
        damageFlyingEye.boxCollider = flyingEye.AddComponent<BoxCollider2D>();
        damageFlyingEye.enemyLayer = new LayerMask();
        damageFlyingEye.range = 1f;
        damageFlyingEye.colliderDistance = 2f;
        
        var player = new GameObject("Player") { tag = "Player" };
        player.AddComponent<BoxCollider2D>();

        flyingEyeEnemy.eyeHealth = 100;
        flyingEyeEnemy.anim = flyingEye.AddComponent<Animator>();
        
        damageFlyingEye.DamageFlyingEyeEnemy();
        
        Assert.AreEqual(100, flyingEyeEnemy.eyeHealth);
    }
    
    [Test]
    public void TestFlyingEyeTakesDamageType1FromPlayer()
    {
        var flyingEye = new GameObject { tag = "FlyingEyeEnemy" };
        var flyingEyeEnemy = flyingEye.AddComponent<FlyingEyeEnemy>();
        
        var damageFlyingEye = flyingEye.AddComponent<DamageFlyingEye>();
        damageFlyingEye.flyingEyeEnemy = flyingEyeEnemy;
        damageFlyingEye.attackFlyingEye = flyingEye.AddComponent<AudioSource>();
        damageFlyingEye.boxCollider = flyingEye.AddComponent<BoxCollider2D>();
        damageFlyingEye.enemyLayer = new LayerMask();
        damageFlyingEye.range = 1f;
        damageFlyingEye.colliderDistance = 2f;
        
        var player = new GameObject("Player") { tag = "Player" };
        player.AddComponent<BoxCollider2D>();

        flyingEyeEnemy.eyeHealth = 100;
        flyingEyeEnemy.anim = flyingEye.AddComponent<Animator>();
        
        flyingEyeEnemy.transform.position = player.transform.position;
        damageFlyingEye.DamageFlyingEyeEnemy();
        flyingEyeEnemy.TakeDamage(damageFlyingEye.damage1);
        
        Assert.AreEqual(99, flyingEyeEnemy.eyeHealth);
    }

    [Test]
    public void TestFlyingEyeTakesDamageType2FromPlayer()
    {
        var flyingEye = new GameObject { tag = "FlyingEyeEnemy" };
        var flyingEyeEnemy = flyingEye.AddComponent<FlyingEyeEnemy>();
        
        var damageFlyingEye = flyingEye.AddComponent<DamageFlyingEye>();
        damageFlyingEye.flyingEyeEnemy = flyingEyeEnemy;
        damageFlyingEye.attackFlyingEye = flyingEye.AddComponent<AudioSource>();
        damageFlyingEye.boxCollider = flyingEye.AddComponent<BoxCollider2D>();
        damageFlyingEye.enemyLayer = new LayerMask();
        damageFlyingEye.range = 1f;
        damageFlyingEye.colliderDistance = 2f;
        
        var player = new GameObject("Player") { tag = "Player" };
        player.AddComponent<BoxCollider2D>();

        flyingEyeEnemy.eyeHealth = 100;
        flyingEyeEnemy.anim = flyingEye.AddComponent<Animator>();
        
        flyingEyeEnemy.transform.position = player.transform.position;
        damageFlyingEye.DamageFlyingEyeEnemy();
        flyingEyeEnemy.TakeDamage(damageFlyingEye.damage2);
        
        Assert.AreEqual(98, flyingEyeEnemy.eyeHealth);
    }
}

