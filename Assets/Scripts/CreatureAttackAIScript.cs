using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreatureAttackAIScript : MonoBehaviour
{

    private NavMeshAgent CreatureCapsule;

    public GameObject PlayerCapsule;

    public float CreatureAttackDistance = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        CreatureCapsule = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, PlayerCapsule.transform.position);

        if (distance < CreatureAttackDistance)
        {
            Vector3 dirToPlayer = transform.position - PlayerCapsule.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;

            CreatureCapsule.SetDestination(newPos);
        }
    }
}
