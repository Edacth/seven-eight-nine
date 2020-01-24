using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public string targetScene;
    void Start()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Time.timeScale = 1;
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

    public void RestartScene()
    {
        Debug.Log("Reload scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GotoScene(string sceneName)
    {
        Debug.Log("Load scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

    
}

