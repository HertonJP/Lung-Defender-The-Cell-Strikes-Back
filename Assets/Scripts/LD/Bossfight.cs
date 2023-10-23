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
    [SerializeField] private GameObject youWinPanel;
    [SerializeField] private AudioSource youWinSFX;
    private Transform phase2Position;
    private Animator anim;
    private Collider2D coll;
    
    private void Start()
    {
        coll = GetComponent<Collider2D>();
        youWinPanel.SetActive(false);
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
        if(enemy.enemyHP <= 0)
        {
            youWinSFX.Play();
            youWinPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        if (enemy != null && !isPhase2 && enemy.enemyHP <= enemy.initialEnemyHP / 2)
        {
            enemy.transform.position = phase2Position.position;
            isPhase2 = true;
            coll.enabled = false;
            StartPhase2();
            Invoke("collActive", 1.5f);
        }
    }


    private void collActive()
    {
        coll.enabled = true;
    }
    private void StartPhase2()
    {
        StartCoroutine(SpawnLavaAtPlayer());
    }

    private IEnumerator SpawnLavaAtPlayer()
    {
        while (isPhase2)
        {
            GameObject lavaInstance = Instantiate(lavaPrefab, player.transform.position, Quaternion.identity);
            Destroy(lavaInstance, 3f);
            yield return new WaitForSeconds(4f);
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