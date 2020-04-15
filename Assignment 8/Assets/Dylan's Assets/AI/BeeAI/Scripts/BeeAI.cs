using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeeAI : MonoBehaviour
{
   public UnityEngine.AI.NavMeshAgent agent;

    public enum State {
        PATROL,
        CHASE
    }

    public State state;
    private bool alive;

    // variables for patrolling
    public GameObject[] waypoints;
    public GameObject nest;
    private int waypointInd = 0;
    public float patrolSpeed = 0.5f;

    public float chaseSpeed = 1f;
    public GameObject target;

    // variables for chasing

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updatePosition = true;

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
                case State.CHASE:
                    Chase();
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

    void Chase() {
        agent.speed = chaseSpeed;
        agent.SetDestination(target.transform.position + new Vector3(0, 0, .5f));

        float dist = Vector3.Distance(this.transform.position, nest.transform.position);

        // if the bee gets really far away from its nest, then let it go back to patrol state
        if (dist > 15f)
            state = BeeAI.State.PATROL;
    }

    private void OnTriggerEnter(Collider other) {

        if (other.tag == "Player") {
            state = BeeAI.State.CHASE;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
