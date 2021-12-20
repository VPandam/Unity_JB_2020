using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public float bounceForce = 20;

    bool active = true;

    float timeToFinish = 10;

    public GameObject ring1, ring2, ring3;


    // Start is called before the first frame update

    private void Start()
    {
        ring1 = GameObject.FindGameObjectWithTag("Ring1");
        ring2 = GameObject.FindGameObjectWithTag("Ring2");
        ring3 = GameObject.FindGameObjectWithTag("Ring3");
        StartCoroutine(ActivateRingIndicator());
        StartCoroutine(DestroyAfterTime());


    }

    private void LateUpdate()
    {
        ring1.transform.position = this.gameObject.transform.position;

        ring2.transform.position = this.gameObject.transform.position;

        ring3.transform.position = this.gameObject.transform.position;

    }
    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(timeToFinish);
        Destroy(this);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 direction = (collision.transform.position - this.transform.position).normalized;
            enemyRigidBody.AddForce(direction * bounceForce, ForceMode.Impulse);
        }
    }
    IEnumerator ActivateRingIndicator()
    {

        ring1.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(timeToFinish / 3);
        ring1.GetComponent<MeshRenderer>().enabled = false;

        ring2.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(timeToFinish / 3);
        ring2.GetComponent<MeshRenderer>().enabled = false;

        ring3.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(timeToFinish / 3 - 0.1f);
        ring3.GetComponent<MeshRenderer>().enabled = false;



    }

}
