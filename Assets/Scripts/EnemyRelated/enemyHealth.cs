using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    [SerializeField] private float HP = 2;
    [SerializeField] private int worth = 20;
    bool debugged = false;
    private bool isDestroyed = false;
    public void TakeDamage(float damage)
    {
        HP -= damage;      
        if(HP <= 0 && !isDestroyed)
        {
            TD_Spawner.onEnemyDestroy.Invoke();
            LevelManager.main.IncreaseCurrency(worth);
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
