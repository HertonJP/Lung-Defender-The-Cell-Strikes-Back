using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MDRDrop : MonoBehaviour
{
    [SerializeField] private Inventory inven;


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
    }
}
