using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
	public GameObject SettingUI;
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
