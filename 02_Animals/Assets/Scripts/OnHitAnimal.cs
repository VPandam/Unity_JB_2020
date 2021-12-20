using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitAnimal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            Destroy(this.gameObject);
            if (other.gameObject.transform.rotation.y == 1)
            {
                other.gameObject.transform.Rotate(new Vector3(0, -180, 0));
            }
        }


    }
}
