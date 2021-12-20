using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GameState { inGame, gameOver }

public class GameManager : MonoBehaviour
{
    float borderX = 8.5f;
    float borderZ = 8.5f;

    public GameObject[] powerUps;
    public GameObject enemy;

    int wave = 1;

    GameState currentGameState = GameState.inGame;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(1);
        StartCoroutine(CheckEnemiesAlive());
        StartCoroutine(SpawnPowerUps());
    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector3 generateSpawnPos()
    {
        float randomX = Random.Range(-borderX, borderX);
        float randomZ = Random.Range(-borderZ, borderZ);
        return new Vector3(randomX, 0, randomZ);
    }
    /// <summary>
    /// Spawn X enemies each time they all die. X increases 1 each time a new wave is spawned. The Coroutine checks for enemies every 1 second. 
    /// </summary>
    IEnumerator SpawnPowerUps()
    {
        while (currentGameState == GameState.inGame)
        {
            yield return new WaitForSeconds(Random.Range(5, 6));
            SpawnPowerUpM();
        }
    }
    void SpawnPowerUpM()
    {

        Instantiate(powerUps[Random.Range(0, powerUps.Length)], generateSpawnPos(), enemy.transform.rotation);
    }
    IEnumerator CheckEnemiesAlive()
    {
        while (currentGameState == GameState.inGame)
        {
            yield return new WaitForSeconds(1);
            if (!CheckEnemiesAliveM())
            {
                wave++;
                SpawnEnemies(wave);
            }
        }
    }

    bool CheckEnemiesAliveM()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
            return true;
        else
            return false;
    }

    void SpawnEnemies(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
            Instantiate(enemy, generateSpawnPos(), enemy.transform.rotation);
    }






}
