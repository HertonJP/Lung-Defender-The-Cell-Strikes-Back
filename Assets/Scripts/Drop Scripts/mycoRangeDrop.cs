using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mycoRangeDrop : MonoBehaviour
{
    [SerializeField] private Inventory inven;


    public void mrDrop()
    {
        float randomValue = Random.Range(0f, 1f);
        if (randomValue > 0.25 && randomValue < 0.4)
        {
            inven.firoblast += 1;
        }
        else if (randomValue > 0.4 && randomValue < 0.55)
        {
            inven.nucleus += 1;
        }
        else if (randomValue > 0.55)
        {
            inven.mycoclaw += 1;
        }
        else return;
    }
}
