using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesSpread : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firingPoint;

    public float shootingSpeed = 10f;
    public float fire1Cooldown = 0.5f;
    private bool canShootFire1 = true;

    public float spreadAngle = 360f;
    public int numProjectiles = 16;
    public float offsetDistance = 1f;

    private AudioSource attackSFX;
    private PlayerAttributes playerAttributes;

    private void Start()
    {
        attackSFX = GetComponent<AudioSource>();
        playerAttributes = GetComponent<PlayerAttributes>();
    }

    private void Update()
    {
        if (!Time.timeScale.Equals(0f))
        {
            if (canShootFire1 && Input.GetButtonDown("Fire1"))
            {
                Shoot();
                attackSFX.Play();
                StartCoroutine(Fire1Cooldown());

                if (Input.GetKeyDown(KeyCode.Space) && playerAttributes.playerHP >= 50)
                {
                    TriggerSkillMultiple(3, 0.5f);
                    playerAttributes.playerHP -= 50;
                }
            }

        }



    }

    private void Shoot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector2 shootingDirection = (mousePosition - firingPoint.position).normalized;

        GameObject projectile = Instantiate(projectilePrefab, firingPoint.position, Quaternion.identity);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        rb.velocity = shootingDirection * shootingSpeed;
    }

    private void TriggerSkillMultiple(int numTimes, float delay)
    {
        StartCoroutine(ShootMultipleTimes(numTimes, delay));
    }

    private IEnumerator ShootMultipleTimes(int numTimes, float delay)
    {
        for (int i = 0; i < numTimes; i++)
        {
            ShootMultiple();
            yield return new WaitForSeconds(delay);
        }
    }

    private void ShootMultiple()
    {
        float angleStep = spreadAngle / numProjectiles;

        for (int i = 0; i < numProjectiles; i++)
        {
            float angle = i * angleStep;
            Vector2 direction = new Vector2(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle));
            Vector2 shootingPosition = (Vector2)transform.position + (direction * offsetDistance);

            GameObject projectile = Instantiate(projectilePrefab, shootingPosition, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction * shootingSpeed;
        }
    }

    private IEnumerator Fire1Cooldown()
    {
        canShootFire1 = false;
        yield return new WaitForSeconds(fire1Cooldown);
        canShootFire1 = true;
    }
}