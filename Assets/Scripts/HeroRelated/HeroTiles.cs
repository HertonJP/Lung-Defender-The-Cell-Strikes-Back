using System;
using UnityEngine;

[Serializable]
public class HeroTiles
{
    public HeroSprites heroSprites;
    public string name;
    public int cost;
    public GameObject prefab;

    public HeroTiles(string _name, int _cost, GameObject _prefab)
    {
        name = _name;
        cost = _cost;
        prefab = _prefab;
    }
}
