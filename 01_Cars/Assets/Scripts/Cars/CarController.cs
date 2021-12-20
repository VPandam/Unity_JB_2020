using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float movementSpeed = 20f;
    public float rotationSpeed = 50f;
    private float vertical, horizontal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        this.transform.Translate(Time.deltaTime * movementSpeed * Vector3.forward * vertical);


        if (vertical < 0)
        {
            this.transform.Rotate(Time.deltaTime * rotationSpeed * new Vector3(0, 1) * -horizontal);

        }
        else
        {
            this.transform.Rotate(Time.deltaTime * rotationSpeed * new Vector3(0, 1) * horizontal);
        }

    }

}
