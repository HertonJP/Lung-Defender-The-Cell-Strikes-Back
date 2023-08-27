using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RollMachineTalent", menuName = "Talents/RollMachine")]
public class RollMachineTalent : Talent
{
    public override void Activate(playerStats player)
    {
        player.rollCooldown = 0f;
        TalentUIManager.Instance.doubleRoll.SetActive(true);
    }
}
