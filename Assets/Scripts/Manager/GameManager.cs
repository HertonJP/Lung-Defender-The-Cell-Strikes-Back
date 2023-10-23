using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("TD Save")]
    public int lastUnlockedTDLevel = 0;
    [HideInInspector]
    public string lastTDLevelPlayerPrefs = "TDLevelPlayerPrefs";

    public List<string> itemsPlayerPrefs = new();
    public List<string> buttonPlayerPrefs = new();
    public string firstChar;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey(lastTDLevelPlayerPrefs))
            lastUnlockedTDLevel = PlayerPrefs.GetInt(lastTDLevelPlayerPrefs);
        ValidateButtonPlayerPrefs();
        UpdateLastUnlockedTDLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateLastUnlockedTDLevel()
    {
        PlayerPrefs.SetInt(lastTDLevelPlayerPrefs, lastUnlockedTDLevel);
    }

    public void UpdateTDButtonPlayerPrefs(string playerPrefs)
    {
        PlayerPrefs.SetInt(playerPrefs, 1);
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.SetInt(lastTDLevelPlayerPrefs, 0);
        foreach(string s in buttonPlayerPrefs)
        {
            if (s != firstChar)
                PlayerPrefs.SetInt(s, 0);
            else
                PlayerPrefs.SetInt(s, 1);
        }
    }

    private void ValidateButtonPlayerPrefs()
    {
        foreach (string s in buttonPlayerPrefs)
        {
            if (!PlayerPrefs.HasKey(s))
            {
                PlayerPrefs.SetInt(s, 0);
            }
        }
    } 

    public void GoTDScene()
    {
        SceneManager.LoadScene(3);
    }
}
