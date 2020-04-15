using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AntAI : MonoBehaviour
{
   public UnityEngine.AI.NavMeshAgent agent;

    public enum State {
        PATROL
    }

    public State state;
    private bool alive;

    // variables for patrolling
    public GameObject[] waypoints;
    public GameObject nest;
    private int waypointInd = 0;
    public float patrolSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updatePosition = true;
        agent.updateRotation = false;

        state = State.PATROL;

        alive = true;

        // START FSM in a background process
        StartCoroutine("FSM");
    }

    IEnumerator FSM() {
        while (alive) {
            switch (state) {
                case State.PATROL:
                    Patrol();
                    break;
            }
            yield return null;
        }
    }

    void Patrol() {
        agent.speed = patrolSpeed;
        if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) >= 1) {
            Quaternion newRotation = Quaternion.LookRotation(waypoints[waypointInd].transform.position - this.transform.position);
            //newRotation.x = 0f;
            //newRotation.z = 0f;

            //this.transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 5f);

            agent.SetDestination(waypoints[waypointInd].transform.position);
        } else if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) <= 1) {
            // if we're close to the position we want to get to
            // then it is time to go the next position
            waypointInd += 1;

            if (waypointInd >= waypoints.Length) {
                waypointInd = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
