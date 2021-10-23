using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
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

    // Collision with Enemy
    public bool collisionAktive;


    // Enemy Wave
    public int enemycount;
    public int killedEnemys;
    public float currentSpeed = 5;
    //------Wave 1
    public int nrOfEnemys1 = 20;
    public bool wave1Over = false;
    public float speed1;
    public float respawnMinTime1;
    public float respawnRange1;


    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        WaveController();
        gameOver = false;
        collisionAktive = false;
        enemycount = 0;
        killedEnemys = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public void WaveController()
    {
        if(wave1Over == false)
        {
            // 1. Welle starten
            Wave1();
        }else if (wave1Over == true)
        {
            // WIn UI anzeigen
            WinScreen.SetActive(true);
        }
    }
    void Wave1 ()
    {
        
        if(wave1Over == false)
        {
            StartCoroutine(EnemyWave1());

        }
        
    }

    IEnumerator EnemyWave1()
    {
        while (enemycount <= nrOfEnemys1)
        {
            currentSpeed = speed1;

            respawnMinTime = respawnMinTime1;
            respawnMaxTime = respawnMinTime1 + respawnRange1;


            yield return new WaitForSeconds(Random.Range(respawnMinTime, respawnMaxTime));
            SpawnRightEnemy();
            yield return new WaitForSeconds(Random.Range(respawnMinTime, respawnMaxTime));
            SpawnLeftEnemy();


        }


    }

    public void SpawnLeftEnemy()
    {
        leftSpawnpoint = new Vector2(screenBounds.x * -2, -screenBounds.y/enemyHight);

        GameObject a = Instantiate(leftEnemyPrefab) as GameObject;
        leftEnemyPrefab.transform.position = leftSpawnpoint;

        enemycount++;
    }

    public void SpawnRightEnemy()
    {
        rightSpawnpoint = new Vector2(-screenBounds.x * -2, -screenBounds.y/enemyHight);

        GameObject right = Instantiate(rightEnemyPrefab) as GameObject;
        right.transform.position = rightSpawnpoint;

        enemycount++;
    }

    public void GameIsOver()
    {
        gameOver = true;       
        StartCoroutine(GameOverDelay());
        
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


}
