using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageMushroomTests : MonoBehaviour
{
    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("Scenes/Level1");
    }

    [Test]
    public void TestMushroomGetsNoDamageWhenPlayerIsNotNear()
    {
        // Arrange
        var mushroom = new GameObject
        {
            tag = "MushroomEnemy"
        };
        var mushroomEnemy = mushroom.AddComponent<MushroomEnemy>();
        
        var damageMushroom = mushroom.AddComponent<DamageMushroom>();
        damageMushroom.mushroomEnemy1 = mushroomEnemy;
        damageMushroom.attackMob = mushroom.AddComponent<AudioSource>();
        damageMushroom.boxCollider = mushroom.AddComponent<BoxCollider2D>();
        damageMushroom.enemyLayer = new LayerMask();
        damageMushroom.range = 1f;
        damageMushroom.colliderDistance = 2f;
        
        var player = new GameObject("Player")
        {
            tag = "Player"
        };
        player.AddComponent<BoxCollider2D>();

        mushroomEnemy.enemyHealth = 5;
        mushroomEnemy.anim = mushroom.AddComponent<Animator>();
        
        // Act
        damageMushroom.DamageMushroomEnemy();
        
        Assert.AreEqual(5, mushroomEnemy.enemyHealth);
    }
    
    [Test]
    public void TestMushroomGetsDamage1FromPlayer()
    {
        // Arrange
        var mushroom = new GameObject
        {
            tag = "MushroomEnemy"
        };
        var mushroomEnemy = mushroom.AddComponent<MushroomEnemy>();
        
        var damageMushroom = mushroom.AddComponent<DamageMushroom>();
        damageMushroom.mushroomEnemy1 = mushroomEnemy;
        damageMushroom.attackMob = mushroom.AddComponent<AudioSource>();
        damageMushroom.boxCollider = mushroom.AddComponent<BoxCollider2D>();
        damageMushroom.enemyLayer = new LayerMask();
        damageMushroom.range = 1f;
        damageMushroom.colliderDistance = 2f;
        
            var player = new GameObject("Player")
        {
            tag = "Player"
        };
        player.AddComponent<BoxCollider2D>();

        mushroomEnemy.enemyHealth = 5;
        mushroomEnemy.anim = mushroom.AddComponent<Animator>();
        
        // Act
        mushroomEnemy.transform.position = player.transform.position;
        damageMushroom.DamageMushroomEnemy();
        mushroomEnemy.TakeDamage(damageMushroom.damage1);

        // Assert
        Assert.AreEqual(4, mushroomEnemy.enemyHealth);
    }
    
    [Test]
    public void TestMushroomGetsDamage2FromPlayer()
    {
        // Arrange
        var mushroom = new GameObject
        {
            tag = "MushroomEnemy"
        };
        var mushroomEnemy = mushroom.AddComponent<MushroomEnemy>();
        
        var damageMushroom = mushroom.AddComponent<DamageMushroom>();
        damageMushroom.mushroomEnemy1 = mushroomEnemy;
        damageMushroom.attackMob = new AudioSource();
        damageMushroom.boxCollider = mushroom.AddComponent<BoxCollider2D>();
        damageMushroom.enemyLayer = new LayerMask();
        damageMushroom.range = 1f;
        damageMushroom.colliderDistance = 2f;
        
        var player = new GameObject("Player")
        {
            tag = "Player"
        };
        player.AddComponent<BoxCollider2D>();

        mushroomEnemy.enemyHealth = 5;
        mushroomEnemy.anim = mushroom.AddComponent<Animator>();
        
        // Act
        mushroomEnemy.transform.position = player.transform.position;
        damageMushroom.DamageMushroomEnemy();
        mushroomEnemy.TakeDamage(damageMushroom.damage2);

        // Assert
        Assert.AreEqual(3, mushroomEnemy.enemyHealth);
    }
}

