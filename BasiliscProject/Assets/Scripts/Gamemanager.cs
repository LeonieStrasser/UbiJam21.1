using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance { get => instance; }

    public PlayerInput playerInput = null;

    public GameObject rightEnemyPrefab;
    public GameObject leftEnemyPrefab;
    public float respawnMinTime = 1f;
    public float respawnMaxTime = 2f;

    private Vector2 screenBounds;

    // Enemy Start Vectoren
    public Vector2 leftSpawnpoint;
    public Vector2 rightSpawnpoint;

    // Adjustable hight
    //[Range(1f, 100f)]
    public int enemyHight = 10;


    // Gamestate
    public bool gameOver;
    public float gameOverDelayTime = 0.5f;



    // UI
    public GameObject gameOverscreen;
    public GameObject WinScreen;
    public GameObject ChainUI;

    // Collision with Enemy
    public bool collisionAktive;


    // Animation
    public Animator playerAnimator;

    //Audio
    private AudioManager audioManager;
    public string Soundname_Music;
    public string Soundname_MusicIntro;
    public string Soundname_enemyHit;
    public string Soundname_Hit;
    public string Soundname_punch;
    public string Soundname_damage;
    public string Soundname_loose;
    public string Soundname_StartGame;



    // Enemy Wave
    private int enemycount;

    [HideInInspector]
    public int killedEnemys;

    [HideInInspector]
    public float currentSpeed = 5;

    public WaveData[] waves;

    private int waveIndex = -1;


    private bool waveOver = true;
    public bool WaveOver { get => this.waveOver; set => this.waveOver = value; }

    [HideInInspector]
    public int maxEntitiesCount = 0;



    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        audioManager = AudioManager.instance;
        if( audioManager == null)
        {
            Debug.LogError("No AudioManager in the scene!");
        }
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //AudioManager.instance.PlaySound(Soundname_Music);
        StartWave();
        gameOver = false;
        collisionAktive = false;

       
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void StartWave()
    {
        if (!waveOver)
        {
            return;
        }

        waveIndex++;

        if (waveIndex >= waves.Length)
        {
            // WIn UI anzeigen
            WinScreen.SetActive(true);
        }
        else
        {
            Debug.Log("Wave: " + waveIndex);
           // AudioManager.instance.PlaySound(Soundname_StartGame);
            StartCoroutine(SpawnWave());
        }
    }


    IEnumerator SpawnWave()
    {
        waveOver = false;
        enemycount = 0;
        killedEnemys = 0;


        maxEntitiesCount = waves[waveIndex].nrOfEnemys;
        currentSpeed = waves[waveIndex].speed;

        respawnMinTime = waves[waveIndex].respawnMinTime;
        respawnMaxTime = waves[waveIndex].respawnMinTime + waves[waveIndex].respawnRange;

        while (enemycount < waves[waveIndex].nrOfEnemys)
        {
            yield return new WaitForSeconds(Random.Range(respawnMinTime, respawnMaxTime));
            if (Random.Range(0, 2) == 0)
            {
                SpawnRightEnemy();
            }
            else
            {
                SpawnLeftEnemy();
            }


        }
        yield return new WaitForSeconds(waves[waveIndex].waitForNextWave);
          
    }

    public void SpawnLeftEnemy()
    {
        leftSpawnpoint = new Vector2(screenBounds.x * -2, -screenBounds.y / enemyHight);

        GameObject left = Instantiate(leftEnemyPrefab, leftSpawnpoint, Quaternion.identity);
        left.GetComponent<EnemyMovement>().Init(currentSpeed);

        enemycount++;
    }

    public void SpawnRightEnemy()
    {
        rightSpawnpoint = new Vector2(-screenBounds.x * -2, -screenBounds.y / enemyHight);

        GameObject right = Instantiate(rightEnemyPrefab, rightSpawnpoint, Quaternion.identity);
        right.GetComponent<EnemyMovement>().Init(-currentSpeed);

        enemycount++;
    }

    public void GameIsOver()
    {
        gameOver = true;
        AudioManager.instance.PlaySound(GameManager.instance.Soundname_loose);
        StartCoroutine(GameOverDelay());

    }

    public void LostAllChains()
    {
        ChainUI.SetActive(true);
        PauseGame();
    }

    public void GameOverScreenOn()
    {
        gameOverscreen.SetActive(true);
        PauseGame();
    }



    void PauseGame()
    {
        Time.timeScale = 0;
    }



    IEnumerator GameOverDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(gameOverDelayTime);
            GameOverScreenOn();
        }

    }

    public void OnUnitSpawn(EnemyDestroy unit)
    {
        playerInput.AddUnit(unit);
    }
}
