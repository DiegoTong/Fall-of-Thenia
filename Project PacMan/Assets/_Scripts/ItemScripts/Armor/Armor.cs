//----------------------------------------------------------------------------
/* 
 * Base class for all armors. 
 * This class has functions for Quality, Type and the Bonus
 * Functions Handle the addition to the stats
 * Individual Armor Classes can have different attribs that effect other stats
 * such as health or attack power.
*/
//----------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArmorType
{
    LIGHT,
    MEDIUM,
    HEAVY,

    NUM_ARMORTYPES
};

public enum ArmorQuality
{
    // will be used as Multiples to the baseProt.
    COMMON_W = 0,
    UNCOMMON_G,
    RARE_B,
    EPIC_P,
    LEGENDARY_Y,

    NUM_ARMQUALITIES
};

public enum ArmorBonus
{
    NONE = 0,
    HEALTH,
    MANA,
    ATTACK,
    DEFENCE,
    ATTDEF,
    HPMANA,
    HPATT,
    HPDEF,
    ALLFOUR,

    NUM_BONUSES
};

public class Armor : MonoBehaviour
{
    // Access Player Attribs
    private float playerHealth = PlayerInfo.health;
    private float playerMana = PlayerInfo.magic;
    private float playerAttack = PlayerInfo.power;
    private float currentArmor = PlayerInfo.armor; // Base Armor of the Character
    private int newProtection;

    // Armor Varibles
    public string armorName;
    [SerializeField]
    private int cost = 5;
    public int protection;
    public float bonusPercent;
    public ArmorType armorType;
    public ArmorQuality armorQuality;
    public ArmorBonus armorBonus;

    // if creating armors from code this can be used
    public Armor(string name, int protect, float bonusValue, int price, int type)
    {
        this.armorName = name;
        this.protection = protect;
        this.bonusPercent = bonusValue;
        this.cost = price;
        this.armorType = (ArmorType)type;
    }

    public void randomType()
    {
        int randomVal = Random.Range(0, 4);
        if (randomVal == 0)
        {
            armorType = ArmorType.LIGHT;
        }
        if (randomVal == 1)
        {
            armorType = ArmorType.MEDIUM;
        }
        if (randomVal == 2)
        {
            armorType = ArmorType.HEAVY;
        }
    }

    // Gives Armor a Random Quality
    // Used Mainly for the Shop and Loot
    public void randomQuality()
    {
        int randomVal = Random.Range(0, 101);

        if (randomVal <= 40) { armorQuality = (ArmorQuality)0; }    // 40% chance for common
        else if (randomVal > 40 && randomVal <= 70 ) { armorQuality = (ArmorQuality)1; } // 29% chance for Uncommon
        else if (randomVal > 70 && randomVal <= 85) { armorQuality = (ArmorQuality)2; }  // 14% Chance for Rare
        else if (randomVal > 85 && randomVal <= 95) { armorQuality = (ArmorQuality)3; }  // 9% Chance for Epic
        else if (randomVal > 95 && randomVal <= 100) { armorQuality = (ArmorQuality)4; } // 4% Chance for Legendary
    }

    public void checkQuality()
    {
        // Each Value is 
        switch (armorQuality)
        {
            case (ArmorQuality.COMMON_W):
                newProtection = protection * 1; // No Change if the quality is Common
                cost = cost * 1;
                bonusPercent = 1.0f;
                break;
            case (ArmorQuality.UNCOMMON_G):
                newProtection = protection * 3;
                cost = cost * 2;
                bonusPercent = 1.1f;
                break;
            case (ArmorQuality.RARE_B):
                newProtection = protection * 5;
                cost = cost * 3;
                bonusPercent = 1.2f;
                break;
            case (ArmorQuality.EPIC_P):
                newProtection = protection * 7;
                cost = cost * 4;
                bonusPercent = 1.3f;
                break;
            case (ArmorQuality.LEGENDARY_Y):
                newProtection = protection * 10;
                cost = cost * 5;
                bonusPercent = 1.5f;
                break;
        };
        currentArmor = currentArmor + newProtection;
    }

    void assignBonus()
    {
        int randomVal = Random.Range(0, 11);
        switch (randomVal)
        {
            case 0:
                armorBonus = ArmorBonus.NONE;
                break;
            case 1:
                armorBonus = ArmorBonus.HEALTH;
                break;
            case 2:
                armorBonus = ArmorBonus.MANA;
                break;
            case 3:
                armorBonus = ArmorBonus.ATTACK;
                break;
            case 4:
                armorBonus = ArmorBonus.DEFENCE;
                break;
            case 5:
                armorBonus = ArmorBonus.ATTDEF;
                break;
            case 6:
                armorBonus = ArmorBonus.HPMANA;
                break;
            case 7:
                armorBonus = ArmorBonus.HPATT;
                break;
            case 8:
                armorBonus = ArmorBonus.HPDEF;
                break;
            case 9:
                armorBonus = ArmorBonus.ALLFOUR;
                break;
        };
    }

    public void setBonusAddition() // add on the Bonus to the Players Attribs
    {
        checkQuality(); // Sets Bonus Percent
        switch (armorBonus) // Adds on the bonus to the required attrib
        {
            case ArmorBonus.NONE:
                break;
            case ArmorBonus.HEALTH:
                playerHealth = playerHealth * bonusPercent;
                break;
            case ArmorBonus.MANA:
                playerMana = playerMana * bonusPercent;
                break;
            case ArmorBonus.ATTACK:
                playerAttack = playerAttack * bonusPercent;
                break;
            case ArmorBonus.DEFENCE:
                currentArmor = currentArmor * bonusPercent;
                break;
            case ArmorBonus.ATTDEF:
                playerAttack = playerAttack * bonusPercent;
                currentArmor = currentArmor * bonusPercent;
                break;
            case ArmorBonus.HPMANA:
                playerHealth = playerHealth * bonusPercent;
                playerMana = playerMana * bonusPercent;
                break;
            case ArmorBonus.HPATT:
                playerHealth = playerHealth * bonusPercent;
                playerAttack = playerAttack * bonusPercent;
                break;
            case ArmorBonus.HPDEF:
                playerHealth = playerHealth * bonusPercent;
                currentArmor = currentArmor * bonusPercent;
                break;
            case ArmorBonus.ALLFOUR:
                playerHealth = playerHealth * bonusPercent;
                playerMana = playerMana * bonusPercent;
                playerAttack = playerAttack * bonusPercent;
                currentArmor = currentArmor * bonusPercent;
                break;
        };
    }

    public int setCost()
    {
        if(armorBonus != (ArmorBonus)0) // Bonuses cost an extra 10
        {
            cost = cost + 5;
        }
        checkQuality();
        switch (armorType)
        {
            case (ArmorType.LIGHT):
                cost = cost * 1;
                break;
            case (ArmorType.MEDIUM):
                cost = cost * 2;
                break;
            case (ArmorType.HEAVY):
                cost = cost * 3;
                break;
        };
        return cost;
    }

    private void Start()
    {
        setCost();
        setBonusAddition();
    }
}
