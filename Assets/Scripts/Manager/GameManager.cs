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
    public InventoryUpdater updater;
    public int targetStageLD;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (string s in itemsPlayerPrefs)
        {
            if (!PlayerPrefs.HasKey(s))
            {
                PlayerPrefs.SetInt(s, 0);
            }
        }

        if (PlayerPrefs.HasKey(lastTDLevelPlayerPrefs))
            lastUnlockedTDLevel = PlayerPrefs.GetInt(lastTDLevelPlayerPrefs);
        ValidateButtonPlayerPrefs();
        UpdateLastUnlockedTDLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (string s in itemsPlayerPrefs)
            {
                if (PlayerPrefs.HasKey(s))
                {
                    PlayerPrefs.SetInt(s, 100);
                }
            }
            updater.UpdateAllText();
        }

        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
        }
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
        foreach (string s in buttonPlayerPrefs)
        {
            if (s != firstChar)
                PlayerPrefs.SetInt(s, 0);
            else
                PlayerPrefs.SetInt(s, 1);
        }

        foreach (string s in itemsPlayerPrefs)
        {
            if (PlayerPrefs.HasKey(s))
                PlayerPrefs.SetInt(s, 0);
        }

        updater.UpdateAllText();
    }

    private void ValidateButtonPlayerPrefs()
    {
        foreach (string s in buttonPlayerPrefs)
        {
            if (!PlayerPrefs.HasKey(s))
                PlayerPrefs.SetInt(s, 0);

            if (s == firstChar)
                PlayerPrefs.SetInt(s, 1);
        }
    }

    public void GoTDScene()
    {
        SceneManager.LoadScene(3);
    }
    public void GoLDScene()
    {
        SceneManager.LoadScene(2);
    }

    public void SaveItems(string name, int itemCount)
    {
        string found = itemsPlayerPrefs.Find(x => x.Contains(name));
        if (found == null)
            Debug.Log("wrong item name");
        else
            PlayerPrefs.SetInt(found, itemCount);
    }

    public void UpdateInvenUIText()
    {
        updater.UpdateAllText();
    }
}