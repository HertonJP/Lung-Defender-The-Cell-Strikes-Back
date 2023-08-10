using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private GameObject projectilesPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] public int initialEnemyHP = 20;
    [SerializeField] private GameObject floatingTextPrefab;
    public int enemyHP;
    private bool isDead = false;
    //private Animator animator;

    [SerializeField] private float targetingRange = 3f;
    [SerializeField] public float initialAttackSpeed = 1f;
    public float attackSpeed;


    private Transform target;
    private float timeUntilFire;

    private void Start()
    {
       // animator = GetComponent<Animator>();
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
        //animator.SetBool("inRange", distanceToTarget <= targetingRange);

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
            //animator.SetTrigger("isAttack");
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
            ShowFloatingText(damage.ToString());
        }
    }
    private void Die()
    {
        // animasi mati

        Destroy(gameObject);
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
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, targetingRange);
    }
}