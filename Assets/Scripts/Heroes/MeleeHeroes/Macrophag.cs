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
        if (timeUntilFire >= (1f / _attackSpeed) && target != null && isIdle)
        {
            animState.state = AnimationState.States.Attack;
            Attack();
            timeUntilFire = 0f;
        }
        if(target!=null)
            lastTargetPos = target.position;
    }

    protected override void Ulti()
    {
        if (isIdle)
        {
            mana = 0;
            base.Ulti();
            if (target == null)
                Instantiate(hammer, new Vector2(lastTargetPos.x, lastTargetPos.y + hammerYOffset), Quaternion.identity);
            else
                Instantiate(hammer, new Vector2(target.position.x, target.position.y + hammerYOffset), Quaternion.identity);
            timeUntilFire = 0;
            return;
        }
    }
}
