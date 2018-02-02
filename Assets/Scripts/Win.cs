using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Win : MonoBehaviour
{
    public Collider PlayerColl;
    public Text winText;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other == PlayerColl)
        {
            winText.text = "YOU WIN!!!";
        }
    }
}
