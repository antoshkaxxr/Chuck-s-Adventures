using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
	public GameObject SettingUI;
	public GameObject Levels;
	public static int sceneIndex=1;
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneIndex);
		PauseMenu.PauseGame = false;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
	
	public void SettingGame()
    {
        SettingUI.SetActive(true);
    	SettingMenu settingMenu = FindObjectOfType<SettingMenu>();
    	settingMenu.LoadSettings(0);
    }
	
	public void ChangeLevel()
	{
		Levels.SetActive(true);
	}
	
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingUI.SetActive(false);
        }
    }
	
	public void BackMenu()
    {
        SettingUI.SetActive(false);
    }
}
