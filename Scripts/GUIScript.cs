using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIScript : MonoBehaviour
{
    bool checker, start, character, stage, controls, playAgain;
    int selectedChar = 0, selectedStage = 0, origChar, origStage;
    public GameObject[] characters;
    public GameObject[] stages;
    void Start()
    {
        origChar = selectedChar;
        origStage = selectedStage;
        checker = true;
        start = false;
        character = false;
        stage = false;
        controls = false;
        playAgain = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(characters[selectedChar] != null)
        {
            characters[selectedChar].transform.Rotate(Vector3.up, 20*Time.deltaTime);
        }
        if(stages[selectedStage] != null)
        {
            stages[selectedStage].transform.Rotate(Vector3.up, 20*Time.deltaTime);
        }
    }

    private void OnGUI()
    {
        if (checker)
        {
            GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 300, 300), "Main Menu");
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 30), "START"))
            {
                checker = false;
                start = true;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 30), "CHARACTER"))
            {
                checker = false;
                character = true;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 200, 30), "STAGE"))
            {
                checker = false;
                stage = true;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 30), "CONTROLS"))
            {
                checker = false;
                controls = true;
            }
        }
        if (character)
        {
            characters[selectedChar].SetActive(true);
            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2, 75, 30), "PREV"))
            {
                characters[selectedChar].SetActive(false);
                selectedChar = (selectedChar - 1 + characters.Length) % characters.Length;
                characters[selectedChar].SetActive(true);
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 125, Screen.height / 2, 75, 30), "NEXT"))
            {
                characters[selectedChar].SetActive(false);
                selectedChar = (selectedChar + 1) % characters.Length;
                characters[selectedChar].SetActive(true);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 150, 75, 30), "OKAY"))
            {
                origChar = selectedChar;
                characters[selectedChar].SetActive(false);
                checker = true;
                character = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 25, Screen.height / 2 + 150, 75, 30), "BACK"))
            {
                characters[selectedChar].SetActive(false);
                selectedChar = origChar;
                checker = true;
                character = false;
            }
        }
        if(stage)
        {
            stages[selectedStage].SetActive(true);
            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2, 75, 30), "PREV"))
            {
                stages[selectedStage].SetActive(false);
                selectedStage = (selectedStage - 1 + stages.Length) % stages.Length;
                stages[selectedStage].SetActive(true);
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 125, Screen.height / 2, 75, 30), "NEXT"))
            {
                stages[selectedStage].SetActive(false);
                selectedStage = (selectedStage + 1) % stages.Length;
                stages[selectedStage].SetActive(true);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 150, 75, 30), "OKAY"))
            {
                origStage = selectedStage;
                stages[selectedStage].SetActive(false);
                checker = true;
                stage = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 25, Screen.height / 2 + 150, 75, 30), "BACK"))
            {
                stages[selectedStage].SetActive(false);
                selectedStage = origStage;
                checker = true;
                stage = false;
            }
        }
        if(controls)
        {
            GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 175, 300, 325), "CONTROLS");
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 125, 250, 30), "W/Up-Arrow\t- Move Forward");
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 250, 30), "S/Down-Arrow\t- Move Backward");
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 75, 250, 30), "A/Left-Arrow\t- Move Left");
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 250, 30), "D/Right-Arrow\t- Move Right");
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 250, 30), "Shift\t\t- Run");
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2, 250, 30), "Space\t\t- Jump");
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 25, 250, 30), "Mouse\t\t- Look Around");
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 50, 250, 30), "Left-Click\t\t- Attack");
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 200, 30), "BACK"))
            {
                checker = true;
                controls = false;
            }

        }
        if (start)
        {
            //aaaaa
        }
        if (playAgain)
        {
            
        }
    }
}
