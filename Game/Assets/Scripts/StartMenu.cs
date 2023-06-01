using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
	public GameObject SettingUI;

	public GameObject Levels;

	public static int sceneIndex=1;

    [SerializeField] private AudioSource pressButton;

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
        pressButton.Play();
        SettingUI.SetActive(true);
    	SettingMenu settingMenu = FindObjectOfType<SettingMenu>();
    	settingMenu.LoadSettings(0);
    }
	
	public void ChangeLevel()
	{
        pressButton.Play();
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
        pressButton.Play();
        SettingUI.SetActive(false);
    }
}
