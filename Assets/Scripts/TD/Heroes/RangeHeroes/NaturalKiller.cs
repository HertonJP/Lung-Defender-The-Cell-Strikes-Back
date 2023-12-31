using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalKiller : RangeHeroes
{
    [SerializeField] private float stunDuration;
    [SerializeField] protected bool isUlt;
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        if ((mana + manaIncrease) >= maxMana)
        {
            Ulti();
        }
        if (timeUntilFire >= (1f / _attackSpeed) && target != null && isIdle)
        {
            animState.state = AnimationState.States.Attack;
            Attack();
            timeUntilFire = 0f;
        }
    }

    protected override void Ulti()
    {
        isUlt = true;

    }

    protected override void Attack()
    {
        base.Attack();
        if (isUlt)
        {
            mana = 0;
            base.Ulti();
            projectile.GetComponent<SingleStun>().source.clip = projectile.GetComponent<SingleStun>().skillClip;
            projectile.GetComponent<SingleStun>().source.Play();
        }
           
        UpdateManaBar();
        projectile.GetComponent<SingleStun>().isUlt = isUlt;
        projectile.GetComponent<SingleStun>().stunDuration = stunDuration;
        isUlt = false;
    }
}
