using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scratch : Ability
{
    public Scratch()
    {
        AbilityName = "Scratch";
        AbilityDescription = "Scratch an enemy";
        AbilityId = 2;
        AbilityPower = 20;
        AbilityCost = 10;
    }
}
