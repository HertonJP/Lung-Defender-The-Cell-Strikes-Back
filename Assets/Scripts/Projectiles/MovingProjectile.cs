using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingProjectile : Projectiles
{

    // Update is called once per frame
    public virtual void Update()
    {
        if (target == null)
            Destroy(gameObject);
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            transform.position += (Vector3)direction * projectilesSpeed * Time.deltaTime;
        }

    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
    }
}
