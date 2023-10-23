using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class XDRDrop : MonoBehaviour
{
    [SerializeField] private GameObject itemTextPosition;
    [SerializeField] private Inventory inven;
    [SerializeField] private TextMeshProUGUI itemTextPrefabs;

    private void Start()
    {
        GameObject inventory = GameObject.FindGameObjectWithTag("Inventory");
        inven = inventory.GetComponent<Inventory>();
    }
    public void xdrDrop()
    {
        float randomValue = Random.Range(0f, 1f);
        if (randomValue > 0.45 && randomValue < 0.5)
        {
            inven.club += 1;
        }
        else if (randomValue > 0.5)
        {
            inven.resistantsample += 1;
        }
        else return;
    }
}
