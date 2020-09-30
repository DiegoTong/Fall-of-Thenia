using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShot : Ability
{
    public TargetShot()
    {
        AbilityName = "TargetShot";
        AbilityDescription = "Deals 80 Damage to a random enemy";
        AbilityId = 2;
        AbilityPower = 80;
        AbilityCost = 20;
        AbilitySpecial = 40;
    }
}
