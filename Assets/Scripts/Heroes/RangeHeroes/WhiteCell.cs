using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCell : RangeHeroes
{
    [SerializeField] private int bonusAtt;
    [SerializeField] protected bool isUlt;
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
        if (timeUntilFire >= (1f / _attackSpeed) && target != null)
        {
            animState.state = AnimationState.States.Attack;
            Attack();
            timeUntilFire = 0f;
        }
    }

    protected override void Ulti()
    {
        isUlt = true;
        base.Ulti();
    }
    protected override void Attack()
    {
        base.Attack();
        if (isUlt)
            mana -= maxMana;
        projectile.GetComponent<DealCritDamage>().isCrit = isUlt;
        projectile.GetComponent<DealCritDamage>().critDamage = bonusAtt;
        isUlt = false;
    }
}
