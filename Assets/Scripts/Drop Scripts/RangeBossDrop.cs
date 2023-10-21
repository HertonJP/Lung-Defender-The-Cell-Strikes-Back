using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeBossDrop : MonoBehaviour
{
    [SerializeField] private Inventory inven;


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

    }
}
