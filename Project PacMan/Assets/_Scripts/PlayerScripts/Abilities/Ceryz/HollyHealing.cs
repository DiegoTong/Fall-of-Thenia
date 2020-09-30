using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class HollyHealing : Ability
{
    public HollyHealing()
    {
        AbilityName = "Holy Healing";
        AbilityDescription = "Ceryz Special ability... Heals 90 HP to party";
        AbilityId = 3;
        AbilityPower = 80;
        AbilityCost = 40;
        AbilitySpecial = 40;
    }
}
