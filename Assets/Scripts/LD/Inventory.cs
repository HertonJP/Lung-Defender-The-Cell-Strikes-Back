using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField] private InventoryUpdater update;

    private void Start()
    {
        LoadInventory();
    }

    public void SaveInventory()
    {
        GameManager.Instance.SaveItems("ResistantSample", resistantsample);
        update.resistantSampleText.text = resistantsample.ToString();

        GameManager.Instance.SaveItems("MDRHelmet", mdrhelmet);
        update.mdrHelmetText.text = mdrhelmet.ToString();

        GameManager.Instance.SaveItems("Nucleus", nucleus);
        update.nucleusText.text = nucleus.ToString();

        GameManager.Instance.SaveItems("Fibroblast", fibroblast);
        update.fibroBlastText.text = fibroblast.ToString();

        GameManager.Instance.SaveItems("LeftArm", leftarm);
        update.leftArmText.text = leftarm.ToString();

        GameManager.Instance.SaveItems("Scale", scale);
        update.scaleText.text = scale.ToString();

        GameManager.Instance.SaveItems("Club", club);
        update.clubText.text = club.ToString();

        GameManager.Instance.SaveItems("Eyeball", eyeball);
        update.eyeBallText.text = eyeball.ToString();

        GameManager.Instance.SaveItems("MycoClaw", mycoclaw);
        update.mycoClawText.text = mycoclaw.ToString();
    }

    public void LoadInventory()
    {
        
        nucleus = PlayerPrefs.GetInt("Nucleus");
        update.nucleusText.text = nucleus.ToString();

        mdrhelmet = PlayerPrefs.GetInt("MDRHelmet");
        update.mdrHelmetText.text = mdrhelmet.ToString();

        fibroblast = PlayerPrefs.GetInt("Fibroblast");
        update.fibroBlastText.text = fibroblast.ToString();

        leftarm = PlayerPrefs.GetInt("LeftArm");
        update.leftArmText.text = leftarm.ToString();

        scale = PlayerPrefs.GetInt("Scale");
        update.scaleText.text = scale.ToString();

        club = PlayerPrefs.GetInt("Club");
        update.clubText.text = club.ToString();

        eyeball = PlayerPrefs.GetInt("Eyeball");
        update.eyeBallText.text = eyeball.ToString();

        mycoclaw = PlayerPrefs.GetInt("MycoClaw");
        update.mycoClawText.text = mycoclaw.ToString();

        resistantsample = PlayerPrefs.GetInt("ResistantSample");
        update.resistantSampleText.text = resistantsample.ToString();
    }
}