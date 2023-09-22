using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AgilityTalent", menuName = "Talents/Agility")]
public class AgilityTalent : Talent
{
    
    public override void Activate(playerStats player)
    {
        player.agility += 5;
        player.movementSpeed += 2.5f;
    }
}
