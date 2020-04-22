using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetPhysics : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Food")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        } 
    }
    
}
