using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Attack : Ability
{
    public Attack()
    {
        AbilityName = "Basic Attack";
        AbilityDescription = "It's just a basic attack... even a potato could do it";
        AbilityId = 1;
        AbilityPower = 10;
        AbilityCost = 1;
    }
}
