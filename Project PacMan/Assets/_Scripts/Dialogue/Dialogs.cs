using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogs : MonoBehaviour
{
    public string textDisplayed;
    public int speakingCharID;
    public int nextDialogID;
    public float timer;

    public Dialogs(string textDisplayed, int speakingCharID,int nextDialogID)
    {
        this.textDisplayed = textDisplayed;
        this.speakingCharID = speakingCharID;
        this.nextDialogID = nextDialogID;
    }

    public Dialogs(string textDisplayed, int speakingCharID, int nextDialogID, float timing)
    {
        this.textDisplayed = textDisplayed;
        this.speakingCharID = speakingCharID;
        this.nextDialogID = nextDialogID;
        this.timer = timing;
    }

}
