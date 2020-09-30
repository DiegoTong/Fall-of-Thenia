using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameInfo
{
    public string playerName;
    public int playerLevel = 0;
    public int stamina = 0;
    public int magic = 0;
    public int power = 0;
    public int health = 0;
    public int maxHealth = 0;
    public int speed = 0;
    public int armor = 0;
    public int order = 0;
    public int id = 0;
    public Ability playermove1 = new Attack();
    public Ability playermove2 = new SpecialAttack();
    public Ability playerAbility = null;

    public GameInfo(string newPlayerName, int newPlayerLevel, int newStamina, int newMagic, int newPower, int newHealth, int newSpeed, int newArmor, int newOrder, int newId, int newMaxHealth, Ability newAbility)
    {
        playerName = newPlayerName;
        playerLevel = newPlayerLevel;
        stamina = newStamina;
        magic = newMagic;
        power = newPower;
        health = newHealth;
        speed = newSpeed;
        armor = newArmor;
        order = newOrder;
        id = newId;
        maxHealth = newMaxHealth;
        playerAbility = newAbility;
    }
}


