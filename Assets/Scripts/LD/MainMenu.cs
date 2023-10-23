using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private SettingsMenuController settingsMenuController;

    public void Awake()
    {
        settingsMenuController = FindObjectOfType<SettingsMenuController>();
    }
    public void PlayGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenSettingMenu()
    {
        settingsMenuController.Show();
    }
}
