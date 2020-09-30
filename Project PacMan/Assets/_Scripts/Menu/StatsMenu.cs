using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsMenu : MonoBehaviour
{//attach this to the stats button
    PlayerInfo playerstats;
    GameInfo pi1;
    GameInfo pi2;
    private GameObject PlaceHolder;//this will be replace eventually
    private Button Button;
    private Button FredalfButton;
    private Button GwynButton;
    private Button CeryzButton;
    public int CharacterIndex;
    public GameObject StatMenu;
    public Text CharName;
    public Text CharLVL;
    public Text STRText;
    public Text INTText; 
    public Text DEFText; 
    public Text AGIText;
    public Text EXPText;
    public Text HPText;
    public Text MPText;
    public Slider HP;
    public Slider MP;
    public Image CharPortrait;


    private void Awake()
    {
        FredalfButton = GameObject.FindWithTag("Fredalf").GetComponent<Button>();
        GwynButton = GameObject.FindWithTag("Gwyn").GetComponent<Button>();
        CeryzButton = GameObject.FindWithTag("Ceryz").GetComponent<Button>();
        playerstats = GameObject.FindWithTag("Player").GetComponent <PlayerInfo>();

        STRText = GameObject.FindWithTag("STRTxt").GetComponent<Text>();
        INTText = GameObject.FindWithTag("INTTxt").GetComponent<Text>();
        DEFText = GameObject.FindWithTag("DEFTxt").GetComponent<Text>();
        AGIText = GameObject.FindWithTag("AGITxt").GetComponent<Text>();
        HPText = GameObject.FindWithTag("HPTxt").GetComponent<Text>();
        MPText = GameObject.FindWithTag("MPTxt").GetComponent<Text>();
        CharLVL = GameObject.FindWithTag("LVLTxt").GetComponent<Text>();
        CharName = GameObject.FindWithTag("CharName").GetComponent<Text>();

       // Button.onClick.AddListener(MenuStats);
       // FredalfButton.onClick.AddListener(FredalfloadStats);
        //GwynButton.onClick.AddListener(GwynloadStats);
        //CeryzButton.onClick.AddListener(CeryzloadStats);

        StatMenu = GameObject.FindWithTag("StatsMenu");
       
        

        //PlaceHolder = GameObject.FindWithTag("PlaceHolder");
        //PlaceHolder.GetComponent<MeshRenderer>().enabled = false;

    }

  //stuff that happens for each button pressed
    public void MenuStats()
    {
        Debug.Log("Stats Menu Button Pressed");

        //PlaceHolder.GetComponent<MeshRenderer>().enabled = true;

    }

   public void GwynloadStats()
    {
        STRText.text = playerstats.playerInfo["Gwyn"].power.ToString();
        INTText.text = playerstats.playerInfo["Gwyn"].magic.ToString();
        DEFText.text = playerstats.playerInfo["Gwyn"].armor.ToString();
        AGIText.text = playerstats.playerInfo["Gwyn"].speed.ToString();
        HPText.text = playerstats.playerInfo["Gwyn"].health.ToString();
        MPText.text = playerstats.playerInfo["Gwyn"].stamina.ToString();
        CharLVL.text = playerstats.playerInfo["Gwyn"].playerLevel.ToString();
        CharName.text = playerstats.playerInfo["Gwyn"].playerName.ToString();      
        
   }
    public void FredalfloadStats()
    {
        STRText.text = playerstats.playerInfo["Fredalf"].power.ToString();
        INTText.text = playerstats.playerInfo["Fredalf"].magic.ToString();
        DEFText.text = playerstats.playerInfo["Fredalf"].armor.ToString();
        AGIText.text = playerstats.playerInfo["Fredalf"].speed.ToString();
        HPText.text = playerstats.playerInfo["Fredalf"].health.ToString();
        MPText.text = playerstats.playerInfo["Fredalf"].stamina.ToString();
        CharLVL.text = playerstats.playerInfo["Fredalf"].playerLevel.ToString();
        CharName.text = playerstats.playerInfo["Fredalf"].playerName.ToString();      
        
   }

    public void CeryzloadStats()
    {
        STRText.text = playerstats.playerInfo["Ceryz"].power.ToString();
        INTText.text = playerstats.playerInfo["Ceryz"].magic.ToString();
        DEFText.text = playerstats.playerInfo["Ceryz"].armor.ToString();
        AGIText.text = playerstats.playerInfo["Ceryz"].speed.ToString();
        HPText.text = playerstats.playerInfo["Ceryz"].health.ToString();
        MPText.text = playerstats.playerInfo["Ceryz"].stamina.ToString();
        CharLVL.text = playerstats.playerInfo["Ceryz"].playerLevel.ToString();
        CharName.text = playerstats.playerInfo["Ceryz"].playerName.ToString();
    }


}
