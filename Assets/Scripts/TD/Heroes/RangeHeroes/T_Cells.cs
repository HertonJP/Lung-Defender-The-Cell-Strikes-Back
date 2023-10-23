using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Cells : RangeHeroes
{
    //[SerializeField] private float stunDuration;
    [SerializeField] protected bool isUlt;
    [SerializeField] GameObject arrowRain;
    [SerializeField] float arrowYOffset;
    // Start is called before the first frame update
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
        if (timeUntilFire >= (1f / _attackSpeed) && target != null && isIdle)
        {
            animState.state = AnimationState.States.Attack;
            Attack();
            timeUntilFire = 0f;
        }
        if (target != null)
            lastTargetPos = target.position;
    }

    protected override void Ulti()
    {
        if (isIdle)
        {
            mana = 0;
            UpdateManaBar();
            base.Ulti();
            if (target == null)
                Instantiate(arrowRain, new Vector2(lastTargetPos.x, lastTargetPos.y + arrowYOffset), Quaternion.identity);
            else
                Instantiate(arrowRain, new Vector2(target.position.x, target.position.y + arrowYOffset), Quaternion.identity);

            timeUntilFire = 0;
            return;
        }
    }
}
