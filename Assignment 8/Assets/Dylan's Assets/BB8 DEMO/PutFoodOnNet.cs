using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutFoodOnNet : MonoBehaviour
{
    public void centerFood(GameObject food)
    {
        food.transform.position = this.transform.position + new Vector3(0,1.0f,0);
    }
}
