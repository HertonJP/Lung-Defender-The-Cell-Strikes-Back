using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mycoRangeDrop : MonoBehaviour
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
    public void mrDrop()
    {
        float randomValue = Random.Range(0f, 1f);
        if (randomValue > 0.25 && randomValue < 0.4)
        {
            GameObject text = Instantiate(itemTextPrefabs, itemTextPosition.transform.position, Quaternion.identity);
            TextMesh textMesh = text.GetComponent<TextMesh>();
            textMesh.color = Color.magenta;
            text.GetComponent<TextMesh>().text = "You Got " + 1 + " " + "Firoblast";
            inven.fibroblast += 1;
        }
        else if (randomValue > 0.4 && randomValue < 0.55)
        {
            GameObject text = Instantiate(itemTextPrefabs, itemTextPosition.transform.position, Quaternion.identity);
            TextMesh textMesh = text.GetComponent<TextMesh>();
            textMesh.color = Color.blue;
            text.GetComponent<TextMesh>().text = "You Got " + 1 + " " + "Nucleus";
            inven.nucleus += 1;
        }
        else if (randomValue > 0.55)
        {
            GameObject text = Instantiate(itemTextPrefabs, itemTextPosition.transform.position, Quaternion.identity);
            text.GetComponent<TextMesh>().text = "You Got " + 1 + " " + "Myco's Claw";
            inven.mycoclaw += 1;
        }
        else return;
        inven.SaveInventory();
    }
}
