using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ReviveTalent", menuName = "Talents/Revive")]
public class Revive : Talent
{
    public override void Activate(playerStats player)
    {
        player.canRevive = true;
    }
}
