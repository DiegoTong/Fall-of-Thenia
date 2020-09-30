using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SpecialAttack : Ability
{
    public SpecialAttack()
    {
        AbilityName = "Special Attack";
        AbilityDescription = "Does more damage than a basic attack";
        AbilityId = 2;
        AbilityPower = 30;
        AbilityCost = 10;
    }
}
