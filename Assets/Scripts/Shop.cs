using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] private GameObject ShopPanel;


    private void Start()
    {
        ShopPanel.SetActive(false);
    }
    public void onClickPanel()
    {
        Time.timeScale = 0f;
        if (ShopPanel.activeSelf == true)
        {
            ShopPanel.SetActive(false);
        }
        else
        {
            ShopPanel.SetActive(true);
        }
    }

    public void closePanel()
    {
        Time.timeScale = 1f;
        ShopPanel.SetActive(false);
    }


    private void OnGUI()
    {
        currencyUI.text = LevelManager.main.nutrition.ToString();
    }

    public void SetSelected()
    {

    }
}