using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    [SerializeField] public int strength = 0;
    [SerializeField] public int vit = 0;
    [SerializeField] public int agility = 0;
    [SerializeField] public int luck = 0;

    [SerializeField] public int xp = 0;
    [SerializeField] public int playerLevel = 1;
    [SerializeField] public float critChance = 0.5f;
    [SerializeField] public int availableStatPoints = 0;
    [SerializeField] public int attackDamage = 10;

    private int[] xpThresholds = { 0, 25, 50, 75, 100, 100, 100, 100, 100, 100, 100};

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

    public void AllocateStatPoint(int statIndex)
    {
        if (availableStatPoints > 0)
        {
            switch (statIndex)
            {
                case 0: // Strength
                    strength++;
                    break;
                case 1: // Vitality
                    vit++;
                    break;
                case 2: // Agility
                    agility++;
                    break;
                case 3: // Luck
                    luck++;
                    break;
            }
            availableStatPoints--;
        }
    }
}