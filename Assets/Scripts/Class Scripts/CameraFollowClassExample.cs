using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    /*
        public TRansform target;    
        private Vector3 offset;
        
        private float sensitivity; -> Rotation speed    
        private float rotationX; -> X rotation
        private float rotationY; -> Y rotation

        private float minY = -30f;
        private float maxY = 30f;
    */

    // Use this for initialization
    void Start ()
    {
        /*
        offset = transform.position - target.position; <- distance between camera and player object
        */
    }

    // Update is called once per frame
    void Update ()
    {
        /*
            //transform.lookAt(target, Vector3.up); -> tracks player by rotation 
            -> transform.position = target.position + offset; -> places the camera behind the robot to follow it.
            This does not rotate the camera as the robot turns however.
            -Tracks player via position transforms.
            **
            -> rotationX = transform.LocalEulerAngles.y + Input.GetAxis("mouse X") * rotation speed);
            -> rotationY += Input.GetAxis("Mouse Y") * rotationSpeed;
            -> transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            **
            * This will both track the player & rotate the CAMERA. It does not rotate the camera
            * Around the player.
            * 
            *        **
            -> rotationX = transform.LocalEulerAngles.y + Input.GetAxis("mouse X") * rotation speed);
            -> rotationY = Mathf.clamp();
            -> rotationY += Input.GetAxis("Mouse Y") * rotationSpeed;
            -> transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            **
            * This locks the camera rotation on Y axis.
            * 
            * 
            * 
            -> rotationX = transform.LocalEulerAngles.y + Input.GetAxis("mouse X") * rotation speed);
            -> rotationY = Mathf.clamp();
            -> rotationY += Input.GetAxis("Mouse Y") * rotationSpeed;
            -> transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

            


        */

        /*
         First PERSON CONTROLLER
        See professor's project.
        We want to rotate the camera with the robot when it turns.
        Change to first person. ==> make camera a child of robot. 
        Name camera to eye
        change the position of camera to match with robots looking position.
        Change to let robot strafe side to side. Use mouse to rotate.

        How to check local coordinate system:
        if(direction.x != 0)
        {
            rbody.MovePosition(rbody.position + transform.right * direction.x * speed * Time.deltatime)
        }
        if(direction.z != 0)
        {
            see professor's github
        }
          
        */
    }
}
