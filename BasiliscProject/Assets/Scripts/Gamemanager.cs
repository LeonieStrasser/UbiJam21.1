using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public GameObject rightEnemyPrefab;
    public GameObject leftEnemyPrefab;
    public float respawntime = 1f;

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



    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(EnemyWave());
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnLeftEnemy()
    {
        leftSpawnpoint = new Vector2(screenBounds.x * -2, -screenBounds.y/enemyHight);

        GameObject a = Instantiate(leftEnemyPrefab) as GameObject;
        leftEnemyPrefab.transform.position = leftSpawnpoint;
    }

    public void SpawnRightEnemy()
    {
        rightSpawnpoint = new Vector2(-screenBounds.x * -2, -screenBounds.y/enemyHight);

        GameObject right = Instantiate(rightEnemyPrefab) as GameObject;
        right.transform.position = rightSpawnpoint;
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

    IEnumerator EnemyWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawntime);
            SpawnRightEnemy();
            SpawnLeftEnemy();
        }
        
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
