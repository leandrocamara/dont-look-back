using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullRotate : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        RotateSkullToPlayer();
    }

    private void RotateSkullToPlayer()
    {
        transform.LookAt(player.transform);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 90f, 0);
    }
}
