using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    Rigidbody _rb;
    public float movementForce;
    // Start is called before the first frame update

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.transform.position - this.transform.position).normalized;

        _rb.AddForce(direction * movementForce);

        if (this.transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }


    }
}
