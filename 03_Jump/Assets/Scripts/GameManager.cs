using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameMode
{
    inGame, gameOver
}
public class GameManager : MonoBehaviour
{
    public GameObject spawnPosition;
    public GameObject[] obstacles;

    const string SPEED_F = "Speed_f";


    Animator playerAnimator;

    public GameMode currentGameState;
    public static GameManager sharedInstance;

    public float obstaclesSpeed, bgSpeed;

    void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();


    }
    // Start is called before the first frame update
    void Start()
    {


        currentGameState = GameMode.inGame;
        InvokeRepeating("InstantiateObstacle", 1f, Random.Range(1.5f, 3.5f));
        InvokeRepeating("IncreaseSpeed", 1f, 1f);


    }

    // Update is called once per frame
    void Update()
    {
        if (currentGameState == GameMode.gameOver)
        {
            CancelInvoke("InstantiateObstacle");
            CancelInvoke("IncreaseSpeed");
            Invoke("RestartGame", 3);
        }
    }

    void InstantiateObstacle()
    {
        int obstacleType = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[obstacleType], spawnPosition.transform.position, obstacles[obstacleType].transform.rotation);
    }

    void RestartGame()
    {
        SceneManager.LoadScene("Prototype 3");
    }

    void IncreaseSpeed()
    {
        obstaclesSpeed += 0.1f;
        bgSpeed += 0.1f;
        playerAnimator.SetFloat(SPEED_F, playerAnimator.GetFloat(SPEED_F) + 0.05f);
    }
}
