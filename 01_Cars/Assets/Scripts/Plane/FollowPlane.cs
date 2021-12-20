using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlane : MonoBehaviour
{
    public GameObject planeToFollow;
    public Vector3 destination;
    Vector3 playerPreviousPos = Vector3.zero;
    public float distance = 20f;
    Vector3 velocity = Vector3.zero;
    public float smoothDamp = 0.3f;
    public Vector3 cinematicOffset = new Vector3(30, 15, 0);
    public bool cinematic = true;

    // Start is called before the first frame update
    void Start()
    {
        if (cinematic)
        {
            this.transform.Rotate(15, -90, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        if (cinematic)
        {
            Vector3 destination = planeToFollow.transform.position + cinematicOffset;
            this.transform.position = destination;
        }
        else
        {
            Vector3 offset = planeToFollow.transform.position - playerPreviousPos;
            if (offset.magnitude < 0.3f)
            { return; }
            offset.Normalize();
            Vector3 a = planeToFollow.transform.position - offset * distance;
            Vector3 destination = new Vector3(a.x, a.y + 15, a.z);
            this.transform.position = Vector3.SmoothDamp(this.transform.position, destination, ref velocity, smoothDamp); ;
            transform.LookAt(planeToFollow.transform.position);
            playerPreviousPos = planeToFollow.transform.position;
        }




    }

}
