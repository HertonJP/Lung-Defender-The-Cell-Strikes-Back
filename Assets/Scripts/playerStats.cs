using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    [SerializeField] public int strength = 0;
    [SerializeField] public int vit = 0;
    [SerializeField] public int agility = 0;
    [SerializeField] public int luck = 0;

    [SerializeField] public int playerMaxHP = 100;
    [SerializeField] public int xp = 0;
    [SerializeField] public int playerLevel = 1;
    [SerializeField] public float critChance = 0.5f;
    [SerializeField] public int availableStatPoints = 0;
    [SerializeField] public int attackDamage = 10;

    [SerializeField] private GameObject hitVFXPrefab;

    public int playerHP;
    private int[] xpThresholds = { 0, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100};

    private void Start()
    {
        playerHP = playerMaxHP;
    }
    public void GainXP(int amount)
    {
        xp += amount;
        CheckLevelUp();
    }

    public void CheckLevelUp()
    {
        int nextLevelThreshold = xpThresholds[playerLevel - 1];
        if (xp >= nextLevelThreshold)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        playerLevel++;
        availableStatPoints += 3;
        xp = 0;
        Debug.Log("Player Leveled up");
    }

    public int CalculateDamage(int baseDamage)
    {
        if (Random.value <= critChance)
        {
            return baseDamage * 2; 
        }
        else
        {
            return baseDamage; 
        }
    }

    public void TakeDamage(int damage)
    {
        playerHP -= damage;
        if (playerHP <= 0)
        {
            Die();
        }
        else
        {
            PlayHitVFX();
        }
    }
    private void PlayHitVFX()
    {
        if (hitVFXPrefab != null)
        {
            GameObject hitVFXObject = Instantiate(hitVFXPrefab, transform.position, Quaternion.identity);
            Destroy(hitVFXObject, 0.3f);
        }
    }

    private void Die()
    {
        Debug.Log("mati");
        Destroy(gameObject);
    }

    public void AllocateStatPoint(int statIndex)
    {
        if (availableStatPoints > 0)
        {
            switch (statIndex)
            {
                case 0: // Strength
                    strength++;
                    attackDamage += 1; 
                    break;
                case 1: // Vitality
                    vit++;
                    playerMaxHP += 5;
                    playerHP += 5;
                    break;
                case 2: // Agility
                    agility++;
                    break;
                case 3: // Luck
                    luck++;
                    critChance += 0.05f; 
                    break;
            }
            availableStatPoints--;
        }
    }


    //misc
    public void ApplyKnockback(Vector2 direction, float force)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * force, ForceMode2D.Impulse);
    }
}