using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DendriticCell : RangeHeroes
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private bool isUlt = false;
    [SerializeField] private float ultDuration;
    [SerializeField] private Transform laserShootPoint;
    [SerializeField] private float ultInitialDamage;
    [SerializeField] private float totalDamage = 0;
    private bool hasStartCoroutine = false;
    private Transform lastTarget;
    public override void Start()
    {
        base.Start();
        lineRenderer = transform.GetChild(1).GetComponent<LineRenderer>();
    }

    public override void Update()
    {
        base.Update();
        if (mana >= maxMana)
        {
            timeUntilFire = 0;
            Ulti();
        }
        if (timeUntilFire >= (1f / _attackSpeed) && target != null && !isUlt)
        {
            animState.state = AnimationState.States.Attack;
            Attack();
            timeUntilFire = 0f;
        }

        if (isUlt)
        {
            if (!hasStartCoroutine)
            {
                mana -= maxMana;
                StartCoroutine(LaserCountDown(ultDuration));
                hasStartCoroutine = true;
            }

            if (target != null)
            {
                if (target != lastTarget)
                {
                    totalDamage = 0;
                    lastTarget = target;
                }
                totalDamage += (ultInitialDamage* Time.deltaTime);
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, laserShootPoint.position);
                lineRenderer.SetPosition(1, target.position);
                target.GetComponent<enemyHealth>().TakeDamage(totalDamage);
            }
            else
            {
                lineRenderer.positionCount = 1;
                lineRenderer.SetPosition(0, laserShootPoint.position);
                totalDamage = 0;
            }
        }

    }

    protected override void Ulti()
    {
        isUlt = true;
        base.Ulti();
    }

    private IEnumerator LaserCountDown(float duration)
    {
        yield return new WaitForSeconds(duration);
        isUlt = false;

        Debug.Log(mana);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, laserShootPoint.position);
        totalDamage = 0;
        hasStartCoroutine = false;
        timeUntilFire = 0;
    }
}
