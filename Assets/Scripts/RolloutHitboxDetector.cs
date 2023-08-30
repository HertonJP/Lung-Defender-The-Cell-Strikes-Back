using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RolloutHitboxDetector : MonoBehaviour
{
    public playerStats playerStats;
    private Collider2D hitboxCollider;

    private void Start()
    {
        hitboxCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (playerStats.isRollout)
        {
            CheckColliders();
        }
    }

    private void CheckColliders()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(hitboxCollider.transform.position, hitboxCollider.bounds.size, 0f);

        foreach (Collider2D collider in colliders)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                int damage = Mathf.RoundToInt(playerStats.playerMaxHP * 0.05f);
                enemy.TakeDamage(damage);

                if (playerStats.isLifestealActive)
                {
                    int healAmount = Mathf.RoundToInt(damage * 0.5f);
                    playerStats.playerHP = Mathf.Min(playerStats.playerHP + healAmount, playerStats.playerMaxHP);
                }
            }
        }
    }
}