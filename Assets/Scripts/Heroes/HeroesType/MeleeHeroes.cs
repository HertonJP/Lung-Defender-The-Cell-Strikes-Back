using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHeroes : Heroes 
{ 
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public void MeleeAttack()
    {
        if(target!=null)
            Instantiate(_projectilesPrefab, target.position, Quaternion.identity);
    }
}
