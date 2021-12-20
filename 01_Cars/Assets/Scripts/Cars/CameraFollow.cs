using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject toFollow;

    public float smoothDamp = 0.3f;
    private Vector3 velocity = Vector3.zero;


    public Vector3 offset = new Vector3(0, 5, -6);
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {

        //this.transform.position = destination;

        Vector3 destination = toFollow.transform.position + offset;
        this.transform.position = Vector3.SmoothDamp(this.transform.position, destination, ref velocity, smoothDamp);

    }
    private void FixedUpdate()
    {
    }
}
