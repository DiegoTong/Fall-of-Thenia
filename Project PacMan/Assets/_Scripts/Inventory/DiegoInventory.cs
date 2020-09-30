using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiegoInventory : MonoBehaviour
{
    public Dictionary<string, Item> Items = new Dictionary<string, Item>();
    Item Potions;
    Item RevivalThingy;
    Item CrystalShard;
    Item MegaPotion;
    Item MegaCrystalShard;
    private void Start()
    {
        Potions = new Item("Potion", "Potion", 1, "Heals 50 health", 0, 50, 0, Item.ItemType.CONSUMABLE, 0, false, 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
