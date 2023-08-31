using System.Collections;
using UnityEngine;

public class Bossfight : MonoBehaviour
{
    public Enemy enemy;
    public playerStats player;

    private bool isPhase2 = false;

    [SerializeField] private Transform gbPosition;
    [SerializeField] private GameObject groundBreak;
    [SerializeField] private GameObject dustVFXprefab;
    [SerializeField] private GameObject lavaPrefab;
    [SerializeField] private string phase2Tag = "Phase2Position";
    [SerializeField] private AudioSource groundSlam;
    private Transform phase2Position;
    private Animator anim;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<playerStats>();
        }

        GameObject phase2Object = GameObject.FindWithTag(phase2Tag);
        if (phase2Object != null)
        {
            phase2Position = phase2Object.transform;
        }
        StartCoroutine(HandleBossAttack());
    }

    private void Update()
    {
        if (enemy != null && !isPhase2 && enemy.enemyHP <= enemy.initialEnemyHP / 2)
        {
            isPhase2 = true;
            StartPhase2();
        }
    }

    private void StartPhase2()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        anim.SetTrigger("isLavaTime");
        if (phase2Position != null)
        {
            transform.position = phase2Position.position;
        }

        AI aiComponent = enemy.GetComponent<AI>();
        if (aiComponent != null)
        {
            aiComponent.enabled = false;
        }

        StartCoroutine(SpawnLavaAtPlayer());
    }

    private IEnumerator SpawnLavaAtPlayer()
    {
        while (isPhase2)
        {
            GameObject lavaInstance = Instantiate(lavaPrefab, player.transform.position, Quaternion.identity);
            Destroy(lavaInstance, 3f);
            yield return new WaitForSeconds(1.5f);
        }
    }

    private IEnumerator HandleBossAttack()
    {
        while (true)
        {
            if (enemy != null && enemy.inRange())
            {
                bossAttack();
            }
            yield return new WaitForSeconds(3f);
        }
    }

    public void bossAttack()
    {
        if (!isPhase2)
        {
            spawnGroundBreak();
        }
    }

    public void spawnGroundBreak()
    {
        groundSlam.Play();
        GameObject gBreak = Instantiate(groundBreak, gbPosition.position, Quaternion.identity);
        Destroy(gBreak, 2.0f);
        StartCoroutine(SpawnDustVFXAfterDelay(0.2f));
    }

    private IEnumerator SpawnDustVFXAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject dustVFX = Instantiate(dustVFXprefab, gbPosition.position, Quaternion.identity);
        Destroy(dustVFX, 2.0f);
    }
}