using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelMenu : MonoBehaviour
{
    [SerializeField] private AudioSource pressButton;

    public void Level1()
    {
        StartMenu.sceneIndex = 3;
        SceneManager.LoadScene("LoadingScene1");
    }
    public void Level2()
    {
        StartMenu.sceneIndex = 5;
        SceneManager.LoadScene("LoadingScene2");
    }
    public void Level3()
    {
        StartMenu.sceneIndex = 7;
        SceneManager.LoadScene("LoadingScene3");
    }
    
    public void Back()
    {
        SceneManager.LoadScene("StartMenu");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }
}
