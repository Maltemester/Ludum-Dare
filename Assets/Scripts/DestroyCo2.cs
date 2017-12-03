using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCo2 : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Co2")
        {
            Destroy(other.transform.gameObject);
        }
        if (other.tag == "Smoke")
        {
            Destroy(other.transform.gameObject);
        }
    }
}
