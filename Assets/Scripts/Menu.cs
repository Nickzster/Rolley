using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    //size of button
    public int buttonWidth;
    public int buttonHeight;
    //position of button
    private int originX;
    private int originY;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        buttonWidth = 200;
        buttonHeight = 50;
        originX = Screen.width / 2 - buttonWidth / 2; //Places it in middle.
        originY = Screen.height / 2 - buttonHeight / 2;

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(originX, originY - 50, buttonWidth, buttonHeight), "Roll-A-Ball"))
        {
            Application.LoadLevel("minigame");
        }
        if(GUI.Button(new Rect(originX, originY, buttonWidth, buttonHeight), "My Game"))
        {

            Application.LoadLevel("myGame");
        }
        if (GUI.Button(new Rect(originX, originY + 50, buttonWidth, buttonHeight), "Quit Game"))
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit;
        #endif
        }

        /*
         pseudo code 
         if(exit button)
#if UNITY_EDITOR
                UnityEditor.Editor.Application.isPlaying = false;
#else
                Application.Quit;
#endif
         */
    }
}
