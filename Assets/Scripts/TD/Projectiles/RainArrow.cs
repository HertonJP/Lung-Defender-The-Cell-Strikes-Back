using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainArrow : MonoBehaviour
{
    [SerializeField] private List<enemyHealth> enemies;
    [SerializeField] private float arrowDamage;
    [SerializeField] private float nextDamageTime;
    bool hasStartCoroutine = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<enemyHealth>() != null)
        {
            enemies.Add(collision.GetComponent<enemyHealth>());
            collision.gameObject.GetComponent<enemyHealth>().TakeDamage(arrowDamage);
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<enemyHealth>() != null)
        {
            enemies.Remove(collision.GetComponent<enemyHealth>()); 
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!hasStartCoroutine)
        {
            StartCoroutine(ContinousDamage(collision));
        }
        
    }

    public void DestroyArrow()
    {
        Destroy(gameObject);
    }

    private IEnumerator ContinousDamage(Collider2D coll)
    {
        hasStartCoroutine = true;
        yield return new WaitForSeconds(nextDamageTime);
        for(int i=0; i < enemies.Count; i++)
        {
            if (enemies[i] == null)
                continue;
            enemies[i].TakeDamage(arrowDamage);
        }
        hasStartCoroutine = false;
    }

    public void EnableCollider()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }
}
