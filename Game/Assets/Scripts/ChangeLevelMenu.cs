using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Level1()
    {   
        StartMenu.sceneIndex = 1;
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        StartMenu.sceneIndex = 2;
        SceneManager.LoadScene("Level2");
    }
    public void Level3()
    {
        StartMenu.sceneIndex = 3;
        SceneManager.LoadScene("Level3");
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
