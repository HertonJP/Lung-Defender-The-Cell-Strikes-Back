using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Cells : RangeHeroes
{
    [SerializeField] private float bonusAttSpeed;
    [SerializeField] private float bonusAttSpeedDuration;
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
    }

    protected override void Ulti()
    {
        GetComponent<AudioSource>().Play();
        StartCoroutine(AttackSpeedBonus());
        base.Ulti();

    }

    private IEnumerator AttackSpeedBonus()
    {
        mana = 0;
        UpdateManaBar();
        _attackSpeed += bonusAttSpeed;
        manaIncrease = 0;
        yield return new WaitForSeconds(bonusAttSpeedDuration);
        _attackSpeed -= bonusAttSpeed;
        manaIncrease = 40;
    }
}
