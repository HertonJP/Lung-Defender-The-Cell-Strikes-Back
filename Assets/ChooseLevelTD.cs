using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseLevelTD: MonoBehaviour
{
    [SerializeField] List<Button> levelButton = new();
    private void OnEnable()
    {
        for (int i = 0; i < PlayerPrefs.GetInt(GameManager.Instance.lastTDLevelPlayerPrefs) + 1; i++)
        {
            levelButton[i].interactable = true;
        }
    }

    public void GoSceneTD(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
