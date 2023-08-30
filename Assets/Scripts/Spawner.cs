using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private TextMeshProUGUI currentStageText;
    [SerializeField] private TextMeshProUGUI pressHereText;
    [SerializeField] private GameObject bossPrefabs;
    public static UnityEvent onEnemyDestroy = new UnityEvent();
    public playerStats player;
    public Cameras cam;
    public Transform fightSpawn;
    public Transform shopSpawn;
    public Transform bossfightSpawn;
    public Transform bossSpawn;

    public int currentWave = 0;
    public int currentStage = 0;
    public bool isShopClear = false;

    public int enemiesAlive;

    private void Awake()
    {
        onEnemyDestroy.AddListener(enemyDestroyed);
    }
    private void Update()
    {
        currentStageText.text = currentStage.ToString();
    }
    private void enemyDestroyed()
    {
        enemiesAlive--;
    }

    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        while (true)
        {
            yield return new WaitUntil(() => enemiesAlive == 0 && (currentStage != 0 || isShopClear) && (currentStage != 3 || isShopClear) && (currentStage != 6 || isShopClear));
            yield return new WaitForSeconds(3);

            if ((currentStage == 0 && isShopClear) || (currentStage == 3 && isShopClear) || (currentStage == 6 && isShopClear))
            {
                isShopClear = false;
                currentStage++;
            }
            else if (currentStage != 0 && currentStage != 3 && currentStage != 6)
            {
                currentStage++;
            }

            yield return StartCoroutine(SpawnBasedOnStage());
        }
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
                pressHereText.enabled = true;
                cam.shopCam.enabled = true;
                cam.mainCam.enabled = false;
                player.gameObject.transform.position = shopSpawn.transform.position;
                break;
            case 1:
                pressHereText.enabled = false;
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
                pressHereText.enabled = false;
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
                pressHereText.enabled = false;
                player.gameObject.transform.position = bossfightSpawn.transform.position;
                Instantiate(bossPrefabs, bossSpawn.position, Quaternion.identity);
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

    public void OnShopClear()
    {
        isShopClear = true;
    }
}