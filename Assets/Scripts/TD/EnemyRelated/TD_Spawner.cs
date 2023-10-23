using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TD_Spawner : MonoBehaviour
{
    public static TD_Spawner main;
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("WavesData")]
    [SerializeField] private int baseEnemies = 3;
    [SerializeField] private float enemiesPerSecond = 1f;
    [SerializeField] private float timeBetweenWaves = 10f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;

    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;
    public int spawnPoint;
    [SerializeField] private int maxWave;

    private void Awake()
    {
        main = this;
        onEnemyDestroy.AddListener(enemyDestroyed);
    }


    private void enemyDestroyed()
    {
        enemiesAlive--;
    }

    private void Start()
    {
        if (LevelManager.main.spawnPoint > 1)
        {
            spawnPoint = Random.Range(0, LevelManager.main.spawnPoint);
        }
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!isSpawning)
        {
            return;
        }
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }
        if(enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;

        if (LevelManager.main.spawnPoint > 1)
        {
            spawnPoint = Random.Range(0, LevelManager.main.spawnPoint);
        }

        if (currentWave < maxWave)
        {
            StartCoroutine(StartWave());
        }
        else
        {
            LevelManager.main.victoryPanel.SetActive(true);
            GameManager.Instance.lastUnlockedTDLevel++;
            PlayerPrefs.SetInt(GameManager.Instance.lastTDLevelPlayerPrefs, GameManager.Instance.lastUnlockedTDLevel);
        }
    }

    private void SpawnEnemy()
    {
        int index = Random.Range(0, enemyPrefabs.Length);
        GameObject prefabToSpawn = enemyPrefabs[index];
        if (spawnPoint == 0)
        {
            Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
        }
        else
        {
            Instantiate(prefabToSpawn, LevelManager.main.startPoint2.position, Quaternion.identity);
        }
        
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }
}