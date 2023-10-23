using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MDRBossDrop : MonoBehaviour
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
    public void mdrbossDrop()
    {
        for(int i = 1; i < 5; i++)
        {
            float randomValue = Random.Range(0f, 1f);
            Debug.Log(randomValue);
            if (randomValue <0.05)
            {
                GameObject text = Instantiate(itemTextPrefabs, itemTextPosition.transform.position, Quaternion.identity);
                text.GetComponent<TextMesh>().text = "You Got " + 1 + " " + "Left Arm";
                inven.leftarm += 1;
            }
            else if (randomValue > 0.05 && randomValue <0.45)
            {
                GameObject text = Instantiate(itemTextPrefabs, itemTextPosition.transform.position, Quaternion.identity);
                text.GetComponent<TextMesh>().text = "You Got " + 1 + " " + "Firoblast";
                inven.firoblast += 1;
            }
            else if (randomValue > 0.45)
            {
                GameObject text = Instantiate(itemTextPrefabs, itemTextPosition.transform.position, Quaternion.identity);
                text.GetComponent<TextMesh>().text = "You Got " + 1 + " " + "Nucleus";
                inven.nucleus += 1;
            }
        }
        
    }
}
