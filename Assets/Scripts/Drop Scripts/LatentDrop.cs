using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatentDrop : MonoBehaviour
{
    [SerializeField] private Inventory inven;


    public void latentDrop()
    {
        float randomValue = Random.Range(0f, 1f);
        if (randomValue > 0.35 && randomValue < 0.9)
        {
            inven.mycoclaw += 1;
        }
        else if (randomValue > 0.9)
        {
            inven.scale += 1;
        }
        else return;
    }
}
