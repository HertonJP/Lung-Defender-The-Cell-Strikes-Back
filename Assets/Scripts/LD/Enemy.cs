using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private GameObject projectilesPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] private GameObject floatingTextCrit;
    [SerializeField] private GameObject hitVFXPrefab;
    [SerializeField] private GameObject attackRange;
    [SerializeField] private int xpToGrant = 5;
    [SerializeField] public bool isBoss = false;
    public int enemyHP;
    private bool isDead = false;
    private Transform phase2Position;
    [SerializeField] private float targetingRange = 3f;
    [SerializeField] public float initialAttackSpeed = 1f;
    [SerializeField] public int initialEnemyHP;
    [SerializeField] public int enemyDamagePoints;
    [SerializeField] private string phase2Tag = "Phase2Position";
    public float attackSpeed;

    private Animator anim;
    private Collider2D coll;
    public Transform target;
    private float timeUntilFire;
    private bool isAttacking = false;
    private bool isShowingText = false;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        enemyHP = initialEnemyHP;
        attackSpeed = initialAttackSpeed;
        GameObject phase2Object = GameObject.FindWithTag(phase2Tag);
        if (phase2Object != null)
        {
            phase2Position = phase2Object.transform;
        }
    }

    private void Update()
    {
        if(isBoss && enemyHP <= initialEnemyHP / 2)
        {
            anim.SetTrigger("isLavaTime");
            
        }
        if (target == null)
        {
            if(isBoss && enemyHP <= initialEnemyHP / 2)
            {
                target = phase2Position;
            }
            else
            {
                FindTarget();
                return;
            }
        }
        float distanceToTarget = Vector2.Distance(target.position, transform.position);
        if (!inRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;
        }
        if (timeUntilFire >= 1f / attackSpeed)
        {
            StartAttack();
            timeUntilFire = 0f;
        }
    }

    public void RangeAttack()
    {
        Debug.Log("range attack kepanggil");
        if (target == null)
        {
            return;
        }
        GameObject projectilesObj = Instantiate(projectilesPrefab, firingPoint.position, Quaternion.identity);

        Vector2 directionToPlayer = target.transform.position - firingPoint.position;

        enemyProjectiles projectilesScript = projectilesObj.GetComponent<enemyProjectiles>();
        projectilesScript.SetInitialDirection(directionToPlayer);
    }
    public bool inRange()
    {
        if (target == null || attackRange == null)
        {
            return false;
        }
        return Vector2.Distance(target.position, attackRange.transform.position) <= targetingRange;
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, playerMask);
        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    public void TakeDamage(int damage)
    {
        enemyHP -= damage;
        playerStats player = FindObjectOfType<playerStats>();    
        if (enemyHP <= 0 && !isBoss)
        {
            ShowFloatingText(damage.ToString());
            PlayHitVFX();
            enemyHP = 0;
            isDead = true;
            Die();
        }
        if(enemyHP <= 0 && isBoss)
        {
            ShowFloatingText(damage.ToString());
            PlayHitVFX();
            enemyHP = 0;
            isDead = true;
            BossDie();
        }
        else
        {
            
            if (anim != null)
            {
                anim.SetTrigger("isHit");
            }
            
          
            ShowFloatingText(damage.ToString());
            
            PlayHitVFX();
        }
    }

    private void PlayHitVFX()
    {
        if (hitVFXPrefab != null)
        {
            GameObject hitVFXObject = Instantiate(hitVFXPrefab, transform.position, Quaternion.identity);
            Destroy(hitVFXObject, 0.3f);
        }
    }

    private IEnumerator DestroyWithDelay(float delay)
    {
        if (isShowingText)
        {
            yield return new WaitForSeconds(delay);
            Destroy(gameObject);
        }
    }

    private void ShowFloatingText(string text)
    {
        if (floatingTextPrefab != null)
        {
            GameObject floatingText = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            FloatingTextController textController = floatingText.GetComponent<FloatingTextController>();
            if (textController != null)
            {
                textController.Init(text);
            }
        }
    }

    private void ShowFloatingTextCrit(string text)
    {
        if (floatingTextCrit != null)
        {
            GameObject floatingTextCrot = Instantiate(floatingTextCrit, transform.position, Quaternion.identity);
            FloatingTextController textController = floatingTextCrit.GetComponent<FloatingTextController>();
            if (textController != null)
            {
                textController.Init(text);
            }
        }
    }
    public void StartAttack()
    {
        if (isDead) return;
        anim.SetBool("isAttacking", true);
        anim.SetTrigger("isAttack");
    }

    public void EndAttack()
    {
        if (isDead) return;
        anim.SetBool("isAttacking", false);
    }
    private void StopAttackingAndFollowing()
    {
        isDead = true;
        target = null;

        AI aiComponent = GetComponent<AI>();
        if (aiComponent != null)
        {
            aiComponent.enabled = false;
        }
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    private void BossDie()
    {
        coll.enabled = false;
        StopAttackingAndFollowing();
        anim.SetTrigger("isDead");
        Debug.Log("mati");
        isShowingText = true;

        float destroyDelay = 3.4f;
        StartCoroutine(DestroyWithDelay(destroyDelay));
        playerStats player = FindObjectOfType<playerStats>();
        if (player != null && player.playerLevel <= 14)
        {
            player.GainXP(xpToGrant);
        }
    }
    private void Die()
    {
        coll.enabled = false;
        StopAttackingAndFollowing();
        anim.SetTrigger("isDead");
        Debug.Log("mati");
        isShowingText = true;

        float destroyDelay = 2.4f;
        StartCoroutine(DestroyWithDelay(destroyDelay));
        playerStats player = FindObjectOfType<playerStats>();
        if (player != null && player.playerLevel <= 14)
        {
            player.GainXP(xpToGrant);
        }
    }
    void OnDestroy()
    {
        Spawner.onEnemyDestroy.Invoke();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(attackRange.transform.position, targetingRange);
    }
}