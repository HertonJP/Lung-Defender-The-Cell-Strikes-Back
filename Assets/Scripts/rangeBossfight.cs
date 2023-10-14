using System.Collections;
using UnityEngine;

public class rangeBossfight : MonoBehaviour
{
    public Enemy enemy;
    [SerializeField] private smallProjectiles smallProjectileScript;
    public playerStats player;

    public bool isPhase2 = false;
    private Collider2D col;

    [Header("Small Projectile Settings")]
    [SerializeField] private GameObject smallProjectilePrefab;
    [SerializeField] private int numProjectiles = 12;
    [SerializeField] private float spreadAngle = 360f;
    [SerializeField] private float offsetDistance = 1f;
    [SerializeField] private float shootingSpeed = 5f;
    [SerializeField] private float shootInterval = 6f;

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

        StartCoroutine(ShootSmallProjectilesRepeatedly());
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
    }

    private void enablingCollider()
    {
        col.enabled = true;
    }

    private void StartPhase2()
    {
        //buat nanti
    }

    private void ShootMultiple()
    {
        float angleStep = spreadAngle / numProjectiles;

        for (int i = 0; i < numProjectiles; i++)
        {
            float angle = i * angleStep;
            Vector2 direction = new Vector2(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle)).normalized;
            Vector2 shootingPosition = (Vector2)transform.position + (direction * offsetDistance);

            GameObject projectile = Instantiate(smallProjectilePrefab, shootingPosition, Quaternion.identity);
            smallProjectileScript = projectile.GetComponent<smallProjectiles>();

            if (smallProjectileScript != null)
            {
                smallProjectileScript.SetInitialDirection(direction);
            }
        }
    }

    private IEnumerator ShootSmallProjectilesRepeatedly()
    {
        while (true)
        {
            if (isPhase2)
            {
                ShootMultiple();
            }

            yield return new WaitForSeconds(shootInterval);
        }
    }
}