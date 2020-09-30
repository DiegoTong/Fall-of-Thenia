using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenuStats : MonoBehaviour
{
    PlayerInfo playerstats;
    public Text CeryzLevel;
    public Text GwynLevel;
    public Text FredalfLevel;
    public Text FredalfHealth;
    public Text FredalfMana;
    public Text GwynHealth;
    public Text GwynMana;
    public Text CeryzHealth;
    public Text CeryzMana;

    private void Awake()
    {
        GwynLevel = GameObject.FindWithTag("LVLTxt").GetComponent<Text>();
        CeryzLevel = GameObject.FindWithTag("LVLTxt").GetComponent<Text>();
        FredalfLevel = GameObject.FindWithTag("LVLTxt").GetComponent<Text>();
        GwynHealth = GameObject.FindWithTag("HealthBarText").GetComponent<Text>();
        FredalfHealth = GameObject.FindWithTag("HealthBarText").GetComponent<Text>();
        CeryzHealth = GameObject.FindWithTag("HealthBarText").GetComponent<Text>();
        GwynMana = GameObject.FindWithTag("MPTxt").GetComponent<Text>();
        CeryzMana = GameObject.FindWithTag("MPTxt").GetComponent<Text>();
        FredalfMana = GameObject.FindWithTag("MPTxt").GetComponent<Text>();
        playerstats = GameObject.FindWithTag("Player").GetComponent<PlayerInfo>();
    }



    // Update is called once per frame
    void Gwyn()
    {
        GwynLevel.text = playerstats.playerInfo["Gwyn"].playerLevel.ToString();
        GwynHealth.text = playerstats.playerInfo["Gwyn"].health.ToString();
        GwynMana.text = playerstats.playerInfo["Gwyn"].stamina.ToString();
    }
    void Fredalf()
    {
        FredalfLevel.text = playerstats.playerInfo["Fredalf"].playerLevel.ToString();
        FredalfHealth.text = playerstats.playerInfo["Fredalf"].health.ToString();
        FredalfMana.text = playerstats.playerInfo["Fredalf"].stamina.ToString();
    }
    void Ceryz()
    {
        CeryzLevel.text = playerstats.playerInfo["Ceryz"].playerLevel.ToString();
        CeryzHealth.text = playerstats.playerInfo["Ceryz"].health.ToString();
        CeryzMana.text = playerstats.playerInfo["Ceryz"].stamina.ToString();
    }

    private void Update()
    {
        Ceryz();
        Fredalf();
        Gwyn();
    }






}
