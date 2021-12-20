using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    BoxCollider obstacleCollider;
    // Start is called before the first frame update
    void Awake()
    {
        obstacleCollider = GetComponentInChildren<BoxCollider>();
    }


    // Update is called once per frame
    void Update()
    {

        if (GameManager.sharedInstance.currentGameState == GameMode.inGame)
        {
            this.transform.Translate(new Vector3(-1, 0, 0) * GameManager.sharedInstance.obstaclesSpeed * Time.deltaTime);
        }
        else
        {
            obstacleCollider.material = null;
        }

    }


}
