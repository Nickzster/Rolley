using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    public float speed;
    public Text countText;
    public Text winText;

    public float jumpHeight;

    private void increment()
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
        count = 0;
        increment();
        winText.text = "";
    }

    private void Update() //Called before rendering a frame
    {
       
    }
    private void FixedUpdate() //Called before performing any physics calculations
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical); //used for addforce.

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
