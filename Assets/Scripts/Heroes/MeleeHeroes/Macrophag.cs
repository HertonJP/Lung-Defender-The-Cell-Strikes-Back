using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Macrophag : MeleeHeroes
{
    [SerializeField] private GameObject hammer;
    [SerializeField] private float hammerYOffset;
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        if (mana >= maxMana)
        {
            Ulti();
        }
        if (timeUntilFire >= (1f / _attackSpeed) && target != null)
        {
            animState.state = AnimationState.States.Attack;
            Attack();
            timeUntilFire = 0f;
        }
    }

    protected override void Ulti()
    {
        mana -= maxMana;
        base.Ulti();
        Instantiate(hammer,new Vector2(target.position.x,target.position.y+hammerYOffset), Quaternion.identity);
        timeUntilFire = 0;
        return;
    }
}
