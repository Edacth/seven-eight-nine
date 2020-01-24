using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    bool active = true;
    public Vector3 spawnLocation;
    public GameObject spawnObject;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && active)
        {
            Debug.Log("ENTER");
            Instantiate(spawnObject, spawnLocation, Quaternion.identity);
            active = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(spawnLocation, 0.4f);
    }
}
