using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private GameObject projectilesPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] private GameObject hitVFXPrefab;
    [SerializeField] private GameObject attackRange;
    public int enemyHP;
    private bool isDead = false;
    [SerializeField] private float targetingRange = 3f;
    [SerializeField] public float initialAttackSpeed = 1f;
    [SerializeField] public int initialEnemyHP = 20;
    [SerializeField] public int enemyDamagePoints = 5;
    public float attackSpeed;
    private Animator anim;
    private Transform target;
    private float attackCooldown;
    private bool isShowingText = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        enemyHP = initialEnemyHP;
        attackSpeed = initialAttackSpeed;
        attackCooldown = 0f;
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;

        if (target == null)
        {
            FindTarget();
            return;
        }

        if (!inRange())
        {
            target = null;
        }
        else if (inRange() && attackCooldown <= 0)
        {
            StartAttack();
            attackCooldown = 1f / attackSpeed;
        }
    }

    public void RangeAttack()
    {
        if (target == null) return;
        GameObject projectilesObj = Instantiate(projectilesPrefab, firingPoint.position, Quaternion.identity);
        Vector2 directionToPlayer = target.transform.position - firingPoint.position;
        enemyProjectiles projectilesScript = projectilesObj.GetComponent<enemyProjectiles>();
        projectilesScript.SetInitialDirection(directionToPlayer);
    }

    public bool inRange()
    {
        return Vector2.Distance(target.position, attackRange.transform.position) <= targetingRange;
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, Vector2.zero, 0f, playerMask);
        if (hits.Length > 0) target = hits[0].transform;
    }

    public void TakeDamage(int damage)
    {
        enemyHP -= damage;

        if (enemyHP <= 0 && !isDead)
        {
            isDead = true;
            Die();
        }
        else
        {
            anim.SetTrigger("isHit");
            ShowFloatingText(damage.ToString());
            PlayHitVFX();
        }
    }

    private void PlayHitVFX()
    {
        GameObject hitVFXObject = Instantiate(hitVFXPrefab, transform.position, Quaternion.identity);
        Destroy(hitVFXObject, 0.3f);
    }

    private IEnumerator DestroyWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    private void ShowFloatingText(string text)
    {
        GameObject floatingText = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
        FloatingTextController textController = floatingText.GetComponent<FloatingTextController>();
        textController.Init(text);
    }

    public void StartAttack()
    {
        anim.SetBool("isAttacking", true);
        anim.SetTrigger("isAttack");
    }

    public void EndAttack()
    {
        anim.SetBool("isAttacking", false);
    }

    private void Die()
    {
        anim.SetTrigger("isDead");
        StartCoroutine(DestroyWithDelay(2.4f));
        playerStats player = FindObjectOfType<playerStats>();
        if (player != null && player.playerLevel <= 4)
        {
            player.GainXP(5);
        }
    }
}