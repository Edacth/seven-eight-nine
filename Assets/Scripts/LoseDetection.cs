using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseDetection : MonoBehaviour
{
    public GameObject[] monsters;
    public float deathRadius;
    public GameObject loseScreen;

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
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        loseScreen.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Debug.Log("LOSER LOL");
    }
}
