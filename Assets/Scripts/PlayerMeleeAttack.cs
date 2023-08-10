using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] private Collider2D hitbox1;
    [SerializeField] private Collider2D hitbox2;
    public int attackDamage = 10;

    private void Start()
    {
        hitbox1.enabled = false;
        hitbox2.enabled = false;
    }

    public void EnableHitbox(int hitboxIndex)
    {
        if (hitboxIndex == 1)
        {
            hitbox1.enabled = true;
        }
        else if (hitboxIndex == 2)
        {
            hitbox2.enabled = true;
        }
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, hitbox1.bounds.size, 0f);
        foreach (Collider2D collider in colliders)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(attackDamage);
            }
        }
    }

    public void DisableHitbox(int hitboxIndex)
    {
        if (hitboxIndex == 1)
        {
            hitbox1.enabled = false;
        }
        else if (hitboxIndex == 2)
        {
            hitbox2.enabled = false;
        }
    }

    
}