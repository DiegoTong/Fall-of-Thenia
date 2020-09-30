using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Ability
{
    public FireBall()
    {
        AbilityName = "Fireball";
        AbilityDescription = "Deals 30 damage to all enemies";
        AbilityId = 2;
        AbilityPower = 30;
        AbilityCost = 20;
        AbilitySpecial = 10;
    }
}
