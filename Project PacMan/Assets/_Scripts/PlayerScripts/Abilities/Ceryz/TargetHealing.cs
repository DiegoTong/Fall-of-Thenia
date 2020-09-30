using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHealing : Ability
{
    public TargetHealing()
    {
        AbilityName = "Self Healing";
        AbilityDescription = "Ceryz heals herself for 30 health";
        AbilityId = 3;
        AbilityPower = 30;
        AbilityCost = 10;
        AbilitySpecial = 40;
    }
}
