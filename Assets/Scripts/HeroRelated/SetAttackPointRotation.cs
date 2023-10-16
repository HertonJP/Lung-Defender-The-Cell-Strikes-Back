using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAttackPointRotation : MonoBehaviour
{
    public Transform target;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            return;
        }

        direction = (target.position - transform.position).normalized;
        transform.up = direction;
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
        direction = (target.position - transform.position).normalized;
        transform.up = direction;
    }
}
