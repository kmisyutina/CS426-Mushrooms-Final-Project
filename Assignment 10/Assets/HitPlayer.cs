using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    public float force;
    public bool hit;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            hit = true;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * force);
        } else
        {
            hit = false;
        }
    }
}
