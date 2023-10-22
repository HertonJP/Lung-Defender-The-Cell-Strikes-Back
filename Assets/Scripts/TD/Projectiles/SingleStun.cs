using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleStun : MovingProjectile
{
    public bool isUlt = false;
    public float stunDuration;
    public override void Update()
    {
        base.Update();
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
        if (other.collider.GetComponent<Stun>() != null && isUlt)
        {
            other.collider.GetComponent<Stun>().duration = stunDuration;
            other.collider.GetComponent<Stun>().isStunned = isUlt;
            isUlt = false;
        }

    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
