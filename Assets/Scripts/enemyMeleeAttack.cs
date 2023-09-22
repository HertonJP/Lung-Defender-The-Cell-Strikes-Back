using UnityEngine;
public class enemyMeleeAttack : MonoBehaviour
{
    [SerializeField] private Collider2D hitbox;
    [SerializeField] private float knockbackForce;
    [SerializeField] private AudioSource attackSFX;
  

    public Enemy enemy;

    private void Start()
    {
        attackSFX = GetComponent<AudioSource>();
        hitbox.enabled = false;
    }

    public void EnableHitbox()
    {
        hitbox.enabled = true;
        CheckColliders(hitbox);
    }

    public void DisableHitbox()
    {
        hitbox.enabled = false;
    }

    public void enemyAttackSFX()
    {
        attackSFX.Play();
    }

    private void CheckColliders(Collider2D hitboxCollider)
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(hitboxCollider.transform.position, hitboxCollider.bounds.size, 0f);
        foreach (Collider2D collider in colliders)
        {
            playerStats player = collider.GetComponent<playerStats>();
            if (player != null && !player.isImmune)
            {
                int damage = enemy.enemyDamagePoints;
                player.TakeDamage(damage);

            }
        }
    }
}