using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;
    public Transform Player;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position; //gets the distance from the camera to the player object
    }

    // Update is called once per frame
    void LateUpdate() //runs every frame, but it is guaranteed to run after all objects have been processed.
    {
        transform.position = player.transform.position + offset; //as we move the player, the camera is moved into a new position alligned with player object.
        transform.LookAt(Player);
//        transform.Rotate(Vector3.up);

    }
}
