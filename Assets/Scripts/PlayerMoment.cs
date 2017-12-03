using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoment : MonoBehaviour {

    private Vector3 diff;

    [SerializeField] float startForce = 2;
     float force;

    Rigidbody2D rb2D;

    void Start()
    {
        force = startForce;
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.z = 0;
        diff.Normalize();

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(0, 0, 1), diff), 0.3f);
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            force = startForce * 2;
        }
        else
        {
            force = startForce;
        }

        rb2D.AddForce(diff * force, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Smoke")
        {
            Destroy(other.gameObject);
        }
    }
}
