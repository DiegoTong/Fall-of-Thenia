using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability
{
    private string abilityName;
    private string abiltyDescription;
    private int abilityId;
    private int abilityPower;
    private int abilityCost;
    private int abilitySpecial;
    public string AbilityName
    {
        get { return abilityName; }
        set { abilityName = value; }
    }

    public string AbilityDescription
    {
        get { return abiltyDescription; }
        set { abiltyDescription = value; }
    }
    public int AbilityId
    {
        get { return abilityId; }
        set { abilityId = value; }
    }
    public int AbilityPower
    {
        get { return abilityPower; }
        set { abilityPower = value; }
    }
    public int AbilityCost
    {
        get { return abilityCost; }
        set { abilityCost = value; }
    }

    public int AbilitySpecial
    {
        get { return abilitySpecial; }
        set { abilitySpecial = value; }
    }
}
