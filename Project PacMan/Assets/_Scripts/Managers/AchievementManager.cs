using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{

    [Header("Achievements")]

    public int combatEncounters = 0;  //Various achivements.  Public to allow testing

    public int skillsUsed = 0;

    public int BasicAttacks = 0;

    public int Something2 = 0;

    public int Something3 = 0;


    [Header("Achievements: True = Aquired")]

    public bool achievement1 = false; //Public for testing or presentation purposes

    public bool achievement2 = false;

    public bool achievement3 = false;

    public bool achievement4 = false;

    public bool achievement5 = false;

    public bool achievement6 = false;





    public static AchievementManager instance = null;

    public static AchievementManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void AchivementTracker(string Achievement)
    {
        if(Achievement == "CombatEncounters")
        {
            if (combatEncounters < 10)
            {
                combatEncounters++;
            }
            else
            {
                achievement1 = true;
            }
        }
        else if (Achievement == "SkillsUsed")
        {
            if (skillsUsed < 10)
            {
                skillsUsed++;
            }
            else
            {
                achievement2 = true;
            }
        }
        else //Add more when required
        {
            Debug.Log("Invalid Achivement.  Please use either 'CombatEncounters', 'SkillsUsed', or :IN PROGRESS:");
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
