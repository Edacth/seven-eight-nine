using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 forwardVector;
    Vector3 motion;
    public float mouseSensitivity = 60f;
    public float verticalSpeed = 0.1f;
    public float horizontalSpeed = 0.07f;

    public GameObject camera;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


        // Translate mouse movement to rotation
        Vector3 rotationChange = Vector3.zero;
        rotationChange.x += -(Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime);
        rotationChange.y += (Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime);

        //camera.transform.Rotate(rotationChange, Space.World);
        camera.transform.eulerAngles += rotationChange;

        //Debug.DrawRay(transform.position, camera.transform.forward.normalized * 5);

    }

    private void FixedUpdate()
    {
        float angle = (camera.transform.rotation.eulerAngles.y) * (Mathf.PI / 180); // Convert to radians'

        forwardVector.x = (float)Mathf.Sin(angle);
        forwardVector.z = (float)Mathf.Cos(angle);
        forwardVector.Normalize();
        Debug.DrawRay(transform.position, forwardVector * 10);

        motion = Vector3.zero;
        motion.x = forwardVector.x * Input.GetAxis("Vertical");
        motion.z = forwardVector.z * Input.GetAxis("Vertical");
        //Debug.Log(Input.GetAxis("Vertical"));

        // Project on plane is magical
        motion = Vector3.ProjectOnPlane(camera.transform.forward * Input.GetAxisRaw("Vertical") * verticalSpeed + camera.transform.right * Input.GetAxisRaw("Horizontal") * horizontalSpeed, Vector3.up);
        //Debug.Log((motion));
        //Debug.Log((motion * verticalSpeed));
        // Move player
        //transform.position += motion * Time.deltaTime;
        //rb.AddForce(motion * 500 * Time.deltaTime, ForceMode.Force);
        rb.MovePosition(transform.position + motion);
        //rb.velocity = motion * playerSpeed;
    }
}
