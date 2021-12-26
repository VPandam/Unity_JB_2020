using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Target : MonoBehaviour
{
    Rigidbody _rb;
    ParticleSystem explosion;

    public float minForceUp, maxForceUp, minTorque, maxTorque;
    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        explosion = GetComponentInChildren<ParticleSystem>();
    }

    void Start()
    {

        AddForceUp();
        AddTorqueXYZ();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void AddForceUp()
    {
        _rb.AddForce(Vector3.up * Random.Range(minForceUp, maxForceUp), ForceMode.Impulse);
    }

    void AddTorqueXYZ()
    {
        _rb.AddTorque(Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque),
        Random.Range(minTorque, maxTorque),
        ForceMode.Impulse);

    }

    private void OnMouseDown()
    {
        // explosion.Play();
        ParticleSystem explos = Instantiate(explosion, this.transform.position, explosion.transform.rotation);
        explos.Play();
        Destroy(this.gameObject);

    }
}
