using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class WorldMap : MonoBehaviour
{
    public Dialogs[] dialogs = new Dialogs[10];
    public GameObject dialogBox;
    public GameObject infoPic;
    public Text text;
    public int nextDialog = 0;
    public bool tutorial = false;
    MapManager mapManager;

    private int infoBox = 0;

    // Forces the player to see the Tutorial.
    // Only works once
    IEnumerator textDelay(float time)
    {
        yield return new WaitForSeconds(time);
        setText();
    }

    // Start is called before the first frame update
    void Start()
    {
        mapManager = GameObject.FindGameObjectWithTag("Player").GetComponent<MapManager>();
        dialogs[0] = new Dialogs("Welcome To the World Map!", infoBox, 1, 3.0f);
        dialogs[1] = new Dialogs("Here You can see your Player and Compass ", infoBox, 2, 4.0f);
        dialogs[2] = new Dialogs("You can Walk around With WASD or the Left Joystick and Rotate the Camera with the Mouse or Right Stick", infoBox, 3, 7.0f);
        dialogs[3] = new Dialogs("The Compass above your Character will point to the Current Objective", infoBox, 4, 5.0f);
        dialogs[4] = new Dialogs("As you complete objectives more of the map will be unlocked allowing you a larger area to explore", infoBox, 5, 7.0f);
        dialogs[5] = new Dialogs("You can open the Pause menu with P", infoBox, 6, 3.0f);   // Waiting on extra Instructions
        dialogs[6] = new Dialogs("Clicking on their Portrait will give you their Stats", infoBox, 7, 4.0f);
        dialogs[7] = new Dialogs("For Now, Head Onwards to Solise!", infoBox, 8, 3.0f);
        dialogs[8] = new Dialogs("", infoBox, -1, 3.0f);


        if (tutorial == false)
        {
            infoPic.SetActive(true);
            dialogBox.SetActive(false);
            setText();
            tutorial = true;
        }
    }
    // Called from the mapManeger Script
    public void setText()
    {
        text.text = dialogs[nextDialog].textDisplayed; // Sets the text to the right Dialogue
        nextDialog = dialogs[nextDialog].nextDialogID;
        if (nextDialog == -1)
        {
            dialogBox.SetActive(false);
            infoPic.SetActive(false);
        }
        else
        {
            StartCoroutine(textDelay(dialogs[nextDialog].timer));
        }
    }
}
