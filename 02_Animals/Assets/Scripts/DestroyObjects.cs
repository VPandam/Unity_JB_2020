using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    float zMax;
    float zMin;
    GameObject globals;
    Globals globalsScript;
    Hashtable maxCoordinates;
    // Start is called before the first frame update
    void Awake()

    {

        globals = GameObject.Find("Globals");
        globalsScript = globals.GetComponent<Globals>();

    }
    private void Start()
    {
        Debug.Log("zmaX: " + globalsScript.zMax + "zmin: " + globalsScript.zMin);



    }
    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z > globalsScript.zMax || this.transform.position.z < globalsScript.zMin ||
            this.transform.position.x > globalsScript.xMax || this.transform.position.x < globalsScript.xMin)
        {
            Destroy(gameObject);
        }
    }
}
