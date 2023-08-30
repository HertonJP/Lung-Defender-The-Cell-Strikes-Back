using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    public static UnityEvent onEnemyDestroy = new UnityEvent();
    public playerStats player;
    public Cameras cam;
    public Transform fightSpawn;
    public Transform shopSpawn;
    public Transform bossfightSpawn;

    public int currentWave = 0;
    public int currentStage = 0;
    public bool isShopClear = false;

    public int enemiesAlive;
    private bool isSpawning = false;

    private void Awake()
    {
        onEnemyDestroy.AddListener(enemyDestroyed);
    }

    private void enemyDestroyed()
    {
        enemiesAlive--;
    }

    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!isSpawning)
        {
            return;
        }
        StartCoroutine(SpawnBasedOnStage());
        isSpawning = false;
    }

    private IEnumerator SpawnBasedOnStage()
    {
        int enemiesToSpawn = 0;
        int[] indicesToUse = new int[0];

        switch (currentStage)
        {
            case 0:
            case 3:
            case 6:
                cam.shopCam.enabled = true;
                cam.mainCam.enabled = false;
                player.gameObject.transform.position = shopSpawn.transform.position;
                if (!isShopClear)
                {
                    yield break;
                }
                isShopClear = false;
                currentStage++;
                break;
            case 1:
                player.gameObject.transform.position = fightSpawn.transform.position;
                cam.mainCam.enabled = true;
                cam.shopCam.enabled = false;
                enemiesToSpawn = 5;
                indicesToUse = new int[] { 0, 1 };
                break;
            case 2:
                enemiesToSpawn = 5;
                indicesToUse = new int[] { 1, 2 };
                break;
            case 4:
                player.gameObject.transform.position = fightSpawn.transform.position;
                cam.mainCam.enabled = true;
                cam.shopCam.enabled = false;
                enemiesToSpawn = 5;
                indicesToUse = new int[] { 1, 2, 3 };
                break;
            case 5:
                enemiesToSpawn = 5;
                indicesToUse = new int[] { 2, 3, 4 };
                break;
            case 7:
                yield break;
        }

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int randomIndex = indicesToUse[Random.Range(0, indicesToUse.Length)];
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemyPrefabs[randomIndex], randomSpawnPoint.position, Quaternion.identity);
            enemiesAlive++;
            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator StartWave()
    {
        yield return new WaitUntil(() => enemiesAlive == 0 && (currentStage != 0 || isShopClear) && (currentStage != 3 || isShopClear) && (currentStage != 6 || isShopClear));
        yield return new WaitForSeconds(3);

        if ((currentStage == 0 && isShopClear) || (currentStage == 3 && isShopClear) || (currentStage == 6 && isShopClear))
        {
            currentStage++;
            isShopClear = false;
        }
        else if (currentStage != 0 && currentStage != 3 && currentStage != 6 && enemiesAlive == 0)
        {
            currentStage++;
        }
        isSpawning = true;
        StopCoroutine(StartWave());
        StartCoroutine(StartWave());
    }

    public void OnShopClear()
    {
        isShopClear = true;
    }
}