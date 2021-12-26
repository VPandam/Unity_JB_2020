using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<Target> targets;
    public float spawnY = -2;
    float spawnX = 4;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTargets()
    {
        while (GameManager.sharedInstance.currentGameState == GameState.ingame)
        {

            yield return new WaitForSeconds(1);
            int targetIndex = Random.Range(0, targets.Count);
            Instantiate(targets[targetIndex],
            new Vector3(Random.Range(-spawnX, spawnX), spawnY, 0), targets[targetIndex].transform.rotation);
        }

    }
}
