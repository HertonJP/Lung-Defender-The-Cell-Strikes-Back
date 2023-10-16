using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacrophagHammer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<enemyHealth> enemies;
    [SerializeField] private int hammerDamage;
    [SerializeField] private float stunDuration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<enemyHealth>()!=null)
            enemies.Add(collision.GetComponent<enemyHealth>());
    }

    public void DealDamage()
    {
        foreach(enemyHealth e in enemies)
        {
            e.TakeDamage(hammerDamage);
        }
        Debug.Log("Hammer hit : "+enemies.Count);
    }

    public void DestroyHammer()
    {
        Destroy(gameObject);
    }
}
