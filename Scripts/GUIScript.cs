using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIScript : MonoBehaviour
{
    bool checker, start, character, stage;
    int selectedChar = 0, selectedStage = 0;
    public GameObject[] characters;
    public GameObject[] stages;
    void Start()
    {
        checker = true;
        start = false;
        character = false;
        stage = false;

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
                checker = true;
                character = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 25, Screen.height / 2 + 150, 75, 30), "BACK"))
            {
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
                checker = true;
                stage = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 25, Screen.height / 2 + 150, 75, 30), "BACK"))
            {
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
