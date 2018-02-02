using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    //Movement stuff
    private Rigidbody rb; //Player object
    private int count; //Used for pick ups
    public float speed; //How fast the object will move
    private Vector3 fallingVelocity; //Used for gravity simulation.
    //Physics stuff
    public LayerMask ground;
    public Transform feet;
    //Game Stuff
    public Text countText; //Displays on user HUD
    public Text winText; //Displays winner message

    public float Gravity; //Standard gravity

    public float jumpHeight; //Jump height

    private void increment() //Increments count. Used for Game stuff
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 11)
        {
            winText.text = "YOU WIN!!!";
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        fallingVelocity.x = 0;
        fallingVelocity.y = 0;
        fallingVelocity.z = 0;
        count = 0;
        increment();
        winText.text = "";
    }

    private void Update() //Called before rendering a frame
    {
        //      bool isGrounded = Physics.CheckSphere(feet.position, 0.0f, ground, QueryTriggerInteraction.Ignore);
        bool isGrounded = true;
        Debug.Log(isGrounded);

//        fallingVelocity.y -= fallingVelocity.y - Gravity * Time.deltaTime; //This updates the falling velocity value.
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            fallingVelocity.y = Mathf.Sqrt(Gravity * jumpHeight);
            Debug.Log(fallingVelocity);
            rb.AddForce(fallingVelocity);
            Debug.Log("Player should jump now");
        }
      
    }
    private void FixedUpdate() //Called before performing any physics calculations
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical); //used for addforce.
        movement = movement.normalized;

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            Debug.Log(count);
            increment();
        }
    }

   // Destroy(other.gameObject);
}
