using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatText : MonoBehaviour
{
    public float speed = 5f;
    public float height = 0.5f;

    void Update()
    {
        Vector3 pos = transform.position;
        float newY = pos.y + Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(pos.x, newY, pos.z);
    }
}
