using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnFood : MonoBehaviour
{
    public GameObject theObject;
    public float maxPos = 50f;
    public float minPos = -50f;
    
    public int max = 100;

    void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn() {
         for (int i = 0; i<max; i++) {
             yield return new WaitForSeconds(0.3f);
             Vector3 theNewPos = new Vector3(Random.Range(minPos, maxPos), 0, Random.Range(minPos, maxPos));
             GameObject go = Instantiate(theObject);
             go.transform.position = theNewPos;
         }
     }
}
