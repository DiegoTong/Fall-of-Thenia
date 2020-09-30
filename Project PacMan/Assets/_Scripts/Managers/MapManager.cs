using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public bool tutorialComplete = false;   // Stops the Trigger from triggering the intro again
    public bool talkedToRuma = false;
    public bool talkedToGlenn = false;
    public bool breakWalls = false;         // Break the map Barriers allowing the player access to the other areas
    public bool soliseComplete = false;     // Used to Get Rid of the Solise trigger

    // E stands for Enterable
    public bool E_Tolpos = false;
    public bool E_Lokar = false;
    public bool E_Solise = false;

    public GameObject lokarTrigger;
    public GameObject TolposTrigger;
    public GameObject SoliseTrigger;
    public GameObject barrier1;
    public GameObject barrier2;
    public GameObject mainCharacter;
    public GameObject compass;
    public Camera m_camera;
    public PlayerInfo playerstats;
    // lookat Objects
    public Transform Lokar;
    public Transform Tolpos;
    public Transform Solise;

    private Scene scene;
    private WorldMap worldMap;
    private SceneTransitions sceneTransitions;

    public int minTime;
    public int maxTime;
    public int timetoWait;
    public int currentTime = 0;

    private void checkScene()
    {
        scene = SceneManager.GetActiveScene();
        checkGameObjects();
        if (scene.name == "SampleScene")
        {
            m_camera.enabled = true;
        }
        else
        {
            m_camera.enabled = false;
        }
    }

    private void compassLookAt()
    {
        if (soliseComplete != true)
        {
            Solise = GameObject.Find("Solise").GetComponent<Transform>();
            compass.transform.LookAt(Solise.transform);
        }
         else if (lokarTrigger.activeSelf == true && soliseComplete)
        {
            Lokar = GameObject.Find("Lokar").GetComponent<Transform>();
            compass.transform.LookAt(Lokar.transform);
        }
        else if(soliseComplete && talkedToGlenn && talkedToRuma != true)
        {
            Tolpos = GameObject.Find("Tolpos").GetComponent<Transform>();
            compass.transform.LookAt(Lokar.transform);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.name == "SoliseTrigger")
        {
            if (soliseComplete == false)
            {
                SoliseTrigger.SetActive(false);
                //TolposTrigger.SetActive(true);
                soliseComplete = true;

                SceneManager.LoadScene("F_BurningVillage");
            }
        }
        if (other.transform.gameObject.name == "TolposTrigger")
        {
            if (talkedToRuma == false)
            {
                talkedToRuma = true;
                SceneManager.LoadScene("F_ReturnTORuma");
            }
            else if (talkedToRuma = true && talkedToGlenn == true)
            {
                SceneManager.LoadScene("F_Fredalf");
            }
        }
        if (other.transform.gameObject.name == "LokarTrigger")
        {
            if (talkedToGlenn == false)
            {
                talkedToGlenn = true;
                SceneManager.LoadScene("F_TalkingToGlennA");
            }
        }
        if (other.transform.gameObject.name == "HealingCrystal")
        {
            Debug.Log("Healed");
            playerstats.playerInfo["Ceryz"].health = playerstats.playerInfo["Ceryz"].maxHealth;
            playerstats.playerInfo["Gwyn"].health = playerstats.playerInfo["Gwyn"].maxHealth;
            playerstats.playerInfo["Fredalf"].health = playerstats.playerInfo["Fredalf"].maxHealth;
 
        }
        if (other.transform.gameObject.name == "Cube")
        {
            sceneTransitions.LoadBossBattle();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneTransitions = GameObject.FindGameObjectWithTag("Player").GetComponent<SceneTransitions>();
        playerstats = GameObject.FindGameObjectWithTag("PlayerInfo").GetComponent<PlayerInfo>();
        scene = SceneManager.GetActiveScene();
        TolposTrigger.SetActive(true);
        SoliseTrigger.SetActive(true);
        lokarTrigger.SetActive(true);
        barrier1.SetActive(true);

        minTime = Random.Range(200, 900);
        maxTime = Random.Range(900, 1600);

        timetoWait = Random.Range(minTime, maxTime);
    }

    void randomBattle()
    {
        currentTime += 1;
        minTime = Random.Range(200, 900);
        maxTime = Random.Range(900, 1600);
        timetoWait = Random.Range(minTime, maxTime);
        if (currentTime == timetoWait && scene.name == "SampleScene")
        {
            currentTime = 0;
            sceneTransitions.loadRandomBattle();
        }

    }

    void checkGameObjects()
    {

    lokarTrigger = GameObject.Find("LokarTrigger");
    TolposTrigger = GameObject.Find("TolposTrigger");
    SoliseTrigger = GameObject.Find("SoliseTrigger");
    barrier1 = GameObject.Find("BeforeWall1");
    barrier2 = GameObject.Find("BeforeWall2");
    }
    // Update is called once per frame
    void Update()
    {
        checkScene();
        randomBattle();
        compassLookAt();
        //breakbarrier();
    }
}
