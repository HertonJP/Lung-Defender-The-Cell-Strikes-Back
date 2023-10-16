using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeHeroes : Heroes
{
    protected GameObject  projectile;
    private SetAttackPointRotation attackPointRotation;
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        attackPointRotation = _firingPoint.GetComponent<SetAttackPointRotation>();
        if (target == null)
            return;
        attackPointRotation.SetTarget(target);
    }

    protected override void Attack()
    {
        projectile = Instantiate(_projectilesPrefab, transform.position, Quaternion.identity);
        projectile.transform.rotation = _firingPoint.rotation;
        projectile.GetComponent<Projectiles>().SetTarget(target);
        attackPointRotation.SetTarget(target);
        projectile.transform.eulerAngles += new Vector3(0, 0, 90);
        base.Attack();
    }
}
