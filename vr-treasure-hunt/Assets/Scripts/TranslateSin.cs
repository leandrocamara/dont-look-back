using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateSin : MonoBehaviour
{
    public float distance = 500;
    public float speed = 2.0f;

    private void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y + Mathf.Sin(Time.time * distance) / speed,
            transform.position.z
        );
    }
}
