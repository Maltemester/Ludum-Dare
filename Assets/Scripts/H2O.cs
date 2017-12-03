using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H2O : MonoBehaviour {

    [SerializeField]
    GameObject h2O;

    public IEnumerator SpawnH2O()
    {
        float randomFloat = Random.Range(2, 4);

        yield return new WaitForSeconds(randomFloat);

        GameObject clone = Instantiate(h2O, transform.position, transform.rotation, transform) as GameObject;
    }
}
