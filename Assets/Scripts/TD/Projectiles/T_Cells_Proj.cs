using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Cells_Proj : MovingProjectile
{
    public override void Update()
    {
        base.Update();
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
        
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
