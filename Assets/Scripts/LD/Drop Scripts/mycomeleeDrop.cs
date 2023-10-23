using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mycomeleeDrop : MonoBehaviour
{
    [SerializeField] private Inventory inven;
    

    public void mmDrop()
    {
        float randomValue = Random.Range(0f, 1f);
        if (randomValue > 0.3 && randomValue < 0.5)
        {
            inven.nucleus += 1;
        }
        else if (randomValue > 0.5)
        {
            inven.mycoclaw += 1;
        }
        else return;
    }
}
