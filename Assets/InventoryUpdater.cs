using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryUpdater : MonoBehaviour
{
    public TMP_Text mycoClawText;
    public TMP_Text mdrHelmetText;
    public TMP_Text leftArmText;
    public TMP_Text eyeBallText;
    public TMP_Text scaleText;
    public TMP_Text resistantSampleText;
    public TMP_Text fibroBlastText;
    public TMP_Text nucleusText;
    public TMP_Text clubText;

    public void SetMycoClawText(int amount)
    {
        mycoClawText.text = amount.ToString();
    }

    public void SetMDRHelmetText(int amount)
    {
        mdrHelmetText.text = amount.ToString();
    }

    public void SetLeftArmText(int amount)
    {
       leftArmText.text = amount.ToString();
    }

    public void SetEyeBallText(int amount)
    {
        eyeBallText.text = amount.ToString();
    }

    public void SetScaleText(int amount)
    {
        scaleText.text = amount.ToString();
    }

    public void SetResistantSampleText(int amount)
    {
        resistantSampleText.text = amount.ToString();
    }

    public void SetFibroblastText(int amount)
    {
        fibroBlastText.text = amount.ToString();
    }

    public void SetNucleusText(int amount)
    {
       nucleusText.text = amount.ToString();
    }

    public void SetClubText(int amount)
    {
        clubText.text = amount.ToString();
    }

    public void UpdateAllText()
    {
        mycoClawText.text = PlayerPrefs.GetInt("MycoClaw").ToString();
        mdrHelmetText.text = PlayerPrefs.GetInt("MDRHelmet").ToString();
        leftArmText.text = PlayerPrefs.GetInt("LeftArm").ToString();
        eyeBallText.text = PlayerPrefs.GetInt("Eyeball").ToString();
        scaleText.text = PlayerPrefs.GetInt("Scale").ToString();
        resistantSampleText.text = PlayerPrefs.GetInt("ResistantSample").ToString();
        fibroBlastText.text = PlayerPrefs.GetInt("Fibroblast").ToString();
        nucleusText.text = PlayerPrefs.GetInt("Nucleus").ToString();
        clubText.text = PlayerPrefs.GetInt("Club").ToString();
    }
}
