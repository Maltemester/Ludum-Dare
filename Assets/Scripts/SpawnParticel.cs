using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticel : MonoBehaviour {

    bool inhales = false;
    [SerializeField] float startSpawnTimer = 0.1f;
    float spawnTimer = 0.1f;

    LungsBreathing lungs;
    [SerializeField]GameObject smoke;

    [SerializeField]
    float force = 0.5f;

    [SerializeField]
    GameObject pos;

    Animator anim;

    void Start()
    {
        lungs = GameObject.Find("Lungs").GetComponent<LungsBreathing>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (inhales && spawnTimer <= Time.time)
        {
            Spawn();
            spawnTimer = Time.time + startSpawnTimer;
        }
    }

    public void SmokeCig()
    {
        anim.SetBool("Ready", true);
        StartCoroutine(StopSmoke());
    }


    IEnumerator StopSmoke()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Ready", false);
    }

    void Spawn()
    {
        GameObject clone = Instantiate(smoke, pos.transform.position, pos.transform.rotation) as GameObject;
        clone.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force, ForceMode2D.Impulse);
    }

    public void Inhale()
    {
        inhales = !inhales;
    }
}