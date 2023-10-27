using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public void GoLDScene(int stage)
    {
        Debug.Log("here");
        GameManager.Instance.targetStageLD = stage;
        SceneManager.LoadScene(2);

        //updater = GameObject.FindAnyObjectByType<InventoryUpdater>();
    }
}
