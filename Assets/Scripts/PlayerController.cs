using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 camRotation;
    public Vector3 forwardVector;
    public Vector3 motion;
    public float mouseSensitivity = 20f;

    public GameObject camera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        // Translate mouse movement to rotation
        Vector3 rotationChange = Vector3.zero;
        rotationChange.x += -(Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime);
        rotationChange.y += (Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime);

        //camera.transform.Rotate(rotationChange, Space.World);
        camera.transform.eulerAngles += rotationChange;
        Debug.Log(rotationChange);

        Debug.DrawRay(transform.position, camera.transform.forward.normalized * 5);

        // Get movement input
        motion = Vector3.zero;
        motion.x = Input.GetAxis("Vertical");

        // Move player
        transform.position += motion * Time.deltaTime;
        
    }
}
