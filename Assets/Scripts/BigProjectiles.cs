using System.Collections;
using UnityEngine;

public class BigProjectiles : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Vector2 initialDirection;
    [SerializeField] private float projectilesSpeed = 5f;

    [Header("Spread Settings")]
    [SerializeField] private GameObject smallProjectilePrefab;
    [SerializeField] private int numProjectiles = 5;
    [SerializeField] private float spreadAngle = 60f;
    [SerializeField] private float offsetDistance = 1f;

    private void FixedUpdate()
    {
        rb.velocity = initialDirection * projectilesSpeed;
    }

    public void SetInitialDirection(Vector2 direction)
    {
        initialDirection = direction.normalized;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       
        StartCoroutine(SpawnAndDestroy());
    }

    private IEnumerator SpawnAndDestroy()
    {
        SpawnSmallProjectiles();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private void SpawnSmallProjectiles()
    {
        float angleStep = spreadAngle / numProjectiles;

        for (int i = 0; i < numProjectiles; i++)
        {
            float angle = i * angleStep;
            Vector2 direction = new Vector2(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle));
            Vector2 shootingPosition = (Vector2)transform.position + (direction * offsetDistance);

            GameObject smallProjectile = Instantiate(smallProjectilePrefab, shootingPosition, Quaternion.identity);
            Rigidbody2D rbSmall = smallProjectile.GetComponent<Rigidbody2D>();
            rbSmall.velocity = direction * projectilesSpeed;
        }
    }
}