using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterTeleporter : MonoBehaviour
{
    public float cooldown = 5f;
    public Vector3 teleportLocation;
    public GameObject[] monsters;

    float realCooldown;

    void Start()
    {
        
    }

    void Update()
    {
        if (realCooldown > 0)
        {
            realCooldown -= Time.deltaTime;
            if (realCooldown < 0) { realCooldown = 0; }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && realCooldown == 0f)
        {
            float longestDist = int.MinValue;
            int farthestIndex = 0;
            for (int i = 0; i < monsters.Length; i++)
            {
                float dist = Vector3.Distance(transform.position, monsters[i].transform.position);
                if (dist > longestDist && monsters[i].activeSelf)
                {
                    longestDist = dist;
                    farthestIndex = i;
                }
            }
            NavMeshAgent agent = monsters[farthestIndex].GetComponent<NavMeshAgent>();
            agent.Warp(teleportLocation);

            realCooldown = cooldown;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(teleportLocation, 0.4f);
    }
}
