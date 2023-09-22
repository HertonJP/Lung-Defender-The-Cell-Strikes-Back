using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundBreak : MonoBehaviour
{
    public playerStats player;
    [SerializeField] private int gbDamage = 10;

    private Collider2D gbCollider;

    private void Start()
    {
        gbCollider = GetComponent<Collider2D>();
        gbCollider.enabled = false; 
        player = FindObjectOfType<playerStats>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && !player.isImmune)
        {
            player.TakeDamage(gbDamage);
        }
    }

    public void EnableCollider()
    {
        if (gbCollider != null)
        {
            gbCollider.enabled = true;
        }
    }

    public void DisableCollider()
    {
        if (gbCollider != null)
        {
            gbCollider.enabled = false;
        }
    }
}





