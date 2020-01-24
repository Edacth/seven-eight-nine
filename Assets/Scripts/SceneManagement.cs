using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public string targetScene;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            RestartScene();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            GotoScene(targetScene);
        }
    }

    void RestartScene()
    {
        Debug.Log("Reload scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void GotoScene(string sceneName)
    {
        Debug.Log("Load scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
