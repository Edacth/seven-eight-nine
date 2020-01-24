using System;
using System.Collections;
using UnityEngine;

public class CreatureAIScript : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject creature;

    public enum State
    {
        PATROL,
        CHASE
    }

    public State state;
    private bool alive;

    // Patrol Variables
    public GameObject[] PatrolPoints;
    private int PatrolPointInd = 0;
    public float PatrolSpeed = 1.0f;

    // Chase Variables
    public GameObject Target;
    public float ChaseSpeed = 2.0f;

    public float detectionRadius;


    bool yell;
    public AudioClip yellSound;




    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        agent.updatePosition = true;
        agent.updateRotation = true;

        state = CreatureAIScript.State.PATROL;

        alive = true;

        StartCoroutine("FSM");
    }

    IEnumerator FSM()
    {
        while (alive)
        {
            switch (state)
            {
                case State.PATROL:
                    Patrol();
                    if (!yell)
                    {
                        yell = true;
                    }
                    break;
                case State.CHASE:
                    Chase();
                    if (yell)
                    {
                        AudioSource source = GetComponent<AudioSource>();
                        source.PlayOneShot(yellSound);
                        yell = false;
                    }
                    break;
            }
            yield return null;
        }


    }

    void Patrol()
    {
        agent.speed = PatrolSpeed;
        if (Vector3.Distance(this.transform.position, PatrolPoints[PatrolPointInd].transform.position) >= 2)
        {
            agent.SetDestination(PatrolPoints[PatrolPointInd].transform.position);

        }
        else if (Vector3.Distance(this.transform.position, PatrolPoints[PatrolPointInd].transform.position) <= 2)
        {
            //PatrolPointInd += 1;
            //if (PatrolPointInd >= PatrolPoints.Length)
            //{
            //    PatrolPointInd = 0;
                
            //}
            PatrolPointInd = UnityEngine.Random.Range(0, PatrolPoints.Length);
            //Debug.Log("Length: " + PatrolPoints.Length + " Ind: " + PatrolPointInd);
        }

        if (Vector3.Distance(transform.position, Target.transform.position) <= detectionRadius)
        {
            state = State.CHASE;
        }
        
    }

    void Chase()
    {
        agent.speed = ChaseSpeed;
        agent.SetDestination(Target.transform.position);

        if (Vector3.Distance(transform.position, Target.transform.position) >= detectionRadius)
        {
            state = State.PATROL;
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        //if (coll.tag == "Player")
        //{
        //    state = CreatureAIScript.State.CHASE;
        //    Target = coll.gameObject;
        //}
    }
}
