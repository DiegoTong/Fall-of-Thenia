using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class EndlessBarrage : Ability
{
    public EndlessBarrage()
    {
        AbilityName = "Endless Barrage";
        AbilityDescription = "Gwyns' special ability... Damages all enemies by 50";
        AbilityId = 2;
        AbilityPower = 50;
        AbilityCost = 40;
        AbilitySpecial = 10;
    }
}
