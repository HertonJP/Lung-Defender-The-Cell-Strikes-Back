using UnityEngine;

public class rollout : MonoBehaviour
{
    public playerStats player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(player.playerMaxHP / 10);
            Debug.Log("kena rollout boss");
        }
    }
}