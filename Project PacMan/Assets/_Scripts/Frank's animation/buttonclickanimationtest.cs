using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonclickanimationtest : MonoBehaviour
{
    public void SetText(string text)
    {
        Text txt = transform.Find("anim").GetComponent<Text>();
        txt.text = text;
    }
}
