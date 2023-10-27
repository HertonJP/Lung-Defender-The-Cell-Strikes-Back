using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playerStats : MonoBehaviour
{
    public bool strTalent = false;
    public bool agiTalent = false;
    public bool vitTalent = false;
    public bool luckTalent = false;
    public bool cheat = false;
    [Header("Stats")]
    public int strength = 0;
    public int vit = 0;
    public int agility = 0;
    public int luck = 0;
    [Header("Attributes")]
    public int playerMaxHP = 100;
    public int xp = 0;
    public int playerLevel = 1;
    public float critChance = 0.5f;
    public int availableStatPoints = 0;
    public int attackDamage = 10;
    public float movementSpeed = 5f;
    public float rollCooldown = 2f;

    [Header("Visual Effects")]
    [SerializeField] private GameObject levelUpVFX;
    [SerializeField] private GameObject hitVFXPrefab;

    [Header("Audio")]
    [SerializeField] private AudioSource levelUpSFX;

    [Header("UI & Gameplay")]
    public GameObject gameOverPanel;
    public TalentUIManager talentUI;
    public ChooseTalentPanel chooseTalentPanel;
    public Transform shopSpawn;
    public float evasionChance = 0f;
    public bool canBerserk;
    public bool canRevive;
    public bool isRollout;
    public int damageMultiplier = 2;
    public float healthThreshold = 0.4f;
    private bool isBerserkActive;
    public int playerHP;
    public bool isLifestealActive = false;
    public float lifestealDuration = 5f;
    public float lifestealEndTime;
    public bool isImmune = false;
    public GameObject levelUpButton;
    public Shake shake;
    [SerializeField] private AudioSource critSFX;
    [SerializeField] private AudioSource gameOverSFX;

    private int[] xpThresholds = { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };

    private bool startedFlash = false;
    [SerializeField] private float flashDuration;
    [SerializeField] private Material flashMaterial;
    private Material normalMats;

    private void Start()
    {
        PlayerPrefs.GetInt("xp", xp);
        PlayerPrefs.GetInt("Str", strength);
        PlayerPrefs.GetInt("Vit", vit);
        PlayerPrefs.GetInt("Agi", agility);
        PlayerPrefs.GetInt("Luck", luck);
        PlayerPrefs.GetInt("MaxHP", playerMaxHP);
        PlayerPrefs.GetInt("Level", playerLevel);
        PlayerPrefs.GetFloat("CritCh", critChance);
        PlayerPrefs.GetInt("Attack", attackDamage);
        PlayerPrefs.GetFloat("Speed", movementSpeed);
        levelUpButton.SetActive(false);
        gameOverPanel.SetActive(false);
        this.gameObject.transform.position = shopSpawn.transform.position;
        canRevive = false;
        isRollout = false;
        canBerserk = false;
        playerHP = playerMaxHP;
        StartCoroutine(CheckForLowHealth());
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        normalMats = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        if (availableStatPoints > 0)
        {
            levelUpButton.SetActive(true);
        }
        if(availableStatPoints <= 0 || Time.timeScale == 0)
        {
            levelUpButton.SetActive(false);
        }
        if (isLifestealActive && Time.time >= lifestealEndTime)
        {
            isLifestealActive = false;
        }
    }

    public void GainXP(int amount)
    {
        xp += amount;
        CheckLevelUp();
    }

    public void CheckLevelUp()
    {
        int nextLevelThreshold = xpThresholds[playerLevel - 1];
        if (xp >= nextLevelThreshold && playerLevel <= 14)
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
        levelUpSFX.Play();
        GameObject instantiatedVFX = Instantiate(levelUpVFX, transform.position, Quaternion.identity);
        Destroy(instantiatedVFX, 2f);

    }

    public void Heal(int amount)
    {
        playerHP = Mathf.Min(playerMaxHP, playerHP + amount);
    }
    public int CalculateDamage(int baseDamage)
    {
        if (UnityEngine.Random.value <= critChance)
        {
            shake.CamShake();
            critSFX.Play();
            return baseDamage * 2;
        }
        else
        {
            return baseDamage;
        }
    }

    public void TakeDamage(int damage)
    {
        StartCoroutine(Flash());

        if (UnityEngine.Random.Range(0f, 1f) < evasionChance)
        {
            Debug.Log("Miss");
            return;
        }

        playerHP -= damage;

        if (playerHP <= 0)
        {
            playerHP = 0;
            if (canRevive)
            {
                Debug.Log("Revived");
                playerHP = playerMaxHP / 2;

                if (talentUI != null && talentUI.revive != null)
                {
                    talentUI.revive.SetActive(false);
                }

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

    public void ActivateLifesteal()
    {
        if (Time.time - lifestealEndTime > 20)
        {
            isLifestealActive = true;
            lifestealEndTime = Time.time + lifestealDuration;
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
        gameOverPanel.SetActive(true);
        gameOverSFX.Play();
        Time.timeScale = 0f;
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
                    critChance += 0.025f; 
                    break;
            }
            availableStatPoints--;
        }
    }

    private IEnumerator Flash()
    {
        startedFlash = true;
        GetComponent<SpriteRenderer>().material = flashMaterial;
        yield return new WaitForSeconds(flashDuration);
        GetComponent<SpriteRenderer>().material = normalMats;
        startedFlash = false;
    }

    public void SavePlayerStats()
    {
        PlayerPrefs.SetInt("xp", xp);
        PlayerPrefs.SetInt("Str", strength);
        PlayerPrefs.SetInt("Vit", vit);
        PlayerPrefs.SetInt("Agi", agility);
        PlayerPrefs.SetInt("Luck", luck);
        PlayerPrefs.SetInt("MaxHP", playerMaxHP);
        PlayerPrefs.SetInt("Level", playerLevel);
        PlayerPrefs.SetFloat("CritCh", critChance);
        PlayerPrefs.SetInt("Attack", attackDamage);
        PlayerPrefs.SetFloat("Speed", movementSpeed);
    }
}