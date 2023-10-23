using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int nucleus = 0;
    public int mycoclaw = 0;
    public int scale = 0;
    public int fibroblast = 0;
    public int mdrhelmet = 0;
    public int resistantsample = 0;
    public int club = 0;
    public int leftarm = 0;
    public int eyeball = 0;

    private void Start()
    {
        LoadInventory();
    }

    public void SaveInventory()
    {
        GameManager.Instance.SaveItems("ResistantSample", resistantsample);
        GameManager.Instance.SaveItems("MDRHelmet", mdrhelmet);
        GameManager.Instance.SaveItems("Nucleus", nucleus);
        GameManager.Instance.SaveItems("Fibroblast", fibroblast);
        GameManager.Instance.SaveItems("LeftArm", leftarm);
        GameManager.Instance.SaveItems("Scale", scale);
        GameManager.Instance.SaveItems("Club", club);
        GameManager.Instance.SaveItems("Eyeball", eyeball);
        GameManager.Instance.SaveItems("MycoClaw", mycoclaw);
    }

    public void LoadInventory()
    {
        nucleus = PlayerPrefs.GetInt("Nucleus");
        mdrhelmet = PlayerPrefs.GetInt("MDRHelmet");
        fibroblast = PlayerPrefs.GetInt("Fibroblast");
        leftarm = PlayerPrefs.GetInt("LeftArm");
        scale = PlayerPrefs.GetInt("Scale");
        club = PlayerPrefs.GetInt("Club");
        eyeball = PlayerPrefs.GetInt("Eyeball");
        mycoclaw = PlayerPrefs.GetInt("MycoClaw");
    }
}