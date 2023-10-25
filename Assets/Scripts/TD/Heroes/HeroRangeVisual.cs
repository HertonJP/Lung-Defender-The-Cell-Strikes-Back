using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HeroRangeVisual : MonoBehaviour
{
    private Heroes hero;
    // Start is called before the first frame update
    void Start()
    {
        hero = GetComponentInParent<Heroes>();
        transform.localScale = new Vector2(hero.targetingRange * 5f, hero.targetingRange * 5f);
    }

}
