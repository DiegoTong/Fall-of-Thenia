using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WarCry : Ability
{
    public WarCry()
    {
        AbilityName = "War Cry";
        AbilityDescription = "Fredalf's special ability... boost parties damage by 40";
        AbilityId = 2;
        AbilityPower = 40;
        AbilityCost = 40;
        AbilitySpecial = 40;
    }
}
