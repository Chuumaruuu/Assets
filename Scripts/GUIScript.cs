using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIScript : MonoBehaviour
{
    bool checker = true;
    bool option = false;
    bool start = false;
    bool det = false;
    string playerName = "";
    string[] diff;
    int origRad, radioIndex = 0;
    float origSld, sldValue = 1;
    // Start is called before the first frame update
    void Start()
    {
        origRad = radioIndex;
        origSld = sldValue;
        diff = new string[] { "Easy", "Hard", "Extreme" };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (checker)
        {
            GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 200, 300, 400), "Main Menu");
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 150, 200, 30), "START"))
            {
                checker = false;
                start = true;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 30), "OPTION"))
            {
                checker = false;
                option = true;
            }
        }
        if (option)
        {
            GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 150, 450, 300), "OPTION");
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 80), "Difficulty:");
            radioIndex = GUI.Toolbar(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 50, 400, 30),
                radioIndex, diff, "Toggle");
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2, 300, 80), "Game Speed:");
            sldValue = (int) GUI.HorizontalSlider(
                new Rect(Screen.width / 2 - 150, Screen.height / 2 + 25, 300, 30), sldValue, 1, 10);
            GUI.Label(new Rect(Screen.width / 2 + 175, Screen.height / 2 + 25, 300, 80), sldValue.ToString());
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 75, 75, 30), "OKAY"))
            {
                origRad = radioIndex;
                origSld = sldValue;
                option = false;
                checker = true;
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 100, Screen.height / 2 + 75, 75, 30), "CANCEL"))
            {
                radioIndex = 0;
                sldValue = 1;
                option = false; 
                checker = true;
            }
        }
        if (start)
        {
            GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 150, 400, 300), "");
            playerName = GUI.TextField(
                new Rect(Screen.width / 2 - 75, Screen.height / 2 - 100, 250, 20), playerName);
            GUI.Label(new Rect(Screen.width / 2 - 175, Screen.height / 2 - 100, 300, 50), "Player Name:");
            if (GUI.Button(new Rect(Screen.width / 2 - 75, Screen.height / 2, 150, 100), "OKAY") && playerName != "")
            {
                start = false;
                det = true;
            }
        }
        if (det)
        {
            GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 300, 300), "");
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 300, 50), "Player Name:     " + playerName);
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 300, 50), "Difficulty:           " + diff[radioIndex]);
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2, 300, 50), "Game Speed:     " + sldValue);
        }
    }
}
