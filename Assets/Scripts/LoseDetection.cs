using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseDetection : MonoBehaviour
{
    public GameObject[] monsters;
    public float deathRadius;

    private void FixedUpdate()
    {
        for (int i = 0; i < monsters.Length; i++)
        {
            if (Vector3.Distance(monsters[i].transform.position, transform.position) < deathRadius && monsters[i].activeInHierarchy == true)
            {

                Lose();
            }
        }
    }

    public void Lose()
    {
        Debug.Log("LOSER LOL");
    }
}
