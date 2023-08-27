using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "BerserkTalent", menuName = "Talents/Berserk")]
public class BerserkTalent : Talent
{
    public int damageMultiplier = 2; 
    public float healthThreshold = 0.4f;

    private bool isBerserkActive;

    public override void Activate(playerStats player)
    {
        TalentUIManager.Instance.berserk.SetActive(true);
        MonoBehaviour host = player.GetComponent<MonoBehaviour>();
        if (host != null)
        {
            host.StartCoroutine(CheckForLowHealth(player));
        }
    }

    private IEnumerator CheckForLowHealth(playerStats player)
    {
        while (true)
        {
            if (player.playerHP <= player.playerMaxHP * healthThreshold && !isBerserkActive)
            {
                isBerserkActive = true;
                player.attackDamage *= damageMultiplier;
            }
            else if (player.playerHP > player.playerMaxHP * healthThreshold && isBerserkActive)
            {
                isBerserkActive = false;
                player.attackDamage /= damageMultiplier;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}