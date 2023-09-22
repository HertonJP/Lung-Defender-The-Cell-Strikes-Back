using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectiles : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Vector2 initialDirection;
    [SerializeField] private float projectilesSpeed = 5f;
    [SerializeField] private int projectilesDamage = 5;

    private void FixedUpdate()
    {
        rb.velocity = initialDirection * projectilesSpeed;
    }

    public void SetInitialDirection(Vector2 direction)
    {
        initialDirection = direction.normalized;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerStats player = other.gameObject.GetComponent<playerStats>();
            if (player != null && !player.isImmune)
            {
                other.gameObject.GetComponent<playerStats>().TakeDamage(projectilesDamage);
            }
        }

        if (!other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}