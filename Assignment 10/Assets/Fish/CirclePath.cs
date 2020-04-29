using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePath : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float xOffset;
    public float yOffset;
    public float zOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.GetComponentInChildren<MeshRenderer>().bounds.center + new Vector3(xOffset,yOffset,zOffset), Vector3.forward, 30 * Time.deltaTime * speed);
    }
}
