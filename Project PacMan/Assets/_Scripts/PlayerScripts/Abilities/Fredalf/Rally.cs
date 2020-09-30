using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rally : Ability
{
    public Rally()
    {
        AbilityName = "Rally";
        AbilityDescription = "Boost parties armor by 10";
        AbilityId = 2;
        AbilityPower = 10;
        AbilityCost = 30;
        AbilitySpecial = 40;
    }
}
