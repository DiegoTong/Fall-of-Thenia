//----------------------------------------------------------------------------
/* 
 * Base class for all Weapons. 
 * Individual Weapon Classes can have different attribs that effect other stats
 * Potentially add the ability to do status effect damage
*/
//----------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    SWORD = 0,  // Fredalf
    BOW,        // Gwyn
    STAFF,      // Ceryz
    // To be used Later
    RIFLE,      // Ifer
    SNIPER,     // Halla
    KNUCKLES,    // Elson

    NUM_WEAPONTYPES
};

public enum WeaponQuality
{
    COMMON_W = 0,
    UNCOMMON_G,
    RARE_B,
    EPIC_P,
    LEGENDARY_Y,

    Num_WEPQUALITIES
};

public enum WeaponBonus
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

public class Weapons : MonoBehaviour
{
    // Access Player Attribs
    private float playerHealth = PlayerInfo.health;
    private float playerMana = PlayerInfo.magic;
    private float playerArmor = PlayerInfo.armor;
    private float currentAttack = PlayerInfo.power;
    public int newAttack;

    // Weapon Varibles
    public string weaponName;
    
    public int cost = 5;
    public int attackBoost;
    public float bonusPercent;
    public WeaponType weaponType;       // The type of weapon each Character can use. 1 per character
    public WeaponQuality weaponQuality;
    public WeaponBonus weaponBonus;

    // Order - 
    public Weapons(WeaponType type, string name, int attack, WeaponBonus bonus , float bonusVal, int price)
    {
        this.weaponName = name;
        this.attackBoost = attack;
        this.bonusPercent = bonusVal;
        this.cost = price;
        this.weaponType = type;
    }

    public void randomType()
    {
        int randomVal = Random.Range(0, 4);
        if (randomVal == 0)
        {
            weaponType = WeaponType.STAFF;
        }
        if (randomVal == 1)
        {
            weaponType = WeaponType.SWORD;
        }
        if (randomVal == 2)
        {
            weaponType = WeaponType.BOW;
        }
    }

    public void randomQuality()
    {
        int randomVal = Random.Range(0, 101);

        if (randomVal <= 40) { weaponQuality = (WeaponQuality)0; }    // 40% chance for common
        else if (randomVal > 40 && randomVal <= 70) { weaponQuality = (WeaponQuality)1; } // 29% chance for Uncommon
        else if (randomVal > 70 && randomVal <= 85) { weaponQuality = (WeaponQuality)2; }  // 14% Chance for Rare
        else if (randomVal > 85 && randomVal <= 95) { weaponQuality = (WeaponQuality)3; }  // 9% Chance for Epic
        else if (randomVal > 95 && randomVal <= 100) { weaponQuality = (WeaponQuality)4; } // 4% Chance for Legendary
    }

    public void checkQuality()
    {
        // Each Value is 
        switch (weaponQuality)
        {
            case (WeaponQuality.COMMON_W):
                newAttack = attackBoost * 1; // No Change if the quality is Common
                cost = cost * 1;
                bonusPercent = 1.0f;
                break;
            case (WeaponQuality.UNCOMMON_G):
                newAttack = attackBoost * 2;
                cost = cost * 2;
                bonusPercent = 1.1f;
                break;
            case (WeaponQuality.RARE_B):
                newAttack = attackBoost * 3;
                cost = cost * 3;
                bonusPercent = 1.2f;
                break;
            case (WeaponQuality.EPIC_P):
                newAttack = attackBoost * 4;
                cost = cost * 4;
                bonusPercent = 1.3f;
                break;
            case (WeaponQuality.LEGENDARY_Y):
                newAttack = attackBoost * 5;
                cost = cost * 5;
                bonusPercent = 1.5f;
                break;
        };
        currentAttack = currentAttack + newAttack;
    }

    public void assignBonus()
    {
        int randomVal = Random.Range(0, 11);
        switch (randomVal)
        {
            case 0:
                weaponBonus = WeaponBonus.NONE;
                break;
            case 1:
                weaponBonus = WeaponBonus.HEALTH;
                break;
            case 2:
                weaponBonus = WeaponBonus.MANA;
                break;
            case 3:
                weaponBonus = WeaponBonus.ATTACK;
                break;
            case 4:
                weaponBonus = WeaponBonus.DEFENCE;
                break;
            case 5:
                weaponBonus = WeaponBonus.ATTDEF;
                break;
            case 6:
                weaponBonus = WeaponBonus.HPMANA;
                break;
            case 7:
                weaponBonus = WeaponBonus.HPATT;
                break;
            case 8:
                weaponBonus = WeaponBonus.HPDEF;
                break;
            case 9:
                weaponBonus = WeaponBonus.ALLFOUR;
                break;
        };
    }

    public void setBonusAddition() // add on the Bonus to the Players Attribs
    {
        checkQuality(); // Sets Bonus Percent
        switch (weaponBonus) // Adds on the bonus to the required attrib
        {
            case WeaponBonus.NONE:
                break;
            case WeaponBonus.HEALTH:
                playerHealth = playerHealth * bonusPercent;
                break;
            case WeaponBonus.MANA:
                playerMana = playerMana * bonusPercent;
                break;
            case WeaponBonus.ATTACK:
                currentAttack = currentAttack * bonusPercent;
                break;
            case WeaponBonus.DEFENCE:
                playerArmor = playerArmor * bonusPercent;
                break;
            case WeaponBonus.ATTDEF:
                currentAttack = currentAttack * bonusPercent;
                playerArmor = playerArmor * bonusPercent;
                break;
            case WeaponBonus.HPMANA:
                playerHealth = playerHealth * bonusPercent;
                playerMana = playerMana * bonusPercent;
                break;
            case WeaponBonus.HPATT:
                playerHealth = playerHealth * bonusPercent;
                currentAttack = currentAttack * bonusPercent;
                break;
            case WeaponBonus.HPDEF:
                playerHealth = playerHealth * bonusPercent;
                playerArmor = playerArmor * bonusPercent;
                break;
            case WeaponBonus.ALLFOUR:
                playerHealth = playerHealth * bonusPercent;
                playerMana = playerMana * bonusPercent;
                currentAttack = currentAttack * bonusPercent;
                playerArmor = playerArmor * bonusPercent;
                break;
        };
    }
    public int setCost()
    {
        if (weaponBonus != (WeaponBonus)0) // Bonuses cost an extra 10
        {
            cost = cost + 5;
        }
        checkQuality();
        switch (weaponType)
        {
            case (WeaponType.STAFF):
                cost = cost * 1;
                break;
            case (WeaponType.BOW):
                cost = cost * 2;
                break;
            case (WeaponType.SWORD):
                cost = cost * 3;
                break;
        };
        return cost;
    }

    private void Start()
    {
        setCost();
        setBonusAddition();
        checkQuality();
    }

}
