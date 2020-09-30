using System.Collections;
using UnityEngine;

[System.Serializable]
public class Item 
{
    public string itemName;
    public int itemID;
    public string itemDesc;
    public Texture2D itemIcon;
    public int itemPower;    
    public int itemHealth;
    public int itemMana;    
    public int ItemDroppercent;
    bool isLoot;
    public ItemType itemType;

    public enum ItemType
    {
        WEAPON,
        CONSUMABLE,
        QUEST,
        ARMOR,


        NUM_ITEM_TYPES,
    }
    public Item(string fileName, string name, int id, string desc, int power, int health, int mana, ItemType type, int droppedLoot, bool lootOnly = true, float lootDropOdds = 0.0f)
    {
        itemName = name;
        itemID = id;
        itemDesc = desc;
        itemIcon = Resources.Load<Texture2D>("Item Icons/"+ fileName);//path to images
        itemPower = power;        
        itemHealth = health;
        itemMana = mana;
        itemType = type;       
        ItemDroppercent = droppedLoot;
        isLoot = lootOnly;
    }
    public Item() //constructor that takes nothing to NULL out the items by default
    {

    }


}