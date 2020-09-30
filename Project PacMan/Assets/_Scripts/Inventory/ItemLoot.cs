using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLoot : MonoBehaviour
{
    public List<Item> loot = new List<Item>();
    
    public ItemLoot()
    {
        // loot drop items for light armor
        loot.Add(new Item("NoviceRobes", "Light Armor", 7, "More sexy then practical",0,0,0, Item.ItemType.ARMOR, 29, true));//uncommon
        loot.Add(new Item("RobesofAggression", "Light Armor", 8, "Enough atittude to take it", 0,0,0, Item.ItemType.ARMOR, 29, true));//uncommon
        loot.Add(new Item("RobesofIron", "Light Armor", 9, "Is that all you got?",0,0,0, Item.ItemType.ARMOR, 14, true));//rare
        loot.Add(new Item("RobesofTheAncients", "Light Armor", 10, "Smells of the old",0,0,0, Item.ItemType.ARMOR, 4, true));//legendary
        loot.Add(new Item("RobesofTheFallen", "Light Armor", 11, "Smells like the last victim",0,0,0, Item.ItemType.ARMOR, 14, true));//rare
        // loot drop items for medium armor
        loot.Add(new Item("Ancient Rangers Gear", "Medium Armor", 12, "Once Devine Race", 0, 0, 0, Item.ItemType.ARMOR, 4, true));//legendary
        loot.Add(new Item("Rangers Gear", "Medium Armor", 13, "Enough atittude to take it", 0, 0, 0, Item.ItemType.ARMOR, 3, true));//epic
        loot.Add(new Item("ReinforcedLeatherGear", "Medium Armor", 14, "More protection then paper", 0, 0, 0, Item.ItemType.ARMOR, 29, true));//uncommon
        loot.Add(new Item("Scouts Armor", "Medium Armor", 15, "Didn't work for the last person", 0, 0, 0, Item.ItemType.ARMOR, 40, true));//common
        loot.Add(new Item("Studded Leather Gear", "Medium Armor", 16, "Looks don't matter", 0, 0, 0, Item.ItemType.ARMOR, 14, true));//rare
        //loot drops for heavy armor
        loot.Add(new Item("Damaged Exosuit", "Heavy Armor", 17, "Takes a beating and keeps going", 0, 0, 0, Item.ItemType.ARMOR, 40, true));//common
        loot.Add(new Item("GuildedExosuit", "Heavy Armor", 18, "Be part of something", 0, 0, 0, Item.ItemType.ARMOR, 4, true));//legendary
        loot.Add(new Item("Plated Exosuit", "Heavy Armor", 19, "Bring on the pain!", 0, 0, 0, Item.ItemType.ARMOR, 3, true));//epic
        loot.Add(new Item("Reinforced Exosuit", "Heavy Armor", 20, "looks aren't everything...", 0, 0, 0, Item.ItemType.ARMOR, 14, true));//rare
        loot.Add(new Item("Standard Exosuit", "Heavy Armor", 21, "Skin offers better protection", 0, 0, 0, Item.ItemType.ARMOR, 29, true));//rare
        //loot drops for bow
        loot.Add(new Item("Arcane Bow", "Bow", 22, "Keep the Magic Strong", 0, 0, 0, Item.ItemType.WEAPON, 29, true));//rare
        loot.Add(new Item("Bow Of The Ancients", "Bow", 23, "Be part of something", 0, 0, 0, Item.ItemType.WEAPON, 4, true));//legendary
        loot.Add(new Item("Compound Bow", "Bow", 24, "Bring the pain!", 0, 0, 0, Item.ItemType.WEAPON, 3, true));//epic
        loot.Add(new Item("Reinforced Bow", "Bow", 25, "Can be reliable...", 0, 0, 0, Item.ItemType.WEAPON, 40, true));//uncommon
        loot.Add(new Item("Simple Bow", "Bow", 26, "beter then a stick", 0, 0, 0, Item.ItemType.WEAPON, 40, true));//common
        //loot for staff
        loot.Add(new Item("Enchanted Stick", "Staff", 27, "Keep the Magic Strong", 0, 0, 0, Item.ItemType.WEAPON, 29, true));//common
        loot.Add(new Item("Rookies Staff", "Staff", 28, "Be part of something", 0, 0, 0, Item.ItemType.WEAPON, 40, true));//uncommon
        loot.Add(new Item("Staff Of Flames", "Staff", 29, "Bring the pain!", 0, 0, 0, Item.ItemType.WEAPON, 14, true));//rare
        loot.Add(new Item("Staff Of The Ancients", "Staff", 30, "Can be reliable...", 0, 0, 0, Item.ItemType.WEAPON, 4, true));//legendary
        loot.Add(new Item("Staff Of The Forest", "Staff", 31, "Can be reliable...", 0, 0, 0, Item.ItemType.WEAPON, 3, true));//epic
        //loot for swords
        loot.Add(new Item("Cutlass", "Sword", 32, "Keep the Magic Strong", 0, 0, 0, Item.ItemType.WEAPON, 3, true));//epic
        loot.Add(new Item("Damaged Shortsword", "Sword", 33, "Be part of something", 0, 0, 0, Item.ItemType.WEAPON, 29, true));//common
        loot.Add(new Item("Shortsword", "Sword", 34, "Bring the pain!", 0, 0, 0, Item.ItemType.WEAPON, 40, true));//uncommon
        loot.Add(new Item("Sword of the Ancients", "Sword", 35, "Can be reliable...", 0, 0, 0, Item.ItemType.WEAPON, 4, true));//legendary
        loot.Add(new Item("Xiphost", "Sword", 36, "Can be reliable...", 0, 0, 0, Item.ItemType.WEAPON, 14, true));//rare
    }

    
}
