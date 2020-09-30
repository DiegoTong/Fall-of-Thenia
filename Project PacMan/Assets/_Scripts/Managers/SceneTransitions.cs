/* Script is used to transition from world to world and from world to battles.
   Need to Add Saving for Scene states to revert from combat back to previous World State.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    Scene scene;
    GameObject trigger;
    EnemyEncounter enemyEncounter;
    public Animator animator;

    GameObject audioManager;
    AudioManager audioManagerScript;

    public void NewGame()
    {
        FadeToLevel();
        StartCoroutine(newGame());
    }

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOuttrigger");
    }

    IEnumerator newGame()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //grabs the first scene in the build index
    }
    // Start is called before the first frame update
    void Start()
    {

        audioManager = GameObject.Find("AudioManager"); //Setup for Audio Manager
        audioManagerScript = audioManager.GetComponent<AudioManager>();                    //Going to add a Transition Theme to play between each scene loads if possible.

        // Sound Manager calls Main Menu Music
        audioManagerScript.PlayMusic(1, "Location");

         
        // Used to compare scenes and transition
        scene = SceneManager.GetActiveScene();

        // Use to get the enemy encounter code
        enemyEncounter = GameObject.FindGameObjectWithTag("EnemyEncounter").GetComponent<EnemyEncounter>();
    }

    void OnTriggerEnter(Collider other)
    {
        // "SampleScene" Will Be Replaced with the world Scenes. 
        //Additional If Statements needed for each individual World

        // Need Additional "WorldTrigger" for a Transition to New Worlds
        // "Trigger" will Change to "EnemyTrigger" For Combat Scene Transition
        if (scene.name == "SampleScene" && other.transform.gameObject.name == "Trigger") // To work the object the player collides with must be called Trigger
        {
            var randomNum = Random.Range(1, 4); // Random number bewtween 1-3 to decide how many enemies the player will face
            enemyEncounter.NumberOfEnemies(3,1);
            SceneManager.LoadScene("BattleScene"); // On Collision Transition to the proper Battle Scene. 
            audioManagerScript.PlayMusic(0, "Combat");

        }
        else if (scene.name == "SampleScene" && other.transform.gameObject.name == "VillageTrigger") // To work the object the player collides with must be called Trigger
        {
            var randomNum = Random.Range(1, 4); // Random number bewtween 1-3 to decide how many enemies the player will face
            enemyEncounter.NumberOfEnemies(4,1);
            SceneManager.LoadScene("BattleScene"); // On Collision Transition to the proper Battle Scene.

            //What Scene is this?
            audioManagerScript.PlayMusic(0, "Combat");

        }
        else if (scene.name == "SampleScene" && other.transform.gameObject.name == "TriggerBoss") // To work the object the player collides with must be called Trigger
        {
            enemyEncounter.NumberOfEnemies(4,1);
            SceneManager.LoadScene("BattleScene"); // On Collision Transition to the proper Battle Scene. 
            audioManagerScript.PlayMusic(0, "Boss");
            
        }
        else if (scene.name == "BattleScene" && other.transform.gameObject.name == "Trigger")
        {
            SceneManager.LoadScene("SampleScene");
            audioManagerScript.PlayMusic(0, "Location");
        }
    }

    public void LoadTutorialScene()
    {
        var randomNum = Random.Range(1, 2); // Random number bewtween 1-3 to decide how many enemies the player will face
        enemyEncounter.NumberOfEnemies(1,2);
        SceneManager.LoadScene("BattleScene"); // On Collision Transition to the proper Battle Scene. 
        audioManagerScript.PlayMusic(0, "Combat");//Putting Basic Combat Music Just to fill space
    }

    public void loadRandomBattle()
    {
        var randomNum = Random.Range(1, 4); // Random number bewtween 1-3 to decide how many enemies the player will face
        enemyEncounter.NumberOfEnemies(randomNum, 1);
        SceneManager.LoadScene("BattleScene");
    }

    public void LoadSoliceBattleScene()
    {
        enemyEncounter.NumberOfEnemies(3, 3);
        SceneManager.LoadScene("BattleScene"); // On Collision Transition to the proper Battle Scene. 
        audioManagerScript.PlayMusic(0, "Combat"); //Putting Basic Combat Music Just to fill space
    }

    public void LoadBossBattle()
    {
        enemyEncounter.NumberOfEnemies(4, 3);
        SceneManager.LoadScene("BattleScene"); // On Collision Transition to the proper Battle Scene. 
        audioManagerScript.PlayMusic(1, "Boss"); //Putting Basic Combat Music Just to fill space
    }

    public void onDeath()
    {
        SceneManager.LoadScene("MainMenu");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
