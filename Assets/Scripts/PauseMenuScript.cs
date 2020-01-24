using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

enum PauseState
{
    Unpaused,
    Held,
    Paused,
}

public class PauseMenuScript : MonoBehaviour
{
    public UnityEngine.UI.Image pauseImage;
    PauseState pauseState = PauseState.Unpaused;
    public Sprite unpaused;
    public Sprite held;
    public Sprite paused;

    

    void Update()
    {
        if (pauseState == PauseState.Unpaused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SetState(PauseState.Held);
            }
            
        }
        else if (pauseState == PauseState.Held)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                SetState(PauseState.Paused);
            }
        }
        else if (pauseState == PauseState.Paused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SetState(PauseState.Unpaused);
            }
        }
    }

    void SetState(PauseState state)
    {
        switch (state)
        {
            case PauseState.Unpaused:
                pauseState = PauseState.Unpaused;
                pauseImage.sprite = unpaused;
                Time.timeScale = 1;
                break;
            case PauseState.Held:
                pauseState = PauseState.Held;
                pauseImage.sprite = held;
                break;
            case PauseState.Paused:
                pauseState = PauseState.Paused;
                pauseImage.sprite = paused;
                Time.timeScale = 0;
                break;
            default:
                break;
        }
    }
}
