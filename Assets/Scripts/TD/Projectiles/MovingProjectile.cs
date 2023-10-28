using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingProjectile : Projectiles
{
    public List<Collision2D> colliders = new();
    private int hit = 0;
    // Update is called once per frame

    public virtual void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        else
        {
            Vector2 direction = (target.position - transform.position).normalized;
            transform.position += (Vector3)direction * projectilesSpeed * Time.deltaTime;
        }

    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        colliders.Add(other);

        GetComponent<Animator>().Play("Destroy");
        if (hit < 1)
        {
            base.OnCollisionEnter2D(colliders[0]);
            if (colliders.Count > 1)
            {
                int i = 0;
               foreach(Collision2D c in colliders)
               {
                    i++;
                    Debug.Log(i + " " + c.collider.GetComponent<enemyHealth>().HP);
               }
            }
           
        }
            
        ++hit;
        
    }
}
