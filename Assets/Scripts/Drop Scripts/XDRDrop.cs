using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XDRDrop : MonoBehaviour
{
    [SerializeField] private Inventory inven;


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
