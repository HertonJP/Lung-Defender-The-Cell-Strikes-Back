using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MDRBossDrop : MonoBehaviour
{
    [SerializeField] private GameObject itemTextPosition;
    [SerializeField] private Inventory inven;
    [SerializeField] private TextMeshProUGUI itemTextPrefabs;

    private void Start()
    {
        GameObject inventory = GameObject.FindGameObjectWithTag("Inventory");
        inven = inventory.GetComponent<Inventory>();
    }
    public void mdrbossDrop()
    {
        for(int i = 1; i < 5; i++)
        {
            float randomValue = Random.Range(0f, 1f);
            if (randomValue <0.05)
            {
                inven.leftarm += 1;
            }
            else if (randomValue > 0.05 && randomValue <0.45)
            {
                inven.firoblast += 1;
            }
            else if (randomValue > 0.45)
            {
                inven.nucleus += 1;
            }
        }
        inven.SaveInventory();
    }
}
