using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RolloutHitboxDetector : MonoBehaviour
{
    public playerStats playerStats;
    [SerializeField] private Collider2D hitboxCollider;
    private HashSet<Enemy> hitEnemies = new HashSet<Enemy>();

    private void Update()
    {
        if (playerStats.isRollout && hitboxCollider.enabled)
        {
            CheckColliders();
        }
        else
        {
            hitEnemies.Clear();
        }
    }

    private void CheckColliders()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(hitboxCollider.transform.position, hitboxCollider.bounds.size, 0f);

        foreach (Collider2D collider in colliders)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy != null && !hitEnemies.Contains(enemy))
            {
                int damage = Mathf.RoundToInt(playerStats.playerMaxHP * 0.05f);
                enemy.TakeDamage(damage);
                hitEnemies.Add(enemy);

                if (playerStats.isLifestealActive)
                {
                    int healAmount = Mathf.RoundToInt(damage * 0.5f);
                    playerStats.playerHP = Mathf.Min(playerStats.playerHP + healAmount, playerStats.playerMaxHP);
                }
            }
        }
    }
}