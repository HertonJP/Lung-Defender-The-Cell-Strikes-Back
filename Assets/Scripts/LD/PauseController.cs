using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseController : MonoBehaviour
{
    public string sceneName;
    public GameObject pauseMenu;
    public bool isPaused;
    // public GameObject tutorPanel;
    public GameObject gameOverPanel;
    public AudioSource pauseSFX;
    public AudioSource gameOverSFX;
    public GameObject inventoryUI;
    private bool invenUIOpen = false;

    private void Start()
    {
        pauseMenu.SetActive(false);
        // tutorGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            if (!inventoryUI.activeInHierarchy)
            {
                inventoryUI.SetActive(true);
                Time.timeScale = 0;
            }     
            else if (inventoryUI.activeInHierarchy)
            {
                inventoryUI.SetActive(false);
                if(!pauseMenu.activeInHierarchy)
                    Time.timeScale = 1;
            }

        }

    }

    //public void tutorGame()
    //{
    //    tutorPanel.SetActive(true);
    //    Time.timeScale = 0f;
    //    isPaused = true;
    //}

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        pauseSFX.Play();
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        if(!inventoryUI.activeInHierarchy)
            Time.timeScale = 1f;
        isPaused = false;
    }
    public void BackButton(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void RetryButton(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void ReturnLobbyButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lobby");
    }


    public void gameOver()
    {
        gameOverPanel.SetActive(true);
        gameOverSFX.Play();
        Time.timeScale = 0f;
        isPaused = true;
    }
}
