using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "BerserkTalent", menuName = "Talents/Berserk")]
public class BerserkTalent : Talent
{
    

    

    public override void Activate(playerStats player)
    {
        player.canBerserk = true;
        TalentUIManager.Instance.berserk.SetActive(true);
    }

    
}