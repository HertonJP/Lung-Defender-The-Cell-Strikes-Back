using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MDRDrop : MonoBehaviour
{
    [SerializeField] private GameObject itemTextPosition;
    [SerializeField] private Inventory inven;
    [SerializeField] private GameObject itemTextPrefabs;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        itemTextPosition = player.transform.GetChild(4).gameObject;
        GameObject inventory = GameObject.FindGameObjectWithTag("Inventory");
        inven = inventory.GetComponent<Inventory>();
    }
    public void mdrDrop()
    {
        float randomValue = Random.Range(0f, 1f);
        if (randomValue > 0.4 && randomValue < 0.5)
        {
            GameObject text = Instantiate(itemTextPrefabs, itemTextPosition.transform.position, Quaternion.identity);
            text.GetComponent<TextMesh>().text = "You Got " + 1 + " " + "MDR's Helmet";
            inven.mdrhelmet += 1;
        }
        else if (randomValue > 0.5)
        {
            GameObject text = Instantiate(itemTextPrefabs, itemTextPosition.transform.position, Quaternion.identity);
            text.GetComponent<TextMesh>().text = "You Got " + 1 + " " + "Resistant Sample";
            inven.resistantsample += 1;
        }
        else return;
    }
}
