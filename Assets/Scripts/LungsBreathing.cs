using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungsBreathing : MonoBehaviour
{

    public int highPressure = 1;

    [SerializeField]
    float period = 5f;

    [SerializeField] float temp;

    int smoke = 1;
    bool haveSmoked = false;

    SpawnParticel cigaret;
    void Start()
    {
        cigaret = GameObject.Find("Cigaret").GetComponent<SpawnParticel>();
    }


    void Update()
    {
        temp = Mathf.Sin(Time.timeSinceLevelLoad / period);

        if (temp > 0)
        {
            highPressure = 1;

            if (smoke <= 0)
            {
                cigaret.SmokeCig();

                int rando = Random.Range(1, 3);

                smoke += rando;
            }
            haveSmoked = false;
        }
        else
        {
            highPressure = -1;

            if (haveSmoked == false)
            {
                smoke--;
                haveSmoked = true;
            }
        }
    }



}
