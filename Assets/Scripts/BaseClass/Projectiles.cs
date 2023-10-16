using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    protected Transform target;
    [SerializeField] protected float projectilesSpeed = 5f;
    [SerializeField] protected int projectilesDamage = 1;
    public int _projectilesDamage { get; set; }

    private void Start()
    {
        _projectilesDamage = projectilesDamage;
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (!target)
        {
            return;
        }

    }

    public virtual void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        other.gameObject.GetComponent<enemyHealth>().TakeDamage(_projectilesDamage);
    }
}