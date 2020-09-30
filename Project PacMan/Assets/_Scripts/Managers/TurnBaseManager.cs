using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnBaseManager : MonoBehaviour
{
    public GameObject player;
    GameObject Fredalf;
    GameObject gwyn;
    GameObject Ceryz;
    public PlayerInfo playerstats;
    EnemyAI enemyAI;
    Sliders healthBar;
    Sliders manaBar;
    public Ability playerUsedAbility;
    private int damage;
    public static int turnCount;
    int orderFor2;
    public static bool playerEndTurn;
    public static bool enemyEndTurn;
    public GameInfo activePlayer;
    PlayerStats activeEnemy;
    public EnemyEncounter enemyEncounter;
    GameObject enemyObject1;
    GameObject enemyObject2;
    GameObject enemyObject3;
    GameObject bossObject;
    GameObject enemySliders1;
    GameObject enemySliders2;
    GameObject enemySliders3;
    GameObject GwynHealthBar;
    GameObject FredalfHealthBar;
    GameObject CeryzHealthBar;
    GameObject bossSliders;
    public GameObject e1;
    public GameObject e2;
    public GameObject e3;
    public GameObject e4;
    public GameObject i1;
    public GameObject i2;
    public GameObject i3;
    public GameObject i4;
    public GameObject i5;
    public GameObject revivalButton1;
    public GameObject revivalButton2;
    public GameObject revivalButton3;
    GameObject audioManager;
    SpriteManager spriteManagerScript;
    AudioManager audioManagerScript;
    diegoinventory inventory;
    public enum BattleStates
    {
        START,
        PLAYERCHOICE,
        ENEMYCHOICE,
        ENDTURN,
        LOSE,
        WIN
    }

    private BattleStates currentState;
    // Start is called before the first frame update
    void Start()
    {

        turnCount = 1;
        orderFor2 = 1;
        playerEndTurn = false;
        enemyEndTurn = false;
        currentState = BattleStates.START;
        audioManager = GameObject.Find("AudioManager");
        audioManagerScript = audioManager.GetComponent<AudioManager>();
        player = GameObject.FindGameObjectWithTag("PlayerInfo");
        Fredalf = GameObject.FindGameObjectWithTag("PotatoGirl");
        gwyn = GameObject.FindGameObjectWithTag("Gwyn");
        Ceryz = GameObject.FindGameObjectWithTag("Ceryz");
        playerstats = player.GetComponent<PlayerInfo>();
        enemyEncounter = GameObject.FindGameObjectWithTag("EnemyEncounter").GetComponent<EnemyEncounter>();
        spriteManagerScript = GameObject.FindGameObjectWithTag("SpriteManager").GetComponent<SpriteManager>();
        spriteManagerScript.bakcgroundChange(enemyEncounter.encounterID);
        activeEnemy = new PlayerStats(true, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        activePlayer = new GameInfo("0", 0, 0, 0, 0, 0, 0, 0, 0, 0,0, new Attack());
        enemyAI = new EnemyAI();
        healthBar = GameObject.FindGameObjectWithTag("healthBar").GetComponent<Sliders>();
        manaBar = GameObject.FindGameObjectWithTag("ManaBar").GetComponent<Sliders>();
        playerstats.playerAbilities.Add(new Attack());
        playerstats.playerAbilities.Add(new SpecialAttack());
        enemyObject1 = GameObject.FindGameObjectWithTag("EnemyUnit1");
        enemyObject2 = GameObject.FindGameObjectWithTag("EnemyUnit2");
        enemyObject3 = GameObject.FindGameObjectWithTag("EnemyUnit3");
        enemySliders1 = GameObject.FindGameObjectWithTag("EnemySlider1");
        enemySliders2 = GameObject.FindGameObjectWithTag("EnemySlider2");
        enemySliders3 = GameObject.FindGameObjectWithTag("EnemySlider3");
        GwynHealthBar = GameObject.FindGameObjectWithTag("Slider1");
        FredalfHealthBar = GameObject.FindGameObjectWithTag("Slider2");
        CeryzHealthBar = GameObject.FindGameObjectWithTag("Slider3");
        bossObject = GameObject.FindGameObjectWithTag("Boss");
        bossSliders = GameObject.FindGameObjectWithTag("BossSlider");
        inventory = player.GetComponent<diegoinventory>();
        ActivateEnemies();
        setActiveEnemy(turnCount, enemyEncounter.numberOfEncoutners);
        sortHeroesBySpeed();
        setActivePlayer(turnCount);
        removeSliders();
    }

    // Update is called once per frame
    void Update()
    {

        switch (currentState)
        {
            case (BattleStates.START):
                playerEndTurn = false;
                enemyEndTurn = false;
                healthBar.showHealth(activePlayer);
                healthBar.showHealth(playerstats.playerInfo["Ceryz"]);
                healthBar.showHealth(playerstats.playerInfo["Gwyn"]);
                healthBar.showHealth(playerstats.playerInfo["Fredalf"]);
                manaBar.showMana(activePlayer);
                healthBar.enemyHealth(activeEnemy);
                ChooseWHoGoesFirst();
                break;
            case (BattleStates.PLAYERCHOICE):
                CheckIfDead();
                healthBar.showHealth(activePlayer);
                manaBar.showMana(activePlayer);
                healthBar.enemyHealth(activeEnemy);
                // Enable Buttons
                break;
            case (BattleStates.ENEMYCHOICE):
                enemyAI.EnemyDoesAction();
                healthBar.showHealth(activePlayer);
                manaBar.showMana(activePlayer);
                healthBar.enemyHealth(activeEnemy);
                CheckIfDead();
                ChooseWhoGoesNext();
                break;
            case (BattleStates.ENDTURN):
                UpdateCharacter(turnCount);
                //  UpdateEnemy(turnCount);
                turnCount++;
                if (turnCount > 3)
                {
                    turnCount = 1;
                }
                Debug.Log(turnCount + "Turn Count");
                setActivePlayer(turnCount);
                setActiveEnemy(turnCount, enemyEncounter.numberOfEncoutners);
                CheckIfDead();
                healthBar.showHealth(activePlayer);
                manaBar.showMana(activePlayer);
                healthBar.enemyHealth(activeEnemy);
                playerEndTurn = false;
                enemyEndTurn = false;
                ChooseWHoGoesFirst();
                break;
            case (BattleStates.LOSE):
                enemyEncounter.ClearEnemies();
                playerstats.playerInfo["Gwyn"].power = 20;
                playerstats.playerInfo["Gwyn"].armor = 0;
                playerstats.playerInfo["Ceryz"].power = 10;
                playerstats.playerInfo["Ceryz"].armor = 10;
                playerstats.playerInfo["Fredalf"].power = 10;
                playerstats.playerInfo["Fredalf"].armor = 0;

                playerstats.playerInfo["Gwyn"].health = 110;
                playerstats.playerInfo["Gwyn"].magic = 50;
                playerstats.playerInfo["Ceryz"].health = 90;
                playerstats.playerInfo["Ceryz"].magic = 50;
                playerstats.playerInfo["Fredalf"].health = 120;
                playerstats.playerInfo["Fredalf"].magic = 50;
                SceneManager.LoadScene("DeathScene");
                break;
            case (BattleStates.WIN):
                enemyEncounter.ClearEnemies();
                playerstats.playerInfo["Gwyn"].power = 20;
                playerstats.playerInfo["Gwyn"].armor = 0;
                playerstats.playerInfo["Ceryz"].power = 10;
                playerstats.playerInfo["Ceryz"].armor = 10;
                playerstats.playerInfo["Fredalf"].power = 10;
                playerstats.playerInfo["Fredalf"].armor = 0;
                if (enemyEncounter.encounterID == 2)
                {
                    audioManagerScript.PlayMusic(1, "Location");
                   SceneManager.LoadScene("F_Afterscene");
                }
                else if (enemyEncounter.encounterID == 3)
                {
                    audioManagerScript.PlayMusic(1, "Location");
                    SceneManager.LoadScene("F_SoliseEpilogue");
                }
                else if(enemyEncounter.encounterID == 4)
                {
                    audioManagerScript.PlayMusic(1, "Location");
                    SceneManager.LoadScene("F_ForestEpilogue");
                }
                else
                {
                    SceneManager.LoadScene("SampleScene");
                }

                break;
        }
    }

    void ChooseWHoGoesFirst()
    {
        if (activePlayer.speed >= activeEnemy.speed)
        {
            currentState = BattleStates.PLAYERCHOICE;
        }
        else
        {
            currentState = BattleStates.ENEMYCHOICE;
        }
    }

    public void ChooseAttack()
    {
        if (enemyEncounter.enemyParty[1].health > 0 && enemyEncounter.enemyParty[1].id == 0)
        {
            e1.SetActive(true);
            //Sound Manager Code     
        }
        else
        {
            e1.SetActive(false);
        }
        if (enemyEncounter.enemyParty[2].health > 0)
        {
            e2.SetActive(true);
        }
        else
        {
            e2.SetActive(false);
        }
        if (enemyEncounter.enemyParty[3].health > 0)
        {
            e3.SetActive(true);
        }
        else
        {
            e3.SetActive(false);
        }
        if(enemyEncounter.enemyParty[1].health > 0 && enemyEncounter.enemyParty[1].id == 1)
        {
            e4.SetActive(true);
        }
        else
        {
            e4.SetActive(false);
        }
    }

    public void AttackEnemy1()
    {
        playerUsedAbility = playerstats.playermove1;
        CombatBasic();
        CalculatingPlayerDamage(playerUsedAbility, enemyEncounter.enemyParty[1]);
    }
    public void AttackEnemy2()
    {
        playerUsedAbility = playerstats.playermove1;
        CombatBasic();
        CalculatingPlayerDamage(playerUsedAbility, enemyEncounter.enemyParty[2]);
    }
    public void AttackEnemy3()
    {
        playerUsedAbility = playerstats.playermove1;
        CombatBasic();
        CalculatingPlayerDamage(playerUsedAbility, enemyEncounter.enemyParty[3]);
    }
    public void AttackBoss()
    {
        playerUsedAbility = playerstats.playermove1;
        CombatBasic();
        CalculatingPlayerDamage(playerUsedAbility, activeEnemy);
    }
   public void useItem()
    {
        if (inventory.Items["Potion"].quantity > 0)
        {
            i1.SetActive(true);
            //Sound Manager Code     
        }
        else
        {
            i1.SetActive(false);
        }
        if (inventory.Items["RevivalShard"].quantity > 0)
        {
            i2.SetActive(true);
        }
        else
        {
            i2.SetActive(false);
        }
        if (inventory.Items["CrystalShard"].quantity > 0)
        {
            i3.SetActive(true);
        }
        else
        {
            i3.SetActive(false);
        }
        if (inventory.Items["MegaPotion"].quantity > 0)
        {
            i4.SetActive(true);
        }
        else
        {
            i4.SetActive(false);
        }
        if (inventory.Items["MegaCrystalShard"].quantity > 0)
        {
            i5.SetActive(true);
        }
        else
        {
            i5.SetActive(false);
        }
    }
    public void item1()
    {
        if(inventory.Items["Potion"].quantity > 0)
        {
            if (activePlayer.health == activePlayer.maxHealth)
            {
                playerEndTurn = true;
                ChooseWhoGoesNext();
            }
            else
            {
                activePlayer.health = activePlayer.health + inventory.Items["Potion"].itemPower;
                if(activePlayer.health>=activePlayer.maxHealth)
                {
                    activePlayer.health = activePlayer.maxHealth;
                }
                inventory.Items["Potion"].quantity = inventory.Items["Potion"].quantity - 1;
                playerEndTurn = true;
                ChooseWhoGoesNext();
            }
            
        }
    }
    public void item2CheckLife()
    {
        if(playerstats.playerInfo["Gwyn"].health <0)
        {
            revivalButton1.SetActive(true);
        }
        else
        {
            revivalButton1.SetActive(false);
        }
        if (playerstats.playerInfo["Fredalf"].health < 0)
        {
            revivalButton2.SetActive(true);
        }
        else
        {
            revivalButton2.SetActive(false);
        }
        if (playerstats.playerInfo["Ceryz"].health < 0)
        {
            revivalButton3.SetActive(true);
        }
        else
        {
            revivalButton3.SetActive(false);
        }
    }
    public void item2Gwyn()
    {
        if (inventory.Items["RevivalShard"].quantity > 0)
        {
            if (playerstats.playerInfo["Gwyn"].health == playerstats.playerInfo["Gwyn"].maxHealth)
            {
                inventory.Items["RevivalShard"].quantity = inventory.Items["RevivalShard"].quantity - 1;
                playerEndTurn = true;
                ChooseWhoGoesNext();
            }
        }
    }
    public void item2Fredalf()
    {
        if (inventory.Items["RevivalShard"].quantity > 0)
        {
            if (playerstats.playerInfo["Fredalf"].health == playerstats.playerInfo["Fredalf"].maxHealth)
            {
                inventory.Items["RevivalShard"].quantity = inventory.Items["RevivalShard"].quantity - 1;
                playerEndTurn = true;
                ChooseWhoGoesNext();
            }
        }
    }
    public void item2Ceryz()
    {
        if (inventory.Items["RevivalShard"].quantity > 0)
        {
            if (playerstats.playerInfo["Ceryz"].health == playerstats.playerInfo["Ceryz"].maxHealth)
            {
                inventory.Items["RevivalShard"].quantity = inventory.Items["RevivalShard"].quantity - 1;
                playerEndTurn = true;
                ChooseWhoGoesNext();
            }
        }
    }
    public void item3()
    {
        if (inventory.Items["CrystalShard"].quantity > 0)
        {
            if (activePlayer.magic == 50)
            {
                playerEndTurn = true;
                ChooseWhoGoesNext();
            }
            else
            {
                activePlayer.magic = activePlayer.magic + inventory.Items["CrystalShard"].itemPower;
                if (activePlayer.magic >= 50)
                {
                    activePlayer.health = 50;
                }
                inventory.Items["CrystalShard"].quantity = inventory.Items["CrystalShard"].quantity - 1;
                playerEndTurn = true;
                ChooseWhoGoesNext();
            }
        }
    }

    public void item4()
    {
        if (inventory.Items["MegaPotion"].quantity > 0)
        {
            if (activePlayer.health == activePlayer.maxHealth)
            {
                playerEndTurn = true;
                ChooseWhoGoesNext();
            }
            else
            {
                activePlayer.health = activePlayer.health + inventory.Items["MegaPotion"].itemPower;
                if (activePlayer.health >= activePlayer.maxHealth)
                {
                    activePlayer.health = activePlayer.maxHealth;
                }
                inventory.Items["MegaPotion"].quantity = inventory.Items["MegaPotion"].quantity - 1;
                playerEndTurn = true;
                ChooseWhoGoesNext();
            }
        }
    }
    public void item5()
    {
        if (inventory.Items["MegaCrystalShard"].quantity > 0)
        {
            if (activePlayer.magic == 50)
            {
                playerEndTurn = true;
                ChooseWhoGoesNext();
            }
            else
            {
                activePlayer.magic = activePlayer.magic + inventory.Items["MegaCrystalShard"].itemPower;
                if (activePlayer.magic >= 50)
                {
                    activePlayer.health = 50;
                }
                inventory.Items["MegaCrystalShard"].quantity = inventory.Items["MegaCrystalShard"].quantity - 1;
                playerEndTurn = true;
                ChooseWhoGoesNext();
            }
        }
    }
    public void skill1()                                                                                                                                               //Skils
    {
        if (activePlayer.playerName == playerstats.playerInfo["Gwyn"].playerName)
        {
            if ((activePlayer.magic - activePlayer.playerAbility.AbilityCost) >= 0)
            {
                playerUsedAbility = new TargetShot();
                activePlayer.magic = activePlayer.magic - playerUsedAbility.AbilityCost;
                activeEnemy.health = activeEnemy.health - playerUsedAbility.AbilityPower;
                healthBar.enemyHealth(activeEnemy);
                playerEndTurn = true;
                ChooseWhoGoesNext();
            }
            else
            {
                playerEndTurn = true;
                ChooseWhoGoesNext();
            }
        }
        if (activePlayer.playerName == playerstats.playerInfo["Fredalf"].playerName)
        {
            if ((activePlayer.magic - activePlayer.playerAbility.AbilityCost) >= 0)
            {
                playerUsedAbility = new ToArms();
                activePlayer.magic = activePlayer.magic - playerUsedAbility.AbilityCost;
                if (enemyEncounter.enemyParty[1].health > 0)
                {
                    enemyEncounter.enemyParty[1].health = enemyEncounter.enemyParty[1].health - playerUsedAbility.AbilityPower;
                    healthBar.enemyHealth(enemyEncounter.enemyParty[1]);
                }
                if (enemyEncounter.enemyParty[2].health > 0)
                {
                    enemyEncounter.enemyParty[2].health = enemyEncounter.enemyParty[2].health - playerUsedAbility.AbilityPower;
                    healthBar.enemyHealth(enemyEncounter.enemyParty[2]);
                }
                if (enemyEncounter.enemyParty[3].health > 0)
                {
                    enemyEncounter.enemyParty[3].health = enemyEncounter.enemyParty[3].health - playerUsedAbility.AbilityPower;
                    healthBar.enemyHealth(enemyEncounter.enemyParty[3]);
                }
                playerEndTurn = true;
                ChooseWhoGoesNext();
            }
            else
            {
                playerEndTurn = true;
                ChooseWhoGoesNext();
            }
        }
        if (activePlayer.playerName == playerstats.playerInfo["Ceryz"].playerName)
        {
            if ((activePlayer.magic - activePlayer.playerAbility.AbilityCost) >= 0)
            {
                playerUsedAbility = new FireBall();
                activePlayer.magic = activePlayer.magic - playerUsedAbility.AbilityCost;
                if (enemyEncounter.enemyParty[1].health > 0)
                {
                    enemyEncounter.enemyParty[1].health = enemyEncounter.enemyParty[1].health - playerUsedAbility.AbilityPower;
                    healthBar.enemyHealth(enemyEncounter.enemyParty[1]);
                }
                if (enemyEncounter.enemyParty[2].health > 0)
                {
                    enemyEncounter.enemyParty[2].health = enemyEncounter.enemyParty[2].health - playerUsedAbility.AbilityPower;
                    healthBar.enemyHealth(enemyEncounter.enemyParty[2]);
                }
                if (enemyEncounter.enemyParty[3].health > 0)
                {
                    enemyEncounter.enemyParty[3].health = enemyEncounter.enemyParty[3].health - playerUsedAbility.AbilityPower;
                    healthBar.enemyHealth(enemyEncounter.enemyParty[3]);
                }
                playerEndTurn = true;
                ChooseWhoGoesNext();
            }
            else
            {
                playerEndTurn = true;
                ChooseWhoGoesNext();
            }
        }
    }
    public void skill2()
    {
 
    if (activePlayer.playerName == playerstats.playerInfo["Gwyn"].playerName)
    {
        playerUsedAbility = new Reload();
        activePlayer.magic = activePlayer.magic + playerUsedAbility.AbilityPower;   
            if(activePlayer.magic >=50)
            {
                activePlayer.magic = 50;
            }
            manaBar.showMana(activePlayer);
            playerEndTurn = true;
        ChooseWhoGoesNext();
    }
    if (activePlayer.playerName == playerstats.playerInfo["Fredalf"].playerName)
    {
    if ((activePlayer.magic - activePlayer.playerAbility.AbilityCost) >= 0)
    {
    playerUsedAbility = new Rally();
    activePlayer.magic = activePlayer.magic - playerUsedAbility.AbilityCost;
    if (playerstats.playerInfo["Ceryz"].health > 0)
    {
    playerstats.playerInfo["Ceryz"].armor = playerstats.playerInfo["Ceryz"].armor + playerUsedAbility.AbilityPower;
    healthBar.showHealth(playerstats.playerInfo["Ceryz"]);
    }
    if (playerstats.playerInfo["Gwyn"].health > 0)
    {
    playerstats.playerInfo["Gwyn"].armor = playerstats.playerInfo["Gwyn"].armor + playerUsedAbility.AbilityPower;
    healthBar.showHealth(playerstats.playerInfo["Gwyn"]);
    }
    if (playerstats.playerInfo["Fredalf"].health > 0)
    {
    playerstats.playerInfo["Fredalf"].armor = playerstats.playerInfo["Fredalf"].armor + playerUsedAbility.AbilityPower;
    healthBar.showHealth(playerstats.playerInfo["Fredalf"]);
    }
    playerEndTurn = true;
    ChooseWhoGoesNext();
    }
    else
    {
    playerEndTurn = true;
    ChooseWhoGoesNext();
    }
    }
    if (activePlayer.playerName == playerstats.playerInfo["Ceryz"].playerName)
    {
    if ((activePlayer.magic - activePlayer.playerAbility.AbilityCost) >= 0)
    {
        playerUsedAbility = new TargetHealing();
    activePlayer.magic = activePlayer.magic - playerUsedAbility.AbilityCost;
    if (playerstats.playerInfo["Ceryz"].health < playerstats.playerInfo["Ceryz"].maxHealth)
    {
    playerstats.playerInfo["Ceryz"].health = playerstats.playerInfo["Ceryz"].health + playerUsedAbility.AbilityPower;
    healthBar.showHealth(playerstats.playerInfo["Ceryz"]);
    }
    if(playerstats.playerInfo["Ceryz"].health >= playerstats.playerInfo["Ceryz"].maxHealth)
    {
      playerstats.playerInfo["Ceryz"].health = playerstats.playerInfo["Ceryz"].maxHealth;
    }
        playerEndTurn = true;
        ChooseWhoGoesNext();
    }
    else
    {
        playerEndTurn = true;
        ChooseWhoGoesNext();
    }
    }
    }
    public void skill3()
    {
            if (activePlayer.playerName == playerstats.playerInfo["Gwyn"].playerName)
            {
            if ((activePlayer.magic - activePlayer.playerAbility.AbilityCost) >= 0)
            {
                playerUsedAbility = new EndlessBarrage();
                activePlayer.magic = activePlayer.magic - playerUsedAbility.AbilityCost;
                if (enemyEncounter.enemyParty[1].health > 0)
                {
                    enemyEncounter.enemyParty[1].health = enemyEncounter.enemyParty[1].health - playerUsedAbility.AbilityPower;
                    healthBar.enemyHealth(enemyEncounter.enemyParty[1]);
                }
                if (enemyEncounter.enemyParty[2].health > 0)
                {
                    enemyEncounter.enemyParty[2].health = enemyEncounter.enemyParty[2].health - playerUsedAbility.AbilityPower;
                    healthBar.enemyHealth(enemyEncounter.enemyParty[2]);
                }
                if (enemyEncounter.enemyParty[3].health > 0)
                {
                    enemyEncounter.enemyParty[3].health = enemyEncounter.enemyParty[3].health - playerUsedAbility.AbilityPower;
                    healthBar.enemyHealth(enemyEncounter.enemyParty[3]);
                }

                playerEndTurn = true;
                ChooseWhoGoesNext();
            }
            else
            {
                playerEndTurn = true;
                ChooseWhoGoesNext();
            }
        }
            if (activePlayer.playerName == playerstats.playerInfo["Fredalf"].playerName)
            {
                if ((activePlayer.magic - activePlayer.playerAbility.AbilityCost) >= 0)
                {
                    playerUsedAbility = new WarCry();
                activePlayer.magic = activePlayer.magic - playerUsedAbility.AbilityCost;
                if (playerstats.playerInfo["Ceryz"].health > 0)
                {
                    playerstats.playerInfo["Ceryz"].power = playerstats.playerInfo["Ceryz"].power + playerUsedAbility.AbilityPower;
                    healthBar.showHealth(playerstats.playerInfo["Ceryz"]);
                }
                if (playerstats.playerInfo["Gwyn"].health > 0)
                {
                    playerstats.playerInfo["Gwyn"].power = playerstats.playerInfo["Gwyn"].power + playerUsedAbility.AbilityPower;
                    healthBar.showHealth(playerstats.playerInfo["Gwyn"]);
                }
                if (playerstats.playerInfo["Fredalf"].health > 0)
                {
                    playerstats.playerInfo["Fredalf"].power = playerstats.playerInfo["Fredalf"].power + playerUsedAbility.AbilityPower;
                    healthBar.showHealth(playerstats.playerInfo["Fredalf"]);
                }
                playerEndTurn = true;
                ChooseWhoGoesNext();
                }
                else
                {
                    playerEndTurn = true;
                    ChooseWhoGoesNext();
                }
            }
            if (activePlayer.playerName == playerstats.playerInfo["Ceryz"].playerName)
            {
                    if ((activePlayer.magic - activePlayer.playerAbility.AbilityCost) >= 0)
                    {
                        playerUsedAbility = new HollyHealing();
                activePlayer.magic = activePlayer.magic - playerUsedAbility.AbilityCost;
                if (playerstats.playerInfo["Ceryz"].health > 0)
                {
                    playerstats.playerInfo["Ceryz"].health = playerstats.playerInfo["Ceryz"].health + playerUsedAbility.AbilityPower;
                    if (playerstats.playerInfo["Ceryz"].health >= playerstats.playerInfo["Ceryz"].maxHealth)
                    {
                        playerstats.playerInfo["Ceryz"].health = playerstats.playerInfo["Ceryz"].maxHealth;
                    }
                    healthBar.showHealth(playerstats.playerInfo["Ceryz"]);
                }
                if (playerstats.playerInfo["Gwyn"].health > 0)
                {
                    playerstats.playerInfo["Gwyn"].health = playerstats.playerInfo["Gwyn"].health + playerUsedAbility.AbilityPower;
                    if (playerstats.playerInfo["Gwyn"].health >= playerstats.playerInfo["Gwyn"].maxHealth)
                    {
                        playerstats.playerInfo["Gwyn"].health = playerstats.playerInfo["Gwyn"].maxHealth;
                    }
                    healthBar.showHealth(playerstats.playerInfo["Gwyn"]);
                }
                if (playerstats.playerInfo["Fredalf"].health > 0)
                {
                    playerstats.playerInfo["Fredalf"].health = playerstats.playerInfo["Fredalf"].health + playerUsedAbility.AbilityPower;
                    if (playerstats.playerInfo["Fredalf"].health >= playerstats.playerInfo["Fredalf"].maxHealth)
                    {
                        playerstats.playerInfo["Fredalf"].health = playerstats.playerInfo["Fredalf"].maxHealth;
                    }
                    healthBar.showHealth(playerstats.playerInfo["Fredalf"]);
                }

                playerEndTurn = true;
                ChooseWhoGoesNext();
                    }
                    else
                    {
                        playerEndTurn = true;
                        ChooseWhoGoesNext();
                    }
                }


    }
    public void ChooseSkill()
    {
        if (activePlayer.id ==1)
        {
            spriteManagerScript.changeSpriteGwyn();
        }
        if(activePlayer.id ==2)
        {
            spriteManagerScript.changeSpriteFredalf();
        }
        if(activePlayer.id ==3)
        {
            spriteManagerScript.changeSpriteCeryz();
        }
    }
    public void ChooseWhoGoesNext()
    {
        if (activePlayer.health > 0)
        {
            if (playerEndTurn == true && enemyEndTurn == false)
            {
                currentState = BattleStates.ENEMYCHOICE;
            }
            if (!playerEndTurn == false && enemyEndTurn == true)
            {
                currentState = BattleStates.PLAYERCHOICE;
            }
            if (playerEndTurn == true && enemyEndTurn == true)
            {
                currentState = BattleStates.ENDTURN;
            }
        }
        else
        {
            CheckIfDead();
        }
    }

    public void CalculatingPlayerDamage(Ability usedAbility, PlayerStats target)
    // public void CalculatingPlayerDamage(Ability usedAbility, int targetID)
    {
        if (activePlayer.playerName == playerstats.playerInfo["Gwyn"].playerName)
        {
            damage = playerstats.playerInfo["Gwyn"].power + usedAbility.AbilityPower; // - target.armor
        }
        else if (activePlayer.playerName == playerstats.playerInfo["Fredalf"].playerName)
        {
            damage = playerstats.playerInfo["Fredalf"].power + usedAbility.AbilityPower; // - target.armor
        }
        else if (activePlayer.playerName == playerstats.playerInfo["Ceryz"].playerName)
        {
            damage = playerstats.playerInfo["Ceryz"].power + usedAbility.AbilityPower; // - target.armor
        }
        //if (targetID == 1)
        //{
        //    enemyEncounter.enemyParty[1].health = enemyEncounter.enemyParty[1].health - damage + enemyEncounter.enemyParty[1].armor;
        //    healthBar.enemyHealth(enemyEncounter.enemyParty[1]);
        //}
        //else if (targetID == 2)
        //{
        //    enemyEncounter.enemyParty[2].health = enemyEncounter.enemyParty[2].health - damage + enemyEncounter.enemyParty[2].armor;
        //    healthBar.enemyHealth(enemyEncounter.enemyParty[2]);
        //}
        //else if (targetID == 3)
        //{
        //    enemyEncounter.enemyParty[3].health = enemyEncounter.enemyParty[3].health - damage + enemyEncounter.enemyParty[3].armor;
        //    healthBar.enemyHealth(enemyEncounter.enemyParty[3]);
        //}
        target.health = target.health - damage;
        healthBar.enemyHealth(target);
        Debug.Log("Damage" + damage);
        //if (target.id == 0 && target.order == 1)
        //{
        //    enemyEncounter.enemyParty[1] = target;
        //}
        //else if (target.id == 0 && target.order == 2)
        //{
        //    enemyEncounter.enemyParty[2] = target;
        //}
        //else if (target.id == 0 && target.order == 3)
        //{
        //    enemyEncounter.enemyParty[3] = target;
        //}
        damage = 0;
        //targetID = 0;
        playerEndTurn = true;
        ChooseWhoGoesNext();
    }

    public void CheckIfDead()
    {
        if (playerstats.playerInfo["Gwyn"].health <= 0)
        {
            gwyn.SetActive(false);
            GwynHealthBar.SetActive(false);
            activePlayer = playerstats.playerInfo["Fredalf"];
        }
        if (playerstats.playerInfo["Fredalf"].health <= 0)
        {
            Fredalf.SetActive(false);
            FredalfHealthBar.SetActive(false);
            activePlayer = playerstats.playerInfo["Ceryz"];
        }
        if (playerstats.playerInfo["Ceryz"].health <= 0)
        {
            Ceryz.SetActive(false);
            CeryzHealthBar.SetActive(false);
            activePlayer = playerstats.playerInfo["Gwyn"];
        }
        if (playerstats.playerInfo["Gwyn"].health <= 0 && playerstats.playerInfo["Fredalf"].health <= 0 && playerstats.playerInfo["Ceryz"].health <= 0)
        {
            currentState = BattleStates.LOSE;
        }
        if (enemyEncounter.enemyParty[1].id == 1)
        {
            if (enemyEncounter.enemyParty[1].health <= 0)
            {
                bossObject.SetActive(false);
                bossSliders.SetActive(false);
                currentState = BattleStates.WIN;
            }
            else
            {
                activeEnemy = enemyEncounter.enemyParty[1];
            }
        }
        else
        {
            if (enemyEncounter.enemyParty[1].health <= 0)
            {
                enemyObject1.SetActive(false);
                enemySliders1.SetActive(false);
            }
            if (enemyEncounter.enemyParty[2].health <= 0)
            {
                enemyObject2.SetActive(false);
                enemySliders2.SetActive(false);
            }
            if (enemyEncounter.enemyParty[3].health <= 0)
            {
                enemyObject3.SetActive(false);
                enemySliders3.SetActive(false);
            }
            //if (enemyEncounter.enemyParty[1].health <= 0)
            //{
            //    activeEnemy = enemyEncounter.enemyParty[2];
            //}
            //if (enemyEncounter.enemyParty[2].health <= 0)
            //{
            //    activeEnemy = enemyEncounter.enemyParty[3];
            //}
            //if (enemyEncounter.enemyParty[3].health <= 0)
            //{
            //    activeEnemy = enemyEncounter.enemyParty[1];
            //}
            if (enemyEncounter.enemyParty[1].health <= 0 && enemyEncounter.enemyParty[2].health <= 0)
            {
                activeEnemy = enemyEncounter.enemyParty[3];
            }
            if (enemyEncounter.enemyParty[1].health <= 0 && enemyEncounter.enemyParty[3].health <= 0)
            {
                activeEnemy = enemyEncounter.enemyParty[2];
            }
            if (enemyEncounter.enemyParty[2].health <= 0 && enemyEncounter.enemyParty[3].health <= 0)
            {
                activeEnemy = enemyEncounter.enemyParty[1];
            }

            if (enemyEncounter.enemyParty[1].health <= 0 && enemyEncounter.enemyParty[2].health <= 0 && enemyEncounter.enemyParty[3].health <= 0)
            {
                currentState = BattleStates.WIN;
            }
        }
        spriteManagerScript.ArrowPointsCurrent(activePlayer);
    }
    public void sortHeroesBySpeed()
    {
        playerstats.playerInfo["Gwyn"].order = 1;
        playerstats.playerInfo["Fredalf"].order = 2;
        playerstats.playerInfo["Ceryz"].order = 3;
        //if (playerstats.playerInfo["Gwyn"].speed > playerstats.playerInfo["Fredalf"].speed)
        //{
        //    if (playerstats.playerInfo["Gwyn"].speed > playerstats.playerInfo["Ceryz"].speed)
        //    {
                
        //        if (playerstats.playerInfo["Fredalf"].speed > playerstats.playerInfo["Ceryz"].speed)
        //        {

        //        }
        //        else
        //        {
        //            playerstats.playerInfo["Ceryz"].order = 2;
        //            playerstats.playerInfo["Fredalf"].order = 3;
        //        }
        //    }
        //}
        //else if (playerstats.playerInfo["Fredalf"].speed > playerstats.playerInfo["Ceryz"].speed)
        //{
        //    playerstats.playerInfo["Fredalf"].order = 1;
        //    if (playerstats.playerInfo["Gwyn"].speed > playerstats.playerInfo["Ceryz"].speed)
        //    {
        //        playerstats.playerInfo["Gwyn"].order = 2;
        //        playerstats.playerInfo["Ceryz"].order = 3;
        //    }
        //    else
        //    {
        //        playerstats.playerInfo["Ceryz"].order = 2;
        //        playerstats.playerInfo["Gwyn"].order = 3;
        //    }
        //}
        //else
        //{
        //    playerstats.playerInfo["Ceryz"].order = 1;
        //    if (playerstats.playerInfo["Gwyn"].speed > playerstats.playerInfo["Fredalf"].speed)
        //    {
        //        playerstats.playerInfo["Gwyn"].order = 2;
        //        playerstats.playerInfo["Fredalf"].order = 3;
        //    }
        //    else
        //    {
        //        playerstats.playerInfo["Fredalf"].order = 2;
        //        playerstats.playerInfo["Gwyn"].order = 3;
        //    }
        //}
    }

    public void setActivePlayer(int order)
    {
        if (order == playerstats.playerInfo["Gwyn"].order && playerstats.playerInfo["Gwyn"].health > 0)
        {
            activePlayer = playerstats.playerInfo["Gwyn"];
        }
        else if (order == playerstats.playerInfo["Fredalf"].order && playerstats.playerInfo["Fredalf"].health > 0)
        {
            activePlayer = playerstats.playerInfo["Fredalf"];
        }
        else if (order == playerstats.playerInfo["Ceryz"].order && playerstats.playerInfo["Ceryz"].health > 0)
        {
            activePlayer = playerstats.playerInfo["Ceryz"];
        }

        if (order == playerstats.playerInfo["Gwyn"].order && playerstats.playerInfo["Gwyn"].health <= 0)
        {
            if (playerstats.playerInfo["Fredalf"].health >= 0)
            {
                if (playerstats.playerInfo["Fredalf"].order > playerstats.playerInfo["Ceryz"].order)
                {
                    activePlayer = playerstats.playerInfo["Fredalf"];
                }
                else if (playerstats.playerInfo["Ceryz"].health >= 0 && (playerstats.playerInfo["Ceryz"].order > playerstats.playerInfo["Fredalf"].order))
                {
                    activePlayer = playerstats.playerInfo["Ceryz"];
                }
                else
                {
                    activePlayer = playerstats.playerInfo["Fredalf"];
                }
            }
        }
        if (order == playerstats.playerInfo["Fredalf"].order && playerstats.playerInfo["Fredalf"].health <= 0)
        {
            if (playerstats.playerInfo["Gwyn"].health >= 0)
            {
                if (playerstats.playerInfo["Gwyn"].order > playerstats.playerInfo["Ceryz"].order)
                {
                    activePlayer = playerstats.playerInfo["Gwyn"];
                }
                else if (playerstats.playerInfo["Ceryz"].health >= 0 && (playerstats.playerInfo["Ceryz"].order > playerstats.playerInfo["Gwyn"].order))
                {
                    activePlayer = playerstats.playerInfo["Ceryz"];
                }
                else
                {
                    activePlayer = playerstats.playerInfo["Gwyn"];
                }
            }
        }
        if (order == playerstats.playerInfo["Ceryz"].order && playerstats.playerInfo["Ceryz"].health <= 0)
        {
            if (playerstats.playerInfo["Gwyn"].health >= 0)
            {
                if (playerstats.playerInfo["Gwyn"].order > playerstats.playerInfo["Fredalf"].order)
                {
                    activePlayer = playerstats.playerInfo["Gwyn"];
                }
                else if (playerstats.playerInfo["Fredalf"].health >= 0 && (playerstats.playerInfo["Fredalf"].order > playerstats.playerInfo["Gwyn"].order))
                {
                    activePlayer = playerstats.playerInfo["Fredalf"];
                }
                else
                {
                    activePlayer = playerstats.playerInfo["Gwyn"];
                }
            }
        }
        spriteManagerScript.changePortrait(activePlayer);
        spriteManagerScript.ArrowPointsCurrent(activePlayer);
    }
    public void setActiveEnemy(int order, int numberOfEncounter)
    {

        if (numberOfEncounter == 4)
        {
            activeEnemy = enemyEncounter.enemyParty[1];
        }
        else if (numberOfEncounter  == 1)
        {
            if (order == enemyEncounter.enemyParty[1].order && enemyEncounter.enemyParty[1].health > 0)
            {
                activeEnemy = enemyEncounter.enemyParty[1];
            }
        }
        else if (numberOfEncounter == 2)
        {
            
            if (orderFor2 == enemyEncounter.enemyParty[1].order && enemyEncounter.enemyParty[1].health > 0)
            {
                activeEnemy = enemyEncounter.enemyParty[1];
            }
            else if (orderFor2 == enemyEncounter.enemyParty[2].order && enemyEncounter.enemyParty[2].health > 0)
            {
                activeEnemy = enemyEncounter.enemyParty[2];
            }
            if (enemyEncounter.enemyParty[1].health <= 0 && order == enemyEncounter.enemyParty[1].order)
            {
                activeEnemy = enemyEncounter.enemyParty[2];
            }
            if (enemyEncounter.enemyParty[2].health <= 0 && order == enemyEncounter.enemyParty[2].order)
            {
                activeEnemy = enemyEncounter.enemyParty[1];
            }
            orderFor2++;
            if (orderFor2 > 2)
            {
                orderFor2 = 1;
            }

        }
        else if (numberOfEncounter ==3)
        {
            if (order == enemyEncounter.enemyParty[1].order && enemyEncounter.enemyParty[1].health > 0)
            {
                activeEnemy = enemyEncounter.enemyParty[1];
            }
            else if (order == enemyEncounter.enemyParty[2].order && enemyEncounter.enemyParty[2].health > 0)
            {
                activeEnemy = enemyEncounter.enemyParty[2];
            }
            else if (order == enemyEncounter.enemyParty[3].order && enemyEncounter.enemyParty[3].health > 0)
            {
                activeEnemy = enemyEncounter.enemyParty[3];
            }
            if (enemyEncounter.enemyParty[1].health <= 0 && order == enemyEncounter.enemyParty[1].order)
            {
                activeEnemy = enemyEncounter.enemyParty[2];
            }
            if (enemyEncounter.enemyParty[2].health <= 0 && order == enemyEncounter.enemyParty[2].order)
            {
                activeEnemy = enemyEncounter.enemyParty[3];
            }
            if (enemyEncounter.enemyParty[3].health <= 0 && order == enemyEncounter.enemyParty[3].order)
            {
                activeEnemy = enemyEncounter.enemyParty[1];
            }
            if (enemyEncounter.enemyParty[1].health <= 0 && enemyEncounter.enemyParty[2].health <= 0)
            {
                activeEnemy = enemyEncounter.enemyParty[3];
            }
            if (enemyEncounter.enemyParty[1].health <= 0 && enemyEncounter.enemyParty[3].health <= 0)
            {
                activeEnemy = enemyEncounter.enemyParty[2];
            }
            if (enemyEncounter.enemyParty[2].health <= 0 && enemyEncounter.enemyParty[3].health <= 0)
            {
                activeEnemy = enemyEncounter.enemyParty[1];
            }
        }
    }
    public void UpdateCharacter(int order)
    {
        if (activePlayer.magic <= 50)
        {
            activePlayer.magic = activePlayer.magic + 10;
        }
        else
        {
            activePlayer.magic = 50;
        }
        if (order == playerstats.playerInfo["Gwyn"].order && playerstats.playerInfo["Gwyn"].health > 0)
        {
            playerstats.playerInfo["Gwyn"] = activePlayer;
        }
        else if (order == playerstats.playerInfo["Fredalf"].order && playerstats.playerInfo["Fredalf"].health > 0)
        {
            playerstats.playerInfo["Fredalf"] = activePlayer;
        }
        else if (order == playerstats.playerInfo["Ceryz"].order && playerstats.playerInfo["Ceryz"].health > 0)
        {
            playerstats.playerInfo["Ceryz"] = activePlayer;
        }
    }
    public void UpdateEnemy(int order)
    {
        if (enemyEncounter.enemyParty[1].id == 1)
        {
            enemyEncounter.enemyParty[1] = activeEnemy;

        }
        else
        {
            if (order == enemyEncounter.enemyParty[1].order && enemyEncounter.enemyParty[1].health > 0)
            {
                enemyEncounter.enemyParty[1] = activeEnemy;
            }
            else if (order == enemyEncounter.enemyParty[2].order && enemyEncounter.enemyParty[2].health > 0)
            {
                enemyEncounter.enemyParty[2] = activeEnemy;
            }
            else if (order == enemyEncounter.enemyParty[3].order && enemyEncounter.enemyParty[3].health > 0)
            {
                enemyEncounter.enemyParty[3] = activeEnemy;
            }
            if (enemyEncounter.enemyParty[1].health < 0)
            {
                enemySliders1.SetActive(false);
                enemyObject1.SetActive(false);
            }
            if (enemyEncounter.enemyParty[2].health < 0)
            {
                enemySliders2.SetActive(false);
                enemyObject2.SetActive(false);
            }
            if (enemyEncounter.enemyParty[3].health < 0)
            {
                enemySliders3.SetActive(false);
                enemyObject3.SetActive(false);
            }
            if (enemyEncounter.enemyParty[1].id != 4)
            {
                bossObject.SetActive(false);
                bossSliders.SetActive(false);
            }
        }
    }
    public void Run()
    {
        if (enemyEncounter.encounterID == 2)
        {
            spriteManagerScript.changeDescriptionFailedToRun();
        }
        else if (enemyEncounter.encounterID == 3)
        {
            spriteManagerScript.changeDescriptionFailedToRun();
        }
        else if (enemyEncounter.encounterID == 4)
        {
            spriteManagerScript.changeDescriptionFailedToRun();
        }
        else
        {
            var randomNum = Random.Range(0, 50);
            Debug.Log(randomNum);
            if (randomNum > 35)
            {
                enemyEncounter.ClearEnemies();
                SceneManager.LoadScene("SampleScene");
            }
            else
            {
                Debug.Log("bummer");
            }
            playerEndTurn = true;
        }
        ChooseWhoGoesNext();
    }
    public void ActivateEnemies()
    {
        if (enemyEncounter.enemyParty[1].id == 1)
        {
            bossObject.SetActive(true);
            bossSliders.SetActive(true);
            //    bossSliders.SetActive(true);
            enemyObject1.SetActive(false);
            //    enemySliders1.SetActive(false);
            enemyObject2.SetActive(false);
            //      enemySliders2.SetActive(false);
            enemyObject3.SetActive(false);
            //  enemySliders3.SetActive(false);

        }
        else
        {
            if (enemyEncounter.enemyParty[1].active == false)
            {
                enemyObject1.SetActive(false);
                //    enemySliders1.SetActive(false);
                enemyEncounter.enemyParty[1].health = 0;
            }
            if (enemyEncounter.enemyParty[2].active == false)
            {
                enemyObject2.SetActive(false);
                //   enemySliders2.SetActive(false);
                enemyEncounter.enemyParty[2].health = 0;
            }
            if (enemyEncounter.enemyParty[3].active == false)
            {
                enemyObject3.SetActive(false);
                //   enemySliders3.SetActive(false);
                enemyEncounter.enemyParty[3].health = 0;
            }
            bossObject.SetActive(false);
        }

    }
    public void removeSliders()
    {
        if (enemyEncounter.enemyParty[1].id == 1)
        {
            enemySliders1.SetActive(false);
            enemySliders2.SetActive(false);
            enemySliders3.SetActive(false);
        }
        else
        {
            bossSliders.SetActive(false);
        }

    }

    public void CombatBasic()
    {
        if (activePlayer.playerName == playerstats.playerInfo["Gwyn"].playerName)
        {
            audioManagerScript.CombatBasicAttack(AudioManager.AudioChoiceSFX.GwynBAttack);
        }
        else if (activePlayer.playerName == playerstats.playerInfo["Fredalf"].playerName)
        {
            audioManagerScript.CombatBasicAttack(AudioManager.AudioChoiceSFX.FredalfBAttack);
        }
        else if (activePlayer.playerName == playerstats.playerInfo["Ceryz"].playerName)
        {
            audioManagerScript.CombatBasicAttack(AudioManager.AudioChoiceSFX.CeryzBAttack);
        }
    }

}
