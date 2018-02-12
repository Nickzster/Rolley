using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{

    public Collider PlayerColl;
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
        Debug.Log("ONTRIGGERENTERED");
        if(other == PlayerColl)
        {
            Debug.Log("PLAYER");
            SceneManager.LoadScene("myGame");
        }
    }
}
