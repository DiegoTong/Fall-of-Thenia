using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : Ability
{
    public Reload()
    {
        AbilityName = "Reload";
        AbilityDescription = "Recover 10 mana";
        AbilityId = 2;
        AbilityPower = 10;
        AbilityCost = 0;
        AbilitySpecial = 40;
    }
}
