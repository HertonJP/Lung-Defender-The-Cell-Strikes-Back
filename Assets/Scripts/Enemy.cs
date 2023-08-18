using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private GameObject projectilesPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] private GameObject hitVFXPrefab;
    public int enemyHP;
    private bool isDead = false;

    [SerializeField] private float targetingRange = 3f;
    [SerializeField] public float initialAttackSpeed = 1f;
    [SerializeField] public int initialEnemyHP = 20;
    [SerializeField] public int enemyDamagePoints = 5;
    public float attackSpeed;

    private Animator anim;
    private Transform target;
    private float timeUntilFire;

    private bool isShowingText = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        enemyHP = initialEnemyHP;
        attackSpeed = initialAttackSpeed;
    }

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
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
            timeUntilFire = 0f;
        }
    }

    private bool inRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
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
        if (enemyHP <= 0 && !isDead)
        {
            isDead = true;
            Die();
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
    private void Die()
    {
        isShowingText = true;

        float destroyDelay = 0.5f;
        StartCoroutine(DestroyWithDelay(destroyDelay));

        int xpToGrant = 5;
        playerStats player = FindObjectOfType<playerStats>();
        if (player != null)
        {
            player.GainXP(xpToGrant);
        }
    }
}