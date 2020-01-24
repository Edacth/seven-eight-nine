using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDetection : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Win();
        }       
    }

    void Win()
    {
        Debug.Log("WINRAR");
    }
}
