using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Co2 : MonoBehaviour {

    public bool taged;

    [SerializeField] GameObject co2;

    public IEnumerator SpawnCo2()
    {
        float randomFloat = Random.Range(2, 4);

        yield return new WaitForSeconds(randomFloat);

        GameObject clone = Instantiate(co2, transform.position, transform.rotation, transform) as GameObject;
    }

}
