using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftButton : MonoBehaviour
{
    [SerializeField] private string targetChar;
    private Button craftButton;
    private void Start()
    {
        craftButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        
        ValidateCrafting(targetChar);
    }

    private void OnDisable()
    {
        Debug.Log("b");
    }

    // Start is called before the first frame update
    private void ValidateCrafting(string targetChar)
    {
        switch (targetChar)
        {
            case "Killer T":
                if (PlayerPrefs.GetInt("Nucleus") == 1 && PlayerPrefs.GetInt("MycoClaw") == 3)
                    craftButton.interactable = true;
                break;
            case "Macrophag":
                if (PlayerPrefs.GetInt("Nucleus") == 10 && PlayerPrefs.GetInt("Scale") == 3 && PlayerPrefs.GetInt("MycoClaw")==35)
                    craftButton.interactable = true;
                break;
            case "Dendritic":
                if (PlayerPrefs.GetInt("Nucleus") == 20 && PlayerPrefs.GetInt("MycoClaw") == 50 && PlayerPrefs.GetInt("Fibroblast") == 15)
                    craftButton.interactable = true;
                break;
            case "Natural Killer":
                if (PlayerPrefs.GetInt("LeftArm") == 1 && PlayerPrefs.GetInt("MDRHelmet") == 5 && PlayerPrefs.GetInt("ResistantSample") == 35)
                    craftButton.interactable = true;
                break;
            case "B Cell":
                if (PlayerPrefs.GetInt("Eyeball") == 1 && PlayerPrefs.GetInt("Club") == 10 && PlayerPrefs.GetInt("ResistantSample") == 50)
                    craftButton.interactable = true;
                break;
            case "Memory Cell":
                if (PlayerPrefs.GetInt("LeftArm") == 1 && PlayerPrefs.GetInt("Eyeball") == 1 && PlayerPrefs.GetInt("Scale") == 5 && PlayerPrefs.GetInt("MycoClaw") == 75)
                    craftButton.interactable = true;
                break;
            default:
                break;
        }
    }

    public void Craft()
    {
        switch (targetChar)
        {
            case "Killer T":
                GameManager.Instance.UpdateTDButtonPlayerPrefs("Killer T");
                break;
            case "Macrophag":
                GameManager.Instance.UpdateTDButtonPlayerPrefs("Macrophag");
                break;
            case "Dendritic":
                GameManager.Instance.UpdateTDButtonPlayerPrefs("Dendritic");
                break;
            case "Natural Killer":
                GameManager.Instance.UpdateTDButtonPlayerPrefs("Naturaal Killer");
                break;
            case "B Cell":
                GameManager.Instance.UpdateTDButtonPlayerPrefs("B Cell");
                break;
            case "Memory Cell":
                GameManager.Instance.UpdateTDButtonPlayerPrefs("Memory Cell");
                break;
            default:
                break;
        }
    }
}
