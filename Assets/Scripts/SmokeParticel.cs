using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeParticel : MonoBehaviour {

    Rigidbody2D rb2D;
    LungsBreathing lungs;
    Vector3 pressurePos;

    [SerializeField]
    float force;

    Vector3 dir;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        lungs = GameObject.Find("Lungs").GetComponent<LungsBreathing>();
    }

    void FixedUpdate()
    {
        AddForceToTarget();
    }

    float callTime = 0;
    void OnTriggerStay2D(Collider2D other)
    {
        if (Time.time >= callTime)
        {
            if (other.tag == "Lungs")
            {
                pressurePos = other.transform.position;
            }

            callTime = Time.time + 0.4f;
        }
    }



    void AddForceToTarget()
    {
        float pressure = lungs.highPressure;

        if (pressure == 1)
        {
            pressure = 0.7f;
        }

        Vector3 pos = transform.position;

            dir = pos - pressurePos;
            //Debug.DrawLine(pressurePos, pos, Color.red);

        rb2D.AddForce((dir.normalized * force) * pressure, ForceMode2D.Impulse);
    }
}
