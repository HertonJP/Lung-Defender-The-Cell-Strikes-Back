using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RangeBossDrop : MonoBehaviour
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
    public void rangebossDrop()
    {
        StartCoroutine(DropItemsWithDelay()); 
    }

    private IEnumerator DropItemsWithDelay()
    {
        for (int i = 0; i < 5; i++)
        {
            float randomValue = Random.Range(0f, 1f);
            yield return new WaitForSeconds(0.5f);
            if (randomValue < 0.05)
            {
                GameObject text = Instantiate(itemTextPrefabs, itemTextPosition.transform.position, Quaternion.identity);
                TextMesh textMesh = text.GetComponent<TextMesh>();
                textMesh.color = Color.yellow;
                text.GetComponent<TextMesh>().text = "You Got " + 1 + " " + "Eyeball";
                inven.eyeball += 1;
            }
            else if (randomValue > 0.05 && randomValue < 0.45)
            {
                GameObject text = Instantiate(itemTextPrefabs, itemTextPosition.transform.position, Quaternion.identity);
                TextMesh textMesh = text.GetComponent<TextMesh>();
                textMesh.color = Color.yellow;
                text.GetComponent<TextMesh>().text = "You Got " + 1 + " " + "Club";
                inven.club += 1;
            }
            else if (randomValue > 0.45)
            {
                GameObject text = Instantiate(itemTextPrefabs, itemTextPosition.transform.position, Quaternion.identity);
                text.GetComponent<TextMesh>().text = "You Got " + 1 + " " + "MDR's Helmet";
                inven.mdrhelmet += 1;
            }
        }
        inven.SaveInventory();
    }
}
