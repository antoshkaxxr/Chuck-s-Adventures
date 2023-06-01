using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DamagePlayerTests : MonoBehaviour
{
    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("Scenes/Level1");
    }

    [Test]
    public void TestPlayerReactsToMushroomAttack()
    {
        var mushroom = new GameObject { tag = "MushroomEnemy" };
        var mushroomEnemy = mushroom.AddComponent<MushroomEnemy>();
        
        mushroomEnemy.attackMushroom = mushroom.AddComponent<AudioSource>();
        mushroomEnemy.boxCollider = mushroom.AddComponent<BoxCollider2D>();
        mushroomEnemy.playerLayer = new LayerMask();
        mushroomEnemy.PlayerLife = mushroom.AddComponent<PlayerLife>();
        mushroomEnemy.range = 1f;
        mushroomEnemy.colliderDistance = 2f;
        
        var player = new GameObject("Player") { tag = "Player" };
        player.AddComponent<BoxCollider2D>();

        var imageObject = new GameObject();
        var imageComponent = imageObject.AddComponent<Image>();
        
        mushroomEnemy.PlayerLife.playerHealth = 5;
        mushroomEnemy.PlayerLife.anim = player.AddComponent<Animator>();
        mushroomEnemy.PlayerLife.damageSound = player.AddComponent<AudioSource>();
        mushroomEnemy.PlayerLife.hearts = new Image[5];
        mushroomEnemy.PlayerLife.hearts[4] = imageComponent;
        mushroomEnemy.PlayerLife.emptyHearts = Sprite.Create(new Texture2D(10, 10), Rect.zero, new Vector2(0, 0));

        mushroomEnemy.transform.position = player.transform.position;
        mushroomEnemy.DamagePlayer();
        mushroomEnemy.PlayerLife.TakeDamage(mushroomEnemy.damage);
        
        Assert.AreEqual(4, mushroomEnemy.PlayerLife.playerHealth);
    }
    
    [Test]
    public void TestPlayerReactsToSkeletonAttack()
    {
        var skeleton = new GameObject { tag = "SkeletonEnemy" };
        var skeletonEnemy = skeleton.AddComponent<SkeletonEnemy>();
        
        skeletonEnemy.attackSkeleton = skeleton.AddComponent<AudioSource>();
        skeletonEnemy.boxCollider = skeleton.AddComponent<BoxCollider2D>();
        skeletonEnemy.playerLayer = new LayerMask();
        skeletonEnemy.PlayerLife = skeleton.AddComponent<PlayerLife>();
        skeletonEnemy.range = 1f;
        skeletonEnemy.colliderDistance = 2f;
        
        var player = new GameObject("Player") { tag = "Player" };
        player.AddComponent<BoxCollider2D>();

        var imageObject = new GameObject();
        var imageComponent = imageObject.AddComponent<Image>();
        
        skeletonEnemy.PlayerLife.playerHealth = 5;
        skeletonEnemy.PlayerLife.anim = player.AddComponent<Animator>();
        skeletonEnemy.PlayerLife.damageSound = player.AddComponent<AudioSource>();
        skeletonEnemy.PlayerLife.hearts = new Image[5];
        skeletonEnemy.PlayerLife.hearts[4] = imageComponent;
        skeletonEnemy.PlayerLife.emptyHearts = Sprite.Create(new Texture2D(10, 10), Rect.zero, new Vector2(0, 0));

        skeletonEnemy.transform.position = player.transform.position;
        skeletonEnemy.DamagePlayer();
        skeletonEnemy.PlayerLife.TakeDamage(skeletonEnemy.damage);
        
        Assert.AreEqual(4, skeletonEnemy.PlayerLife.playerHealth);
    }
    
    [Test]
    public void TestPlayerReactsToFlyingEyeAttack()
    {
        var flyingEye = new GameObject { tag = "FlyingEyeEnemy" };
        var flyingEyeEnemy = flyingEye.AddComponent<FlyingEyeEnemy>();
        
        flyingEyeEnemy.attackFlyingEye = flyingEye.AddComponent<AudioSource>();
        flyingEyeEnemy.boxCollider = flyingEye.AddComponent<BoxCollider2D>();
        flyingEyeEnemy.playerLayer = new LayerMask();
        flyingEyeEnemy.PlayerLife = flyingEye.AddComponent<PlayerLife>();
        flyingEyeEnemy.range = 1f;
        flyingEyeEnemy.colliderDistance = 2f;
        
        var player = new GameObject("Player") { tag = "Player" };
        player.AddComponent<BoxCollider2D>();

        var imageObject = new GameObject();
        var imageComponent = imageObject.AddComponent<Image>();
        
        flyingEyeEnemy.PlayerLife.playerHealth = 5;
        flyingEyeEnemy.PlayerLife.anim = player.AddComponent<Animator>();
        flyingEyeEnemy.PlayerLife.damageSound = player.AddComponent<AudioSource>();
        flyingEyeEnemy.PlayerLife.hearts = new Image[5];
        flyingEyeEnemy.PlayerLife.hearts[4] = imageComponent;
        flyingEyeEnemy.PlayerLife.emptyHearts = Sprite.Create(new Texture2D(10, 10), Rect.zero, new Vector2(0, 0));

        flyingEyeEnemy.transform.position = player.transform.position;
        flyingEyeEnemy.DamagePlayer();
        flyingEyeEnemy.PlayerLife.TakeDamage(flyingEyeEnemy.damage);
        
        Assert.AreEqual(4, flyingEyeEnemy.PlayerLife.playerHealth);
    }
    
    [Test]
    public void TestPlayerReactsToBossAttack()
    {
        var boss = new GameObject { tag = "BossEnemy" };
        var bossEnemy = boss.AddComponent<BossEnemy>();
        
        bossEnemy.attackBoss = boss.AddComponent<AudioSource>();
        bossEnemy.boxCollider = boss.AddComponent<BoxCollider2D>();
        bossEnemy.playerLayer = new LayerMask();
        bossEnemy.PlayerLife = boss.AddComponent<PlayerLife>();
        bossEnemy.range = 1f;
        bossEnemy.colliderDistance = 2f;
        
        var player = new GameObject("Player") { tag = "Player" };
        player.AddComponent<BoxCollider2D>();

        var imageObject = new GameObject();
        var imageComponent = imageObject.AddComponent<Image>();
        
        bossEnemy.PlayerLife.playerHealth = 5;
        bossEnemy.PlayerLife.anim = player.AddComponent<Animator>();
        bossEnemy.PlayerLife.damageSound = player.AddComponent<AudioSource>();
        bossEnemy.PlayerLife.hearts = new Image[5];
        bossEnemy.PlayerLife.hearts[4] = imageComponent;
        bossEnemy.PlayerLife.emptyHearts = Sprite.Create(new Texture2D(10, 10), Rect.zero, new Vector2(0, 0));

        bossEnemy.transform.position = player.transform.position;
        bossEnemy.DamagePlayer();
        bossEnemy.PlayerLife.TakeDamage(bossEnemy.damage);
        
        Assert.AreEqual(4, bossEnemy.PlayerLife.playerHealth);
    }
}

