using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float movementForce;

    GameObject focalPoint;

    Rigidbody _playerRb;

    float verticalInput;
    // Start is called before the first frame update
    void Awake()
    {
        focalPoint = GameObject.Find("Focal point");
        _playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        _playerRb.AddForce(focalPoint.transform.forward * movementForce * verticalInput, ForceMode.Force);
    }
}
