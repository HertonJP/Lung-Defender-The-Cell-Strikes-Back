using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetStatsTalents : MonoBehaviour
{
    public playerStats player;

    public void resetAll()
    {
        resetStr();
        resetVit();
        resetAgi();
        resetLuck();
    }
    public void resetStr()
    {
        if (player.strTalent)
        {
            player.strength -= 5;
            player.attackDamage -= 5;
        }
    }

    public void resetVit()
    {
        if (player.vitTalent)
        {
            player.vit -= 5;
            player.playerMaxHP -= 50;
        }
    }

    public void resetAgi()
    {
        if (player.agiTalent)
        {
            player.agility -= 5;
            player.movementSpeed -= 2.5f;
        }
    }

    public void resetLuck()
    {
        if (player.luckTalent)
        {
            player.luck -= 5;
            player.critChance -= 0.125f;
        }
    }
}
