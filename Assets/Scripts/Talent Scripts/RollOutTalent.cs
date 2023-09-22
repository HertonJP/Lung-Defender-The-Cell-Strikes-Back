using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RollOutTalent", menuName = "Talents/RollOut")]
public class RollOutTalent : Talent
{
    public override void Activate(playerStats player)
    {
        player.isRollout = true;
        TalentUIManager.Instance.rollout.SetActive(true);
    }
}
