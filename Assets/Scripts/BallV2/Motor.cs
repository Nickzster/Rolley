using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sphere controls - N3K EN

public class Motor : MonoBehaviour
{
    public float moveSpeed = 5.0f; //Roll speed value
    public float drag = 0.5f; //Friction value
    public float terminalRotationSpeed = 25.0f; //Fastest object rotates. Match w/ moveSpeed
    public float gravity = 9.8f;
    public Transform feet;
    public LayerMask ground;
    private float disToGround;
    private bool isGrounded;
    private CharacterController charControl;

    public float jumpHeight;

    private Rigidbody controller; //Rigidbody of the player.

    private Transform camTransform; //Camera transform reference

    private Vector3 fallingVelocity;

    private void Start()
    {
        controller = GetComponent<Rigidbody>();
        controller.maxAngularVelocity = terminalRotationSpeed; 
        controller.drag = drag;
        charControl = GetComponent<CharacterController>();
        fallingVelocity = Vector3.up;
    }

    private void Update()
    {
        Vector3 dir = Vector3.zero; //Direction Vector
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        if(dir.magnitude > 1)
        {
            dir.Normalize(); //Don't go faster on diagonal axis. Refer to CS 485 Lectures.
        }
        //Rotate direction vector w/ camera
        camTransform = Camera.main.transform;

        Vector3 rotatedDirection = camTransform.TransformDirection(dir); //Transforms the direction w.r.t the camera
        rotatedDirection = new Vector3(rotatedDirection.x, 0, rotatedDirection.z);
        rotatedDirection = rotatedDirection.normalized * dir.magnitude;

//        bool isGrounded = Physics.CheckSphere(feet.position, 0.5f, ground, QueryTriggerInteraction.Ignore);
        Debug.Log(isGrounded);
        controller.AddForce(rotatedDirection * moveSpeed); //Move the object
        if(Input.GetButtonDown("Jump") && isGrounded)
            controller.velocity += jumpHeight * Vector3.up;

        if (Input.GetKeyDown("m"))
        {
            Application.LoadLevel("menu");
        }

        if(Input.GetKeyDown("r"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered");
        if(collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exited");
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }

}
