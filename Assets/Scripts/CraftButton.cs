using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftButton : MonoBehaviour
{
    [SerializeField] private string targetChar;
    [SerializeField] private Button craftButton;
    [SerializeField] private InventoryUpdater updater;

    private void Awake()
    {
        craftButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        ValidateCrafting(targetChar);
    }

    // Start is called before the first frame update
    private void ValidateCrafting(string targetChar)
    {
        switch (targetChar)
        {
            case "Killer T":
                if (PlayerPrefs.GetInt("Nucleus") >= 1 && PlayerPrefs.GetInt("MycoClaw") >= 3 && PlayerPrefs.GetInt(targetChar)==0)
                    craftButton.interactable = true;

                if (PlayerPrefs.GetInt(targetChar) == 1)
                {
                    craftButton.interactable = false;
                    craftButton.GetComponentInChildren<TMPro.TMP_Text>().text = "Crafted";
                }
                    
                break;
            case "Macrophag":
                if (PlayerPrefs.GetInt("Nucleus") >= 10 && PlayerPrefs.GetInt("Scale") >= 3 && PlayerPrefs.GetInt("MycoClaw")>=35 && PlayerPrefs.GetInt(targetChar) == 0)
                    craftButton.interactable = true;

                if (PlayerPrefs.GetInt(targetChar) == 1)
                {
                    craftButton.interactable = false;
                    craftButton.GetComponentInChildren<TMPro.TMP_Text>().text = "Crafted";
                }
                    
                break;
            case "Dendritic":
                if (PlayerPrefs.GetInt("Nucleus") >= 20 && PlayerPrefs.GetInt("MycoClaw") >= 50 && PlayerPrefs.GetInt("Fibroblast") >= 15 && PlayerPrefs.GetInt(targetChar) == 0)
                    craftButton.interactable = true;

                if (PlayerPrefs.GetInt(targetChar) == 1)
                {
                    craftButton.interactable = false;
                    craftButton.GetComponentInChildren<TMPro.TMP_Text>().text = "Crafted";
                }
                    
                break;
            case "Natural Killer":
                if (PlayerPrefs.GetInt("LeftArm") >= 1 && PlayerPrefs.GetInt("MDRHelmet") >= 5 && PlayerPrefs.GetInt("ResistantSample") >= 35 && PlayerPrefs.GetInt("Naturaal Killer") == 0)
                    craftButton.interactable = true;

                if (PlayerPrefs.GetInt("Naturaal Killer") == 1)
                {
                    craftButton.interactable = false;
                    craftButton.GetComponentInChildren<TMPro.TMP_Text>().text = "Crafted";
                }
                    
                break;
            case "B Cell":
                if (PlayerPrefs.GetInt("Eyeball") >= 1 && PlayerPrefs.GetInt("Club") >= 10 && PlayerPrefs.GetInt("ResistantSample") >= 50 && PlayerPrefs.GetInt(targetChar) == 0)
                    craftButton.interactable = true;

                if (PlayerPrefs.GetInt(targetChar) == 1)
                {
                    craftButton.interactable = false;
                    craftButton.GetComponentInChildren<TMPro.TMP_Text>().text = "Crafted";
                }
                    
                break;
            case "Memory Cell":
                if (PlayerPrefs.GetInt("LeftArm") >= 1 && PlayerPrefs.GetInt("Eyeball") >= 1 && PlayerPrefs.GetInt("Scale") >= 5 && PlayerPrefs.GetInt("MycoClaw") >= 75 && PlayerPrefs.GetInt(targetChar) == 0)
                    craftButton.interactable = true;

                if (PlayerPrefs.GetInt(targetChar) == 1)
                {
                    craftButton.interactable = false;
                    craftButton.GetComponentInChildren<TMPro.TMP_Text>().text = "Crafted";
                }
                    
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

                PlayerPrefs.SetInt("Nucleus", PlayerPrefs.GetInt("Nucleus") - 1);
                PlayerPrefs.SetInt("MycoClaw", PlayerPrefs.GetInt("MycoClaw") - 3);

                craftButton.interactable = false;
                craftButton.GetComponentInChildren<TMPro.TMP_Text>().text = "Crafted";
                break;
            case "Macrophag":
                GameManager.Instance.UpdateTDButtonPlayerPrefs("Macrophag");

                PlayerPrefs.SetInt("Nucleus", PlayerPrefs.GetInt("Nucleus") - 10);
                PlayerPrefs.SetInt("MycoClaw", PlayerPrefs.GetInt("MycoClaw") - 35);
                PlayerPrefs.SetInt("Scale", PlayerPrefs.GetInt("Scale") - 3);

                craftButton.interactable = false;
                craftButton.GetComponentInChildren<TMPro.TMP_Text>().text = "Crafted";
                break;
            case "Dendritic":
                GameManager.Instance.UpdateTDButtonPlayerPrefs("Dendritic");

                PlayerPrefs.SetInt("Nucleus", PlayerPrefs.GetInt("Nucleus") - 20);
                PlayerPrefs.SetInt("MycoClaw", PlayerPrefs.GetInt("MycoClaw") - 50);
                PlayerPrefs.SetInt("Fibroblast", PlayerPrefs.GetInt("Fibroblast") - 15);

                craftButton.interactable = false;
                craftButton.GetComponentInChildren<TMPro.TMP_Text>().text = "Crafted";
                break;
            case "Natural Killer":
                GameManager.Instance.UpdateTDButtonPlayerPrefs("Naturaal Killer");

                PlayerPrefs.SetInt("LeftArm", PlayerPrefs.GetInt("LeftArm") - 1);
                PlayerPrefs.SetInt("MDRHelmet", PlayerPrefs.GetInt("MDRHelmet") - 5);
                PlayerPrefs.SetInt("ResistantSample", PlayerPrefs.GetInt("ResistantSample") - 35);

                craftButton.interactable = false;
                craftButton.GetComponentInChildren<TMPro.TMP_Text>().text = "Crafted";
                break;
            case "B Cell":
                GameManager.Instance.UpdateTDButtonPlayerPrefs("B Cell");

                PlayerPrefs.SetInt("Eyeball", PlayerPrefs.GetInt("Eyeball") - 1);
                PlayerPrefs.SetInt("Club", PlayerPrefs.GetInt("Club") - 10);
                PlayerPrefs.SetInt("ResistantSample", PlayerPrefs.GetInt("ResistantSample") - 50);

                craftButton.interactable = false;
                craftButton.GetComponentInChildren<TMPro.TMP_Text>().text = "Crafted";
                break;
            case "Memory Cell":
                GameManager.Instance.UpdateTDButtonPlayerPrefs("Memory Cell");

                PlayerPrefs.SetInt("LeftArm", PlayerPrefs.GetInt("LeftArm") - 1);
                PlayerPrefs.SetInt("Eyeball", PlayerPrefs.GetInt("Eyeball") - 1);
                PlayerPrefs.SetInt("Scale", PlayerPrefs.GetInt("Scale") - 5);
                PlayerPrefs.SetInt("MycoClaw", PlayerPrefs.GetInt("MycoClaw") - 75);

                craftButton.interactable = false;
                craftButton.GetComponentInChildren<TMPro.TMP_Text>().text = "Crafted";
                break;
            default:
                break;
        }
        updater.UpdateAllText();
    }
}
