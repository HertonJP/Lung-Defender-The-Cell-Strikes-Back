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
    [SerializeField] public float movementSpeed = 5f;
    [SerializeField] public float rollCooldown = 2f;

    [SerializeField] private GameObject hitVFXPrefab;

    public TalentUIManager talentUI;
    public ChooseTalentPanel chooseTalentPanel;
    public float evasionChance = 0f;
    public bool canBerserk;
    public bool canRevive;
    public bool isRollout;
    public int damageMultiplier = 2;
    public float healthThreshold = 0.4f;
    private bool isBerserkActive;
    public int playerHP;
    private int[] xpThresholds = { 0, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100};

    private void Start()
    {
        canRevive = false;
        isRollout = false;
        canBerserk = false;
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
        if (xp >= nextLevelThreshold && playerLevel <=4)
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

        chooseTalentPanel.ShowPanel();
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
        if (Random.Range(0f, 1f) < evasionChance)
        {
            Debug.Log("Miss");
            return;
        }

        playerHP -= damage;
        CheckForLowHealth();

        if (playerHP <= 0)
        {
            if (canRevive)
            {
                Debug.Log("Revived");
                playerHP = playerMaxHP / 2;
                talentUI.revive.SetActive(false);
                canRevive = false;
            }
            else
            {
                Die();
            }
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

    private IEnumerator CheckForLowHealth()
    {
        while (true)
        {
            if (playerHP <= playerMaxHP * healthThreshold && !isBerserkActive && canBerserk)
            {
                isBerserkActive = true;
                attackDamage *= damageMultiplier;
            }
            else if (playerHP > playerMaxHP * healthThreshold && isBerserkActive && canBerserk)
            {
                isBerserkActive = false;
                attackDamage /= damageMultiplier;
            }
            yield return new WaitForSeconds(0.5f);
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
                    attackDamage += 1; 
                    break;
                case 1: // Vitality
                    vit++;
                    playerMaxHP += 10;
                    playerHP += 10;
                    break;
                case 2: // Agility
                    agility++;
                    movementSpeed += 0.5f;
                    break;
                case 3: // Luck
                    luck++;
                    critChance += 0.05f; 
                    break;
            }
            availableStatPoints--;
        }
    }
}