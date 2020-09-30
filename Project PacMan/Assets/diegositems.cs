using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diegositems : MonoBehaviour
{
    public string itemName;
    public int itemID;
    public string itemDesc;
    public int itemPower;
    bool isLoot;
    public ItemType itemType;
    public int quantity;

    public enum ItemType
    {
        WEAPON,
        CONSUMABLE,
        QUEST,
        ARMOR,


        NUM_ITEM_TYPES,
    }
    public diegositems(string name, int id, string desc, int power, ItemType type, int newquantity)
    {
        itemName = name;
        itemID = id;
        itemDesc = desc;
        itemPower = power;
        itemType = type;
        quantity = newquantity;
    }
}
