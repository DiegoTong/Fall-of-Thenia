using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    public bool active;
    public int level;
    public int stamina;
    public int magic;
    public int power;
    public int health;
    public int speed;
    public int armor;
    public int order;
    public int id;
    public List<Ability> playerAbilities = new List<Ability>();
    public Ability playermove1 = new Attack();
    public Ability playermove2 = new SpecialAttack();


    public PlayerStats(bool newActive, int newLevel, int newStamina, int newMagic, int newPower, int newHealth, int newSpeed, int newArmor, int newOrder, int newId)
    {
        active = newActive;
        level = newLevel;
        stamina = newStamina;
        magic = newMagic;
        power = newPower;
        health = newHealth;
        speed = newSpeed;
        armor = newArmor;
        order = newOrder;
        id = newId;
    }


}
