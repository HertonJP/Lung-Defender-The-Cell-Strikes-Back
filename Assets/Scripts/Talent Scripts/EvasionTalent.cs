using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "EvasionTalent", menuName = "Talents/Evasion")]
public class EvasionTalent : Talent
{

    public override void Activate(playerStats player)
    {
        player.evasionChance = 0.1f;
    }
}