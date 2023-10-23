using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RangeBossDrop : MonoBehaviour
{
    [SerializeField] private GameObject itemTextPosition;
    [SerializeField] private Inventory inven;
    [SerializeField] private TextMeshProUGUI itemTextPrefabs;

    private void Start()
    {
        GameObject inventory = GameObject.FindGameObjectWithTag("Inventory");
        inven = inventory.GetComponent<Inventory>();
    }
    public void rangebossDrop()
    {
        for (int i = 1; i < 5; i++)
        {
            float randomValue = Random.Range(0f, 1f);
            if (randomValue < 0.05)
            {
                inven.eyeball += 1;
            }
            else if (randomValue > 0.05 && randomValue < 0.45)
            {
                inven.club += 1;
            }
            else if (randomValue > 0.45)
            {
                inven.helmet += 1;
            }
        }
        inven.SaveInventory();
    }
}
