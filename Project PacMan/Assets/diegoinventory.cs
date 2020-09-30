using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diegoinventory : MonoBehaviour
{
    public Dictionary<string, diegositems> Items = new Dictionary<string, diegositems>();
    diegositems Potions;
    diegositems RevivalThingy;
    diegositems CrystalShard;
    diegositems MegaPotion;
    diegositems MegaCrystalShard;
    private void Start()
    {
        Potions = new diegositems("Potion",1,"Restore 50 health", 50, diegositems.ItemType.CONSUMABLE,1);
        Items.Add("Potion", Potions);
        RevivalThingy = new diegositems("Revival Shard", 2, "Bring back heroes to life", 50, diegositems.ItemType.CONSUMABLE, 1);
        Items.Add("RevivalShard", RevivalThingy);
        CrystalShard = new diegositems("Crystal Shard", 3, "Restore 20 mana", 20, diegositems.ItemType.CONSUMABLE, 1);
        Items.Add("CrystalShard", CrystalShard);
        MegaPotion = new diegositems("Mega Potion", 4, "Restore 200 health", 200, diegositems.ItemType.CONSUMABLE, 0);
        Items.Add("MegaPotion", MegaPotion);
        MegaCrystalShard = new diegositems("Mega Crystal Shard", 5, "restore 50 mana", 50, diegositems.ItemType.CONSUMABLE, 0);
        Items.Add("MegaCrystalShard", MegaCrystalShard);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
