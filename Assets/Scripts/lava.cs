using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour
{
    public playerStats player;
    [SerializeField] private Collider2D lavaPrefabs;

    public int lavaDamage = 20;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.TakeDamage(lavaDamage);
    }
}
