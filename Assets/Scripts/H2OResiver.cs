using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H2OResiver : MonoBehaviour {

    UIH2O h2o;
    [SerializeField]
    int fillH2O = 5;

    void Start()
    {
        h2o = GameObject.Find("UIH2O").GetComponent<UIH2O>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "H2oParticel")
        {
            h2o.h2oLeft = Mathf.Clamp(h2o.h2oLeft + fillH2O, 0, 100);
            Destroy(other.gameObject);
        }
    }
}
