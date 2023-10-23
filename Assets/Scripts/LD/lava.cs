using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour
{
    public playerStats player;
    private Collider2D lavaCollider;
    public int lavaDamage = 20;

    private void Start()
    {
        lavaCollider = GetComponent<Collider2D>();
        lavaCollider.enabled = false;
        player = FindObjectOfType<playerStats>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && !player.isImmune)
        {
            player.TakeDamage(lavaDamage);
        }
    }

    public void EnableCollider()
    {
        if (lavaCollider != null)
        {
            lavaCollider.enabled = true;
        }
    }

    public void DisableCollider()
    {
        if (lavaCollider != null)
        {
            lavaCollider.enabled = false;
        }
    }
}
