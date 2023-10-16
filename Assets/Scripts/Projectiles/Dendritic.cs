using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dendritic : MovingProjectile
{
    public override void Update()
    {
        base.Update();
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
        Destroy(gameObject);
    }
}
