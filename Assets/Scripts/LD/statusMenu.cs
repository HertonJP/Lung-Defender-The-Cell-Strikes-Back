using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class statusMenu : MonoBehaviour
{
    public TextMeshProUGUI maxHealth;
    public TextMeshProUGUI attack;
    public TextMeshProUGUI critRate;
    public TextMeshProUGUI critDamage;
    public TextMeshProUGUI movementSpeed;

    public TextMeshProUGUI strength;
    public TextMeshProUGUI vit;
    public TextMeshProUGUI agi;
    public TextMeshProUGUI luck;
    public TextMeshProUGUI statPoints;

    private float critRateConv;
    public playerStats player;

    private void Update()
    {
        maxHealth.text = player.playerMaxHP.ToString();
        attack.text = player.attackDamage.ToString();
        critRateConv = player.critChance * 100f;
        critRate.text = critRateConv.ToString("F2") + "%";
        critDamage.text = "200%";
        movementSpeed.text = player.movementSpeed.ToString();

        strength.text = player.strength.ToString();
        vit.text = player.vit.ToString();
        agi.text = player.agility.ToString();
        luck.text = player.luck.ToString();
        statPoints.text = player.availableStatPoints.ToString();
    }
}
