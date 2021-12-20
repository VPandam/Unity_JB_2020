using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 16f;
    public float horizontalInput;
    public GameObject projectile;
    public float fireRate = 0.5f;
    public float nextShotTime;
    private void Awake()
    {
        Application.targetFrameRate = 60;

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (this.transform.position.x < -16)
        {
            this.transform.position = new Vector3(-16f, transform.position.y, transform.position.z);
        }
        if (this.transform.position.x > 16)
        {
            this.transform.position = new Vector3(16f, transform.position.y, transform.position.z);
        }
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if (Input.GetMouseButton(1))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Time.time >= nextShotTime)
        {
            Instantiate(projectile,
            new Vector3(this.transform.position.x, projectile.transform.position.y, this.transform.position.z),
            projectile.transform.rotation);
            nextShotTime = Time.time + fireRate;
        }
    }
}


