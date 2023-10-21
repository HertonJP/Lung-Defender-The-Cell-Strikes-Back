using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public int nutrition;
    public Transform startPoint;
    public Transform startPoint2;
    public Transform[] path;
    public Transform[] path2;
    public int enemyDamage;
    public int maxHealth;
    public int currHealth;
    public int spawnPoint;
    [SerializeField] private Image healthBar;
    [SerializeField] private TMP_Text currHealthText;

    private void Awake()
    {
        main = this;
    }

    private void Update()
    {
        //check if curr health <=0 show gameover
    }

    private void Start()
    {
        currHealth = maxHealth;
        UpdateHealthBar();
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

    public void UpdateHealthBar()
    {
        healthBar.fillAmount = (float) currHealth / maxHealth;
        currHealthText.text = currHealth.ToString();
    }
    public void EnemyDamage()
    {
        currHealth -= enemyDamage;
    }
}
