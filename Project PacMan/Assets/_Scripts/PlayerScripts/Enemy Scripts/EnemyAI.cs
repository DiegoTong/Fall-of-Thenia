using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI
{
    public int targetPlayerHealth;
    GameInfo targetPlayer;
    public int playerHealthPercentage;
    Ability chooseAbility;
    Ability ability;
    GameObject TurnManager;
    TurnBaseManager turnManagerScript;
    PlayerStats enemystats;
    PlayerInfo players;
    int damage;
    int gwynTotalHealth;
    int rickTotalHealth;
    int ceryzTotalHealth;

    void Awake()
    {

    }
    void Start()
    {
        enemystats = new PlayerStats(false, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        targetPlayer = new GameInfo("0", 0, 0, 0, 0, 0, 0, 0, 0, 0,0, new Attack());
        turnManagerScript = GameObject.FindGameObjectWithTag("TurnManager").GetComponent<TurnBaseManager>();
        players = GameObject.FindGameObjectWithTag("PlayerInfo").GetComponent<PlayerInfo>();
        gwynTotalHealth = players.playerInfo["Gwyn"].health + players.playerInfo["Gwyn"].armor;
        rickTotalHealth = players.playerInfo["Rick"].health + players.playerInfo["Rick"].armor;
        ceryzTotalHealth = players.playerInfo["Ceryz"].health + players.playerInfo["Ceryz"].armor;
    }
    void Update()
    {
    }
    public void EnemyDoesAction()
    {
        turnManagerScript = GameObject.FindGameObjectWithTag("TurnManager").GetComponent<TurnBaseManager>();
        enemystats = new PlayerStats(false, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        ability = EnemyChooseAbility();
        CalculatingEnemyDamage(ability, turnManagerScript.activePlayer);
        TurnBaseManager.enemyEndTurn = true;
    }
    public Ability EnemyChooseAbility()
    {

        chooseAbility = null;
        if (gwynTotalHealth > rickTotalHealth)
        {
            if (gwynTotalHealth > ceryzTotalHealth)
            {
                if (rickTotalHealth > ceryzTotalHealth)
                {
                    targetPlayerHealth = ceryzTotalHealth;
                    targetPlayer = players.playerInfo["Ceryz"];
                }
                else
                {
                    targetPlayerHealth = rickTotalHealth;
                    targetPlayer = players.playerInfo["Rick"];
                }
            }
        }
        if (rickTotalHealth > gwynTotalHealth)
        {
            if (rickTotalHealth > ceryzTotalHealth)
            {
                if (gwynTotalHealth > ceryzTotalHealth)
                {
                    targetPlayerHealth = ceryzTotalHealth;
                    targetPlayer = players.playerInfo["Ceryz"];
                }
                else
                {
                    targetPlayerHealth = gwynTotalHealth;
                    targetPlayer = players.playerInfo["Gwyn"];
                }
            }
        }
        if (ceryzTotalHealth > gwynTotalHealth)
        {
            if (ceryzTotalHealth > rickTotalHealth)
            {
                if (gwynTotalHealth > rickTotalHealth)
                {
                    targetPlayerHealth = rickTotalHealth;
                    targetPlayer = players.playerInfo["Rick"];
                }
                else
                {
                    targetPlayerHealth = gwynTotalHealth;
                    targetPlayer = players.playerInfo["Gwyn"];
                }
            }
        }
        else
        {
            targetPlayerHealth = turnManagerScript.activePlayer.health + turnManagerScript.activePlayer.armor;
            targetPlayer = turnManagerScript.activePlayer;
        }
        playerHealthPercentage = (int)(targetPlayerHealth);
        if (turnManagerScript.enemyEncounter.enemyParty[1].id == 1)
        {
            if (playerHealthPercentage > 75)
            {
                chooseAbility = new Scratch();
                return chooseAbility;
            }
            else if (playerHealthPercentage < 75)
            {
                chooseAbility = new Attack();
                return chooseAbility;
            }
        }
        else
        {
            if (playerHealthPercentage > 75)
            {
                chooseAbility = new Scratch();
                return chooseAbility;
            }
            else if (playerHealthPercentage < 75)
            {
                chooseAbility = new Attack();
                return chooseAbility;
            }
        }
        return chooseAbility = new Attack();
    }
    public void CalculatingEnemyDamage(Ability usedAbility, GameInfo activePlayer)
    {
        damage = (enemystats.power + usedAbility.AbilityPower - activePlayer.armor);
        // Debug here for pure damage
        Debug.Log("True Damage " + damage);
        if (damage <= 0)
        {
            damage = 0;
        }
        targetPlayer.health = activePlayer.health - damage;
        Debug.Log("Damage taken " + targetPlayer);
        // Debug here for actual damage
    }
}
