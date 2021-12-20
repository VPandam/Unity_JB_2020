using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float movementSpeed = 20;
    public float rotationSpeed = 20;
    public float horizontal, vertical, accelerate;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        accelerate = Input.GetAxis("Fire1");

        if (accelerate > 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        }

        transform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime * rotationSpeed * vertical);
        transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotationSpeed * horizontal);
        //transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotationSpeed * horizontal);



        transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * rotationSpeed * horizontal);


        if (transform.rotation.eulerAngles.z < 325 && transform.rotation.eulerAngles.z > 320)
        {
            transform.eulerAngles = new Vector3(this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y, 325.001f);
        }
        if (transform.rotation.eulerAngles.z > 35 && transform.rotation.eulerAngles.z < 40)
        {
            transform.eulerAngles = new Vector3(this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y, 34.999f);
        }

    }
}
