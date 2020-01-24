using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinItem : MonoBehaviour
{
    public bool active = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            WinDetection wd = other.gameObject.GetComponent<WinDetection>();
            wd.numCollected += 1;
            gameObject.SetActive(false);
        }
    }
}
