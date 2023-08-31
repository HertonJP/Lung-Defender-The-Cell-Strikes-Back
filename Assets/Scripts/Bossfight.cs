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

    private Transform phase2Position;

    private void Start()
    {
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
    }

    private void Update()
    {
        if (enemy != null && !isPhase2 && enemy.enemyHP <= enemy.initialEnemyHP / 3)
        {
            isPhase2 = true;
            StartPhase2();
        }
    }

    private void StartPhase2()
    {
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
            Destroy(lavaInstance, 2f);
            yield return new WaitForSeconds(1.5f);
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