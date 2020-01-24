using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDetection : MonoBehaviour
{
    public int numToWin;
    public int numCollected;

    void FixedUpdate()
    {
        if (numCollected >= numToWin)
        {
            Win();
        }       
    }

    void Win()
    {
        Debug.Log("WINRAR");
    }
}
