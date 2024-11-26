using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIScript : MonoBehaviour
{
    bool MainMenu, start, character, stage, controls, playAgain, pause;
    int selectedChar = 0, selectedStage = 0, origChar, origStage;
    GameObject selCam;
    public GameObject selRoom;
    public GameObject[] charSel;
    public GameObject[] staSel;
    [SerializeField] GameObject[] stageObj, charObj;
    [SerializeField] Transform[] stageLoc;
    [SerializeField] Transform charLoc;
    void Start()
    {
        origChar = selectedChar;
        origStage = selectedStage;
        MainMenu = true;
        start = false;
        character = false;
        stage = false;
        controls = false;
        playAgain = false;
        pause = false;
        selCam = GameObject.Find("Selection Camera");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        if (playerMovement != null)
        {
            // int playerHp = playerMovement.hp;
            bool playerBackToMain = playerMovement.backToMain;
            MainMenu = playerBackToMain;
        }
        if(charSel[selectedChar] != null)
        {
            charSel[selectedChar].transform.Rotate(Vector3.up, 20*Time.deltaTime);
        }
        if(staSel[selectedStage] != null)
        {
            staSel[selectedStage].transform.Rotate(Vector3.up, 20*Time.deltaTime);
        }
    }

    private void OnGUI()
    {
        if (MainMenu)
        {
            DestroyObj();
            if (selCam != null)
            {
                selCam.SetActive(true);
            }
            GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 300, 300), "Main Menu");
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 30), "START"))
            {
                MainMenu = false;
                start = true;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 30), "CHARACTER"))
            {
                MainMenu = false;
                character = true;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 200, 30), "STAGE"))
            {
                MainMenu = false;
                stage = true;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 30), "CONTROLS"))
            {
                MainMenu = false;
                controls = true;
            }
        }
        if (character)
        {
            selRoom.SetActive(true);
            charSel[selectedChar].SetActive(true);
            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2, 75, 30), "PREV"))
            {
                charSel[selectedChar].SetActive(false);
                selectedChar = (selectedChar - 1 + charSel.Length) % charSel.Length;
                charSel[selectedChar].SetActive(true);
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 125, Screen.height / 2, 75, 30), "NEXT"))
            {
                charSel[selectedChar].SetActive(false);
                selectedChar = (selectedChar + 1) % charSel.Length;
                charSel[selectedChar].SetActive(true);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 150, 75, 30), "OKAY"))
            {
                origChar = selectedChar;
                charSel[selectedChar].SetActive(false);
                selRoom.SetActive(false);
                MainMenu = true;
                character = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 25, Screen.height / 2 + 150, 75, 30), "BACK"))
            {
                charSel[selectedChar].SetActive(false);
                selectedChar = origChar;
                selRoom.SetActive(false);
                MainMenu = true;
                character = false;
            }
        }
        if(stage)
        {
            staSel[selectedStage].SetActive(true);
            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2, 75, 30), "PREV"))
            {
                staSel[selectedStage].SetActive(false);
                selectedStage = (selectedStage - 1 + staSel.Length) % staSel.Length;
                staSel[selectedStage].SetActive(true);
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 125, Screen.height / 2, 75, 30), "NEXT"))
            {
                staSel[selectedStage].SetActive(false);
                selectedStage = (selectedStage + 1) % staSel.Length;
                staSel[selectedStage].SetActive(true);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 150, 75, 30), "OKAY"))
            {
                origStage = selectedStage;
                staSel[selectedStage].SetActive(false);
                MainMenu = true;
                stage = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 25, Screen.height / 2 + 150, 75, 30), "BACK"))
            {
                staSel[selectedStage].SetActive(false);
                selectedStage = origStage;
                MainMenu = true;
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
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 75, 250, 30), "Right-Click\t\t- Shoot");
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 200, 30), "BACK"))
            {
                MainMenu = true;
                controls = false;
            }

        }
        if (start)
        {
            if (selCam != null)
            {
                selCam.SetActive(false);
            }
            DestroyObj();
            Instantiate(charObj[selectedChar], charLoc.position, charLoc.rotation);
            Instantiate(stageObj[selectedStage], stageLoc[selectedStage].position, stageLoc[selectedStage].rotation);
            
            start = false;
        }
    }

    void DestroyObj(){
        GameObject charInstance = GameObject.Find(charObj[selectedChar].name + "(Clone)");
        if (charInstance != null)
        {
            Destroy(charInstance);
        }
        GameObject stageInstance = GameObject.Find(stageObj[selectedStage].name + "(Clone)");
        if (stageInstance != null)
        {
            Destroy(stageInstance);
        }
    }
}
