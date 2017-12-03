using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour
{

    Rigidbody2D rb2D;
    LungsBreathing lungs;
    [SerializeField]
    Vector3 pressurePos;

    [SerializeField]
    float force;

    Co2 co2 = null;

    Vector3 dir;
    bool noTaget = false;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        lungs = GameObject.Find("Lungs").GetComponent<LungsBreathing>();

    }

    void FixedUpdate()
    {
        AddForceToTarget();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "RightCo2" || other.tag == "LeftCo2")
        {
            if (other.transform.childCount > 0 && transform.childCount <= 0)
            {
                other.transform.GetChild(0).transform.parent = transform;

                Co2 co2taken = other.GetComponent<Co2>();
                StartCoroutine(co2taken.GetComponent<Co2>().SpawnCo2());
                co2taken.taged = true;

                ClereCo2();
            }
        }

        if (other.tag == "H2O")
        {
            if (other.transform.childCount > 0 && transform.childCount <= 0)
            {
                other.transform.GetChild(0).transform.parent = transform;

                H2O h2Otaken = other.GetComponent<H2O>();
                StartCoroutine(h2Otaken.GetComponent<H2O>().SpawnH2O());
            }
        }

        if (other.tag == "Lungs")
        {
            pressurePos = other.transform.position;
        }

        if (other.name == "LeftLung")
        {
            GetCo2("Left");
        }
        if (other.name == "RightLung")
        {
            GetCo2("Right");
        }

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

            if (other.name == "LeftLung")
            {
                GetCo2("Left");
            }
            if (other.name == "RightLung")
            {
                GetCo2("Right");
            }

            callTime = Time.time + 0.01f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        ClereCo2();
    }

    void ClereCo2()
    {
        if (co2 != null)
        {
            co2.taged = false;
            co2 = null;
            noTaget = false;
        }
    }

    void GetCo2(string side)
    {
        if (lungs.highPressure == 1 && co2 == null && noTaget == false)
        {
            GameObject[] allCo2 = GameObject.FindGameObjectsWithTag(side + "Co2");

            for (int i = 0; i < allCo2.Length; i++)
            {
                Co2 taget = allCo2[i].GetComponent<Co2>();
                if (taget.taged == false)
                {
                    taget.taged = true;
                    co2 = taget;
                    break;
                }
            }
            if (co2 == null)
            {
                noTaget = true;
            }
        }
    }

    void AddForceToTarget()
    {
        int pressure = lungs.highPressure;

        Vector3 pos = transform.position;

        if (co2 != null && lungs.highPressure == 1)
        {
            dir = co2.transform.position - pos;
            //Debug.DrawLine(co2.transform.position, pos, Color.blue);
        }
        else
        {
            dir = pos - pressurePos;
            //Debug.DrawLine(pressurePos, pos, Color.red);
        }


        rb2D.AddForce((dir.normalized * force) * pressure, ForceMode2D.Impulse);

    }


}
