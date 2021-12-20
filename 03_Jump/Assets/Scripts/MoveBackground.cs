using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{


    Vector3 initialPos;
    BoxCollider collider;
    float wide;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = this.transform.position;
        collider = this.GetComponent<BoxCollider>();
        wide = collider.size.x / 2;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.sharedInstance.currentGameState == GameMode.inGame)
        {
            this.transform.Translate(Vector3.left * Time.deltaTime * GameManager.sharedInstance.bgSpeed);

            if (this.transform.position.x <= initialPos.x - wide)
            {
                this.transform.position = initialPos;
            }
        }



    }
}

