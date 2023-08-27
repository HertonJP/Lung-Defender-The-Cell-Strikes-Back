using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public Slider healthSlider;
    public Slider xpSlider;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI maxHealthText;
    public TextMeshProUGUI xpText;
    public TextMeshProUGUI maxXpText;

    public playerStats player;

    void Start()
    {
        healthSlider.maxValue = player.playerMaxHP;
        xpSlider.maxValue = 100;

        maxHealthText.text = player.playerMaxHP.ToString();
        maxXpText.text = "100";
    }

    void Update()
    {
        float currentHealth = player.playerHP;
        float currentXP = player.xp;

        healthSlider.value = currentHealth;
        xpSlider.value = currentXP;

        healthText.text = currentHealth.ToString();
        xpText.text = currentXP.ToString();
    }
}