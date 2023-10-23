using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MDRDrop : MonoBehaviour
{
    [SerializeField] private GameObject itemTextPosition;
    [SerializeField] private Inventory inven;
    [SerializeField] private TextMeshProUGUI itemTextPrefabs;

    private void Start()
    {
        GameObject inventory = GameObject.FindGameObjectWithTag("Inventory");
        inven = inventory.GetComponent<Inventory>();
    }
    public void mdrDrop()
    {
        float randomValue = Random.Range(0f, 1f);
        if (randomValue > 0.4 && randomValue < 0.5)
        {
            inven.mdrhelmet += 1;
        }
        else if (randomValue > 0.5)
        {
            inven.resistantsample += 1;
        }
        else return;
        inven.SaveInventory();
    }
}
