using UnityEngine;
using System.Collections;

public class CamerFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float diss;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x , player.transform.position.y + diss, -10), 0.5F);
    }
}