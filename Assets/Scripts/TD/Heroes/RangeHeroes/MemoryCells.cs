using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCells : RangeHeroes
{
    [SerializeField] private float slowDuration;
    [SerializeField] private float slowedSpeed;
    [SerializeField] private bool isUlt = false;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        if ((mana+manaIncrease) >= maxMana)
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
        }
           
        UpdateManaBar();
        projectile.GetComponent<AOE_Slow>().isUlt = isUlt;
        projectile.GetComponent<AOE_Slow>().duration = slowDuration;
        projectile.GetComponent<AOE_Slow>().slowedSpeed = slowedSpeed;
        isUlt = false;
    }
}
