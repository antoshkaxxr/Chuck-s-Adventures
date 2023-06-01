using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageSkeletonTests : MonoBehaviour
{
    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("Scenes/Level2");
    }

    [Test]
    public void TestSkeletonDoesNotTakeDamageIfPlayerIsFarAway()
    {
        // Arrange
        var skeleton = new GameObject { tag = "SkeletonEnemy" };
        var skeletonEnemy = skeleton.AddComponent<SkeletonEnemy>();
        
        var damageSkeleton = skeleton.AddComponent<DamageSkeleton>();
        damageSkeleton.skeletonEnemy1 = skeletonEnemy;
        damageSkeleton.attackSkeleton = skeleton.AddComponent<AudioSource>();
        damageSkeleton.boxCollider = skeleton.AddComponent<BoxCollider2D>();
        damageSkeleton.enemyLayer = new LayerMask();
        damageSkeleton.range = 1f;
        damageSkeleton.colliderDistance = 2f;
        
        var player = new GameObject("Player") { tag = "Player" };
        player.AddComponent<BoxCollider2D>();

        skeletonEnemy.enemyHealth = 6;
        skeletonEnemy.anim = skeleton.AddComponent<Animator>();
        
        // Act
        damageSkeleton.DamageSkeletonEnemy();
        
        Assert.AreEqual(6, skeletonEnemy.enemyHealth);
    }
    
    [Test]
    public void TestSkeletonTakesDamageFromWeakAttack()
    {
        // Arrange
        var skeleton = new GameObject { tag = "SkeletonEnemy" };
        var skeletonEnemy = skeleton.AddComponent<SkeletonEnemy>();
        
        var damageSkeleton = skeleton.AddComponent<DamageSkeleton>();
        damageSkeleton.skeletonEnemy1 = skeletonEnemy;
        damageSkeleton.attackSkeleton = skeleton.AddComponent<AudioSource>();
        damageSkeleton.boxCollider = skeleton.AddComponent<BoxCollider2D>();
        damageSkeleton.enemyLayer = new LayerMask();
        damageSkeleton.range = 1f;
        damageSkeleton.colliderDistance = 2f;
        
        var player = new GameObject("Player") { tag = "Player" };
        player.AddComponent<BoxCollider2D>();

        skeletonEnemy.enemyHealth = 6;
        skeletonEnemy.anim = skeleton.AddComponent<Animator>();
        
        // Act
        skeletonEnemy.transform.position = player.transform.position;
        damageSkeleton.DamageSkeletonEnemy();
        skeletonEnemy.TakeDamage(damageSkeleton.damage1);
        
        Assert.AreEqual(5, skeletonEnemy.enemyHealth);
    }

    [Test]
    public void TestSkeletonTakesDamageFromStrongAttack()
    {
        // Arrange
        var skeleton = new GameObject { tag = "SkeletonEnemy" };
        var skeletonEnemy = skeleton.AddComponent<SkeletonEnemy>();

        var damageSkeleton = skeleton.AddComponent<DamageSkeleton>();
        damageSkeleton.skeletonEnemy1 = skeletonEnemy;
        damageSkeleton.attackSkeleton = skeleton.AddComponent<AudioSource>();
        damageSkeleton.boxCollider = skeleton.AddComponent<BoxCollider2D>();
        damageSkeleton.enemyLayer = new LayerMask();
        damageSkeleton.range = 1f;
        damageSkeleton.colliderDistance = 2f;

        var player = new GameObject("Player") { tag = "Player" };
        player.AddComponent<BoxCollider2D>();

        skeletonEnemy.enemyHealth = 6;
        skeletonEnemy.anim = skeleton.AddComponent<Animator>();

        // Act
        skeletonEnemy.transform.position = player.transform.position;
        damageSkeleton.DamageSkeletonEnemy();
        skeletonEnemy.TakeDamage(damageSkeleton.damage2);

        Assert.AreEqual(3, skeletonEnemy.enemyHealth);
    }
}

