using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMoon : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(-1, 1, 0);
        transform.position += direction * speed * Time.fixedDeltaTime;
    }
}
