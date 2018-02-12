using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Invert Y-Axis in inputManager!!!

public class FreeCameraMotor : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 0.0f; //Min angle user can look down at.
    private const float Y_ANGLE_MAX = 50.0f; //Max angle user can look up at.

    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;

    private float distance = 5.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float fixedX = 0.0f;
    private float fixedY = 0.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;

    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        fixedY = 20.0f;
        currentY = fixedY;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        if (Input.GetMouseButton(1))
        {
            currentY += Input.GetAxis("Mouse Y");
        }
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {

        Vector3 dir = new Vector3(0, 0, -distance); //This is the direction (rep. as a vector) the camera needs to look at.
        Quaternion rotation = Quaternion.Euler(currentY * sensitivityY, currentX * sensitivityX, 0); //for rotation on x & y
        Quaternion fixedRotation = Quaternion.Euler(fixedY, currentX * sensitivityX, 0); //for rotation on x only

                if (Input.GetMouseButton(1)) //if the player is holding down right click -- move camera horizontally + vertically. 
                {
                    fixedX = currentX;
                    fixedY = currentY;
                    camTransform.position = lookAt.position + rotation * dir; //move the Camera
                    camTransform.LookAt(lookAt.position); //Lock camera to target.
                }
                else //player is not holding down left click -- move camera horizontally ONLY.
                {
                    camTransform.position = lookAt.position + fixedRotation * dir; //Move camera
                    camTransform.LookAt(lookAt.position); //Lock camera to target
                } 
    }
}
