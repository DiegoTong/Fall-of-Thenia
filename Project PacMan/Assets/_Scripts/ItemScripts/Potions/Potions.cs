// Main parent script for the potion types

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PotionType
{
    HEALTH = 0,
    MANA,
    STAMINA,
    ATTBUFF,
    DEFBUFF,
    ATTDEBUFF,
    DEFDEBUF
};

public enum PotionSize
{
    SMALL,
    MEDIUM,
    LARGE
};

public class Potions : MonoBehaviour
{
    // Variables used to access stats from Player Prefs
    float pHealth = PlayerInfo.health;
    float pArmor = PlayerInfo.armor;
    float pStamina = PlayerInfo.stamina;
    float pMana = PlayerInfo.magic;
    float pAttack = PlayerInfo.power;


    public string itemName;
    public int StatBoostValue;     // Used for Health, Mana and Stamina
    public float BuffBoostPercent;     // Used for All Buffs.
    public PotionType potionType;
    public PotionSize potionSize;

    // Used for the Health, Mana and Stamina Potions
    void checkPotionSize()
    {
        switch (potionSize)
        {
            case (PotionSize.SMALL):
                StatBoostValue = 25;
                BuffBoostPercent = 1.10f;
                break;
            case (PotionSize.MEDIUM):
                StatBoostValue = 50;
                BuffBoostPercent = 1.20f;
                break;
            case (PotionSize.LARGE):
                StatBoostValue = 100;
                BuffBoostPercent = 1.30f;
                break;
        }

    }

    // Check the type of potion then add to specific attrb.
    void checkPotionType()
    {
        checkPotionSize();

        switch (potionType)
        {
            // Non Percentage Boosts
            case PotionType.HEALTH:
                pHealth = pHealth + StatBoostValue;
                break;
            case PotionType.MANA:
                pMana = pMana + StatBoostValue;
                break;
            case PotionType.STAMINA:
                pStamina = pStamina + StatBoostValue;
                break;

                // Percentage Boosts
            case PotionType.ATTBUFF:
                pAttack = pAttack * BuffBoostPercent;
                break;
            case PotionType.ATTDEBUFF:
                pAttack = pAttack - (pAttack * (BuffBoostPercent - 1));
                break;
            case PotionType.DEFBUFF:
                pArmor = pArmor * BuffBoostPercent;
                break;
            case PotionType.DEFDEBUF:
                pArmor = pArmor - (pArmor * (BuffBoostPercent - 1));
                break;
        }
    }
}
