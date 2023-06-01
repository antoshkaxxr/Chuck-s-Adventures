using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelTests
{
    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("Scenes/Level2");
    }

    [Test]
    public void TestLoadingNextSceneWhenPlayerFacesCollisionTrip()
    {
        // Arrange
        var tripTrigger = new GameObject("TripTrigger")
        {
            tag = "Trip"
        };
        var tripCollider = tripTrigger.AddComponent<BoxCollider2D>();
        tripCollider.isTrigger = true;

        var player = new GameObject("Player")
        {
            tag = "Player"
        };
        player.AddComponent<BoxCollider2D>();

        // Act
        tripCollider.transform.position = player.transform.position;

        // Assert
        Assert.AreEqual(4, SceneManager.GetActiveScene().buildIndex);
    }
}
