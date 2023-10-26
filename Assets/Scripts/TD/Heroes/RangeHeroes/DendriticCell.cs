using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DendriticCell : RangeHeroes
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private bool isUlt = false;
    [SerializeField] private float ultDuration;
    [SerializeField] private Transform laserShootPoint;
    [SerializeField] private Transform laserShootPoint2;
    [SerializeField] private float ultInitialDamage;
    [SerializeField] private float totalDamage = 0;
    private bool hasStartCoroutine = false;
    private Transform lastTarget;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip skillClip;
    [SerializeField] private ColliderRange laserCollider;

    private Transform currTarget;
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
            laserCollider.EnableCollider();
            Ulti();
        }

        if (timeUntilFire >= (1f / _attackSpeed) && target != null && !isUlt && isIdle)
        {
            animState.state = AnimationState.States.Attack;
            Attack();
            timeUntilFire = 0f;
        }

        if (isUlt)
        {
            if(laserCollider.laserTarget.Count>0)
                currTarget = laserCollider.laserTarget[0].transform;

            if (!hasStartCoroutine)
            {
                mana =0;
                UpdateManaBar();
                StartCoroutine(LaserCountDown(ultDuration));
                hasStartCoroutine = true;
            }

            if (currTarget != null)
            {
                source.clip = skillClip;
                source.Play();
                if (currTarget != lastTarget)
                {
                    totalDamage = 0;
                    lastTarget = currTarget;
                }

                totalDamage += (ultInitialDamage* Time.deltaTime);
                lineRenderer.positionCount = 2;

                if (GetComponent<SpriteRenderer>().flipX)
                    lineRenderer.SetPosition(0, laserShootPoint2.position);
                else
                    lineRenderer.SetPosition(0, laserShootPoint.position);

                lineRenderer.SetPosition(1, new Vector3(currTarget.position.x, currTarget.position.y+.5f,currTarget.position.z));
                currTarget.GetComponent<enemyHealth>().TakeDamage(totalDamage);
            }
            else
            {
                lineRenderer.positionCount = 1;

                if (GetComponent<SpriteRenderer>().flipX)
                    lineRenderer.SetPosition(0, laserShootPoint2.position);
                else
                    lineRenderer.SetPosition(0, laserShootPoint.position);

                totalDamage = 0;
            }
        }

    }

    protected override void Ulti()
    {
        isUlt = true;
        GetComponent<AudioSource>().Play();
        base.Ulti();
    }

    private IEnumerator LaserCountDown(float duration)
    {
        yield return new WaitForSeconds(duration);
        isUlt = false;
        laserCollider.DisableCollider();
        lineRenderer.positionCount = 1;

        if (GetComponent<SpriteRenderer>().flipX)
            lineRenderer.SetPosition(0, laserShootPoint2.position);
        else
            lineRenderer.SetPosition(0, laserShootPoint.position);

        totalDamage = 0;
        hasStartCoroutine = false;
        timeUntilFire = 0;
    }
}
