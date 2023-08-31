using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossHealthUI : MonoBehaviour
{
    public Slider healthBar;
    public GameObject bossHealthPanel;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI maxHealthText;
    public Enemy enemy;
    
    void Update()
    {
        if (enemy == null || !enemy.gameObject.activeInHierarchy)
        {
            bossHealthPanel.SetActive(false);
            healthBar.gameObject.SetActive(false);
            return;
        }

        if (enemy.isBoss)
        {
            int currentHealth = enemy.enemyHP;
            int maxHealth = enemy.initialEnemyHP;

            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;

            healthText.text = currentHealth.ToString();
            maxHealthText.text = maxHealth.ToString();

            bossHealthPanel.SetActive(true);
            healthBar.gameObject.SetActive(true);
        }
        else
        {
            bossHealthPanel.SetActive(false);
            healthBar.gameObject.SetActive(false);
        }
    }
}