using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIScript : MonoBehaviour
{
    bool checker, start, character, stage;
    string[] chars, stages;
    int origRadChar, origRadSta, radioIndex1 = 0, radioIndex2 = 0;
    void Start()
    {
        checker = true;
        start = false;
        character = false;
        stage = false;
        origRadChar = radioIndex1;
        origRadSta = radioIndex2;
        chars = new string[] { "", "", "" };
        stages = new string[] { "", "", "" };

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (checker)
        {
            GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 200), "Main Menu");
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 30), "START"))
            {
                checker = false;
                start = true;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 200, 30), "CHARACTER"))
            {
                checker = false;
                character = true;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 30), "STAGE"))
            {
                checker = false;
                stage = true;
            }
        }
        if (character)
        {
            GUI.Box(new Rect(Screen.width / 2 - 325, Screen.height / 2 - 200, 650, 400), "SELECT CHARACTER");
            radioIndex1 = GUI.Toolbar(new Rect(Screen.width / 2 - 210, Screen.height / 2 + 75, 600, 30),
                radioIndex1, chars, "Toggle");
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 150, 75, 30), "OKAY"))
            {
                origRadChar = radioIndex1;
                checker = true;
                character = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 25, Screen.height / 2 + 150, 75, 30), "CANCEL"))
            {
                radioIndex1 = origRadChar;
                checker = true;
                character = false;
            }
        }
        if(stage)
        {
            GUI.Box(new Rect(Screen.width / 2 - 325, Screen.height / 2 - 200, 650, 400), "SELECT STAGE");
            radioIndex2 = GUI.Toolbar(new Rect(Screen.width / 2 - 210, Screen.height / 2 + 75, 600, 30),
                radioIndex2, stages, "Toggle");
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 150, 75, 30), "OKAY"))
            {
                origRadSta = radioIndex2;
                checker = true;
                stage = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 25, Screen.height / 2 + 150, 75, 30), "CANCEL"))
            {
                radioIndex2 = origRadSta;
                checker = true;
                stage = false;
            }
        }
        if (start)
        {
            //aaaaa
        }
    }
}
