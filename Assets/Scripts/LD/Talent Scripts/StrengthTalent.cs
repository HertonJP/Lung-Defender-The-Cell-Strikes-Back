using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "StrengthTalent", menuName = "Talents/Strength")]
public class StrengthTalent : Talent
{
    public override void Activate(playerStats player)
    {
        player.strength += 5;
        player.attackDamage += 5;
        player.strTalent = true;
    }
}
