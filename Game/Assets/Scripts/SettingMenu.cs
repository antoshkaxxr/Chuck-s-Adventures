using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingMenu : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Toggle fullScreenToggle; // добавлено поле для чекбокса
    Resolution[] resolutions;
    int currentResolutionIndex;
    int tempResolutionIndex;

    bool prevFullscreenState;
    bool isFullScreen = true;

    // Start is called before the first frame update
    void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = new Resolution[]
        {
            new Resolution() { width = 640, height = 480 },
            new Resolution() { width = 800, height = 600 },
            new Resolution() { width = 1366, height = 768 },
            new Resolution() { width = 1600, height = 900 },
            new Resolution() { width = 1920, height = 1080 },
            new Resolution() { width = 1920, height = 1200 },
            new Resolution() { width = 2560, height = 1440 },
            new Resolution() { width = 2560, height = 1600 },
            new Resolution() { width = 3840, height = 2160 },
        };
        currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width
                && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
        tempResolutionIndex = currentResolutionIndex;
    }

    public void SetFullscreen(bool isFullscreen)
    {
        isFullScreen = isFullscreen;
        UpdateFullscreenToggle(); // обновление состояния чекбокса
    }

    public void SetResolution(int resolutionIndex)
    {
        tempResolutionIndex = resolutionIndex;
    }

    public void Back()
    {
        Screen.fullScreen = prevFullscreenState;
        SceneManager.LoadScene("StartMenu");
    }

    public void SaveSettings()
    {
        currentResolutionIndex = tempResolutionIndex;
        Resolution resolution = resolutions[currentResolutionIndex];
        Screen.SetResolution(resolution.width,
            resolution.height, isFullScreen);
        Screen.fullScreen = isFullScreen;
        PlayerPrefs.SetInt("FullscreenPreference", System.Convert.ToInt32(isFullScreen));
        PlayerPrefs.SetInt("ResolutionPreference", currentResolutionIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("FullscreenPreference"))
            isFullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else
            isFullScreen = true;
        prevFullscreenState = Screen.fullScreen;
        Screen.fullScreen = isFullScreen;
        tempResolutionIndex = currentResolutionIndex;

        UpdateFullscreenToggle(); // обновление состояния чекбокса
    }

    void UpdateFullscreenToggle()
    {
        if (fullScreenToggle != null)
            fullScreenToggle.isOn = isFullScreen;
    }
}
