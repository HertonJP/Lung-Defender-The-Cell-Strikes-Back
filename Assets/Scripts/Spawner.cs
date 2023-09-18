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
    //[SerializeField] private GameObject bossPrefabs;
    [SerializeField] private AudioSource shopBGM;
    [SerializeField] private AudioSource fightBGM;
    [SerializeField] private AudioSource bossBGM;
    [SerializeField] private GameObject stageClearPanel;
    
    public static UnityEvent onEnemyDestroy = new UnityEvent();
    public playerStats player;
    public Cameras cam;
    public Transform fightSpawn;
    public Transform shopSpawn;
    public Transform bossfightSpawn;
    public Transform bossSpawn;
    public SoundEffects sfx;
    public GameObject bossObject;

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
        currentStage = 6;
        stageClearPanel.SetActive(false);
        shopBGM.Play();
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        while (true)
        {
            yield return new WaitUntil(() => enemiesAlive == 0 && (currentStage != 0 || isShopClear) && (currentStage != 3 || isShopClear) && (currentStage != 6 || isShopClear));
            yield return new WaitForSeconds(5);

            if ((currentStage == 0 && isShopClear) || (currentStage == 3 && isShopClear) || (currentStage == 6 && isShopClear) || (currentStage == 9 && isShopClear))
            {
                isShopClear = false;
                currentStage++;
            }
            else if (currentStage != 0 && currentStage != 3 && currentStage != 6)
            {
                stageClearPanel.SetActive(true);
                currentStage++;
                sfx.stageClearSFX.Play();
                yield return new WaitForSeconds(2);
                stageClearPanel.SetActive(false);
            }
            else if ( currentStage == 7 && bossObject == null)
            {
                currentStage++;
            }
            
                yield return StartCoroutine(SpawnBasedOnStage());
              
            
        }
    }

    private void playBossGrowl()
    {
        sfx.bossGrowlSound();
    }
    private IEnumerator SpawnBasedOnStage()
    {
        fightBGM.Stop();
        bossBGM.Stop();
        int enemiesToSpawn = 0;
        int[] indicesToUse = new int[0];

        switch (currentStage)
        {
            case 0:
            case 3:
            case 6:
            case 9:
                fightBGM.Stop();
                bossBGM.Stop();
                shopBGM.Play();
                pressHereText.enabled = true;
                cam.shopCam.enabled = true;
                cam.mainCam.enabled = false;
                player.gameObject.transform.position = shopSpawn.transform.position;
                player.playerHP = player.playerMaxHP;
                break;
            case 1:
                shopBGM.Stop();
                fightBGM.Play();
                pressHereText.enabled = false;
                player.gameObject.transform.position = fightSpawn.transform.position;
                cam.mainCam.enabled = true;
                cam.shopCam.enabled = false;
                enemiesToSpawn = 10;
                indicesToUse = new int[] { 0, 1 };
                break;
            case 2:
                fightBGM.Play();
                enemiesToSpawn = 8;
                indicesToUse = new int[] { 1, 2 };
                break;
            case 4:
                shopBGM.Stop();
                fightBGM.Play();
                pressHereText.enabled = false;
                player.gameObject.transform.position = fightSpawn.transform.position;
                cam.mainCam.enabled = true;
                cam.shopCam.enabled = false;
                enemiesToSpawn = 7;
                indicesToUse = new int[] { 2, 3 };
                break;
            case 5:
                fightBGM.Play();
                enemiesToSpawn = 4;
                indicesToUse = new int[] { 3, 4 };
                break;
            case 7:
                enemiesAlive = 1;
                cam.shopCam.enabled = false;
                cam.bossCam.enabled = true;
                fightBGM.Stop();
                shopBGM.Stop();              
                pressHereText.enabled = false;
                bossObject.SetActive(true);
                player.gameObject.transform.position = bossfightSpawn.transform.position;
                Invoke("playBossGrowl", 2.0f);
                bossBGM.Play();
                break;
            case 8:
                player.gameObject.transform.position = fightSpawn.transform.position;
                cam.bossCam.enabled = false;
                cam.mainCam.enabled = true;
                bossBGM.Stop();
                fightBGM.Play();
                pressHereText.enabled = false;
                enemiesToSpawn = 6;
                indicesToUse = new int[] {3, 4 };
                break;
            case 10:
                break;
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