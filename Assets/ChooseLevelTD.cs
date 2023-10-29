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
        //if (PlayerPrefs.GetInt(GameManager.Instance.lastTDLevelPlayerPrefs) == 0)
        //    levelButton[0].interactable = true;
        //else if (PlayerPrefs.GetInt(GameManager.Instance.lastTDLevelPlayerPrefs) == 1)
        //{
        //    levelButton[0].interactable = true;
        //    levelButton[1].interactable = true;
        //}
        //else if (PlayerPrefs.GetInt(GameManager.Instance.lastTDLevelPlayerPrefs) == 2)
        //{
        //    levelButton[0].interactable = true;
        //    levelButton[1].interactable = true;
        //    levelButton[2].interactable = true;
        //}
        for (int i = 0; i < PlayerPrefs.GetInt(GameManager.Instance.lastTDLevelPlayerPrefs,0) + 1; i++)
        {
            levelButton[i].interactable = true;
        }
    }

    public void GoSceneTD(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
