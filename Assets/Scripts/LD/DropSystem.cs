using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSystem : MonoBehaviour
{
    public Inventory inventory;
    public void dropNucleus()
    {
        inventory.nucleus += 1;
    }

    public void dropMycoClaw()
    {
        inventory.mycoclaw += 1;
    }

    public void dropScale()
    {
        inventory.mycoclaw += 1;
    }

    public void dropFiroBlast()
    {
        inventory.fibroblast += 1;
    }

    public void dropMdrHelmet()
    {
        inventory.mdrhelmet += 1;
    }

    public void dropResistantSample()
    {
        inventory.resistantsample += 1;
    }

    public void dropClub()
    {
        inventory.club += 1;
    }

    public void dropLeftArm()
    {
        inventory.leftarm += 1;
    }

    public void dropEyeball()
    {
        inventory.eyeball += 1;
    }
}
