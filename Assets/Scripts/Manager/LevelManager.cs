using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public int nutrition;
    public Transform startPoint;
    public Transform[] path;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        nutrition = 100;
    }

    public void IncreaseCurrency(int amount)
    {
        nutrition += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= nutrition)
        {
            nutrition -= amount;
            return true;
        }
        else
        {
            Debug.Log("Not enough");
            return false;
        }
    }
}
