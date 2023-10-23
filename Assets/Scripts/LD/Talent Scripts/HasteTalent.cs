using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "HasteTalent", menuName = "Talents/Haste")]
public class HasteTalent : Talent
{
    public override void Activate(playerStats player)
    {
        player.movementSpeed += 2f;
        TalentUIManager.Instance.haste.SetActive(true);
    }
}
