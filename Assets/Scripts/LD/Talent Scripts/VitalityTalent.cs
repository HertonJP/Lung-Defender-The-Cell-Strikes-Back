using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VitalityTalent", menuName = "Talents/Vitality")]
public class VitalityTalent : Talent
{
    public override void Activate(playerStats player)
    {
        player.vit += 5;
        player.playerMaxHP += 50;
        player.playerHP += 50;
    }
}
