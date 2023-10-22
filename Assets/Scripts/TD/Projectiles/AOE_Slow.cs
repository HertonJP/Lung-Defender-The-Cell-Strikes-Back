using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE_Slow : MovingProjectile
{
    public bool isUlt = false;
    public List<TD_AI> enemyAi = new();
    public float duration;
    public float slowedSpeed;
    public override void Update()
    {
        base.Update();
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
        if (isUlt)
        {
            foreach(TD_AI ai in enemyAi)
            {
                ai.slowDuration = duration;
                ai.slowedSpeed = slowedSpeed;
                ai.isSlowed = true;
            }
            isUlt = false;
        }

    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
