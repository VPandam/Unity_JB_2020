using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState
{
    ingame, gameover
}
public class GameManager : MonoBehaviour
{

    public static GameManager sharedInstance;

    public GameState currentGameState;
    SpawnManager spawnManager;
    // Start is called before the first frame update
    void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        currentGameState = GameState.ingame;
        spawnManager.StartCoroutine("SpawnTargets");


    }

    private void Start()

    {


    }

    // Update is called once per frame
    void Update()
    {

    }
}
