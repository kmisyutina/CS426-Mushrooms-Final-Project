using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour { 

    // Tutorial from "PATROL AI WITH UNITY AND C# - EASY TUTORIAL" by Blackthornprod
    public GameObject enemy;

    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int randomSpot;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        anim.Play("Take 001", 0, 0);

        if (Vector3.Distance(enemy.transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                // time to move again?
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
                // rotation
                Vector3 direction = moveSpots[randomSpot].transform.position - enemy.transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                enemy.transform.rotation = rotation;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
