using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (this.gameObject.tag)
            {
                case "Lightning":
                    if (other.gameObject.TryGetComponent(out Lightning lightning) == false)
                    {
                        other.gameObject.AddComponent<Lightning>();
                        Destroy(this.gameObject);

                    }
                    break;
                case "Star":
                    if (other.gameObject.TryGetComponent(out Star star) == false)
                    {
                        other.gameObject.AddComponent<Star>();
                        Destroy(this.gameObject);
                    }
                    break;

            }


        }
    }
}