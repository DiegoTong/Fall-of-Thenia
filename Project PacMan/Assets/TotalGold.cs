using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalGold : MonoBehaviour
{
    public Text Gold;
    public int totalGold = 100;
    public int EarnedGold = 0;

    private void Awake()
    {
        Gold = GameObject.FindWithTag("GoldText").GetComponent<Text>();
        Gold.text = totalGold.ToString();
    }

    void MakeItRain()
    {
        totalGold = totalGold + EarnedGold;
    }

    private void Update()
    {
        Gold.text = totalGold.ToString();
    }

}

