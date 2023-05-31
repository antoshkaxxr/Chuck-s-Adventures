using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingMenu : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    int currentResolutionIndex;
    int tempResolutionIndex;
    

    // Start is called before the first frame update
    void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = new Resolution[]
        {
            new Resolution() { width = 1366, height = 768 },
            new Resolution() { width = 1600, height = 900 },
            new Resolution() { width = 1920, height = 1080 },
            new Resolution() { width = 2560, height = 1440 },
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
		resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
        tempResolutionIndex = currentResolutionIndex;
    }
    

    public void SetResolution(int resolutionIndex)
    {
        tempResolutionIndex = resolutionIndex;
    }

    public void Back()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void SaveSettings()
    {
        currentResolutionIndex = tempResolutionIndex;
        Resolution resolution = resolutions[currentResolutionIndex];
        Screen.SetResolution(resolution.width,
            resolution.height, true);
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
        tempResolutionIndex = currentResolutionIndex;
    }
}
