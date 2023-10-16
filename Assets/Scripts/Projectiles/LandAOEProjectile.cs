using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAOEProjectile : Projectiles
{
    [SerializeField] protected List<enemyHealth> enemies = new();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<enemyHealth>() != null)
        {
            enemies.Add(collision.GetComponent<enemyHealth>());
        }
    }

    public void AOEDamage()
    {
        foreach(enemyHealth e in enemies)
        {
            e.TakeDamage(projectilesDamage);
        }
        Debug.Log("Kena :" + enemies.Count);
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
