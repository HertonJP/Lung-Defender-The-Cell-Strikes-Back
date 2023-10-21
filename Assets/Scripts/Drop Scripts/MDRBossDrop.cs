using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MDRBossDrop : MonoBehaviour
{
    [SerializeField] private Inventory inven;


    public void mdrbossDrop()
    {
        for(int i = 1; i < 5; i++)
        {
            float randomValue = Random.Range(0f, 1f);
            if (randomValue <0.05)
            {
                inven.leftarm += 1;
            }
            else if (randomValue > 0.05 && randomValue <0.45)
            {
                inven.firoblast += 1;
            }
            else if (randomValue > 0.45)
            {
                inven.nucleus += 1;
            }
        }
        
    }
}
