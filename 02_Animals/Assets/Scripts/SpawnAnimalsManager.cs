using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimalsManager : MonoBehaviour
{
    public GameObject[] animals;

    float xSpawn;
    float xMax, xMin;

    Globals globals;

    public float spawnTime = 1f;

    private void Awake()
    {
        GameObject globalsObject = GameObject.Find("Globals");
        globals = globalsObject.GetComponent<Globals>();
        xMax = globals.xMax;
        xMin = globals.xMin;
    }
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnAnimal", 0.5f, spawnTime);

    }

    // Update is called once per frame
    void Update()
    {


    }

    void SpawnAnimal()
    {
        xSpawn = Random.Range(xMin, xMax);
        GameObject AnimalToInstantiate = animals[Random.Range(0, animals.Length)];
        Instantiate(AnimalToInstantiate, new Vector3(xSpawn,
            AnimalToInstantiate.transform.position.y, globals.zMax + -0.5f),
            AnimalToInstantiate.transform.rotation);
    }
}
