using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propellor : MonoBehaviour
{
    public float speed;
    public float accelerate;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        accelerate = Input.GetAxis("Fire1");
        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * speed * accelerate);
    }

}
