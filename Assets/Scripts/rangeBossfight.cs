using System.Collections;
using UnityEngine;

public class rangeBossfight : MonoBehaviour
{
    public Enemy enemy;
    public playerStats player;

    public bool isPhase2 = false;
    private float bigProjectileTimer = 0f;
    private bool canShootBigProjectile = true;
    private Collider2D col;

    [SerializeField] private GameObject bigProjectilePrefab;

    private void Start()
    {
        col = gameObject.GetComponent<Collider2D>();
        col.enabled = false;
        Invoke("enablingCollider", 1);
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<playerStats>();
        }
    }

    private void Update()
    {
        if (enemy.enemyHP <= 0)
        {
            Destroy(this.gameObject);
        }

        if (enemy != null && !isPhase2 && enemy.enemyHP <= enemy.initialEnemyHP / 2)
        {
            isPhase2 = true;
            StartPhase2();
        }

        if (isPhase2 && canShootBigProjectile)
        {
            bigProjectileTimer += Time.deltaTime;

            if (bigProjectileTimer >= 5f)
            {
                ShootBigProjectile();
                bigProjectileTimer = 0f;
                canShootBigProjectile = false;
                StartCoroutine(ResetBigProjectileCooldown());
            }
        }
    }

    private void enablingCollider()
    {
        col.enabled = true;
    }
    private void StartPhase2()
    {
    }


    private void ShootBigProjectile()
    {
        Instantiate(bigProjectilePrefab, transform.position, Quaternion.identity);
    }

    private IEnumerator ResetBigProjectileCooldown()
    {
        yield return new WaitForSeconds(5f);
        canShootBigProjectile = true;
    }
}