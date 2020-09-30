using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToArms : Ability
{
    public ToArms()
    {
        AbilityName = "ToArms";
        AbilityDescription = "Deals 20 damage to all enemies";
        AbilityId = 2;
        AbilityPower = 20;
        AbilityCost = 30;
        AbilitySpecial = 10;
    }
}
