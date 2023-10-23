using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSprites : MonoBehaviour
{
    [SerializeField] private Sprite sprite;

    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
    }
}
