using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ReviveTalent", menuName = "Talents/Revive")]
public class Revive : Talent
{
    public override void Activate(playerStats player)
    {
        Debug.Log("Revive Talent");
        player.canRevive = true;
        TalentUIManager.Instance.revive.SetActive(true);
    }
}
