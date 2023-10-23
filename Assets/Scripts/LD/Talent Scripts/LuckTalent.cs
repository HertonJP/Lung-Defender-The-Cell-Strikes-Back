using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LuckTalent", menuName = "Talents/Luck")]
public class LuckTalent : Talent
{
    public override void Activate(playerStats player)
    {
        player.luck += 5;
        player.critChance += 0.125f;
    }
}
