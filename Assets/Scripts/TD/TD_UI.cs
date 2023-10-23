using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TD_UI : MonoBehaviour
{
    public void ReturnToLobby()
    {
        SceneManager.LoadScene(1);
    }
    public void Restart()
    {  
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
