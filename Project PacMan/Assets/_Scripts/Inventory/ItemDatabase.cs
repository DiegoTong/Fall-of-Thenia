using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public ItemDatabase()
    {
        items.Add(new Item("bone bow com 1", "Bow of Prayers",0,"A Bow that needs prayers", 2,0,0,Item.ItemType.WEAPON, 0,false));
        items.Add(new Item("magic staff epic 1", "Mace of Prayers", 1, "weapon needs prayers", 0, 50, 0, Item.ItemType.WEAPON, 0, false));
        items.Add(new Item("bone bow com 1", "Armor of Prayers", 2, "Armor needs prayers", 0, 50, 0, Item.ItemType.ARMOR, 0, false));
        items.Add(new Item("magic staff epic", "Bow of Prayers", 3, "A Mace that needs prayers", 2, 0, 0, Item.ItemType.WEAPON, 0, false));
        items.Add(new Item("bone bow com 1", "Armor of Prayers", 4, "Armor needs prayers", 0, 50, 0, Item.ItemType.ARMOR, 0, false));
        items.Add(new Item("bone bow com 1", "Armor of Prayers", 5, "Armor needs prayers", 0, 50, 0, Item.ItemType.ARMOR, 0, false));       

    }

}
