using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float gameLength = 0;
    Interval[] intervals;
    
    void Start()
    {
        
    }

    void Update()
    {
        gameLength += Time.deltaTime;

        for (int i = 0; i < intervals.Length; i++)
        {
            if (!intervals[i].activated || intervals[i].time < gameLength)
            {

            }
        }
    }
}

public class Interval
{
    public float time;
    public bool activated = false;
}
