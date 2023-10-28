using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealCritDamage : MovingProjectile
{
    public bool isCrit = false;
    public int critDamage;

    public override void Update()
    {
        base.Update();
    }
    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (isCrit)
        {
            _projectilesDamage = critDamage;
        }
           
        base.OnCollisionEnter2D(other);
       
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
