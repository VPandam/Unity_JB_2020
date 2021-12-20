using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    Color originalColor;
    int timeToFinish = 10;

    MeshRenderer mR;
    // Start is called before the first frame update
    void Start()
    {
        mR = this.gameObject.GetComponent<MeshRenderer>();
        originalColor = mR.material.color;

        mR.material.color = Color.blue;
        this.gameObject.transform.localScale *= 5;
        this.gameObject.GetComponent<Rigidbody>().mass *= 5;
        this.gameObject.GetComponent<PlayerController>().movementForce *= 5;

        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        StartCoroutine(DestroyAfterTime());

    }

    // Update is called once per frame
    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(timeToFinish);
        mR.material.color = originalColor;
        this.gameObject.transform.localScale /= 5;
        Destroy(this);
    }
}
