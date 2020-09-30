using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int slotsX, slotsY;
    public GUISkin skin;
    public List<Item> inventory = new List<Item>();
    public List<Item> slots = new List<Item>();
    private bool showInventory;
    private ItemDatabase database;    
    private bool showTooltip;
    private string tooltip;
    private bool draggingItem;
    private Item draggedItem;
    private int prevIndex;

    private const float ICON_XOFFSET = 100f;
    private const float ICON_YOFFSET = 75f;


    // Use this for initialization
    void Start () //add linventory items here
    {
        for (int i = 0; i < (slotsX * slotsY); i++)
        {
            slots.Add(new Item());
            inventory.Add (new Item());
        }
        database = new ItemDatabase();
        AddItem(0);
        AddItem(1);
        AddItem(2);
        AddItem(3);
        AddItem(4);
        AddItem(5);
        AddItem(6);
        AddItem(7);
        AddItem(8);
        AddItem(9);
        AddItem(10);
        AddItem(11);
        AddItem(12);
        AddItem(13);
        AddItem(14);
        AddItem(15);
        AddItem(16);
        AddItem(17);
        AddItem(18);
        AddItem(19);
        AddItem(20);
        AddItem(21);
        AddItem(22);
        AddItem(23);
        AddItem(24);
        AddItem(25);
        AddItem(26);
        AddItem(27);
        AddItem(28);
        AddItem(29);
        AddItem(30);
        AddItem(31);
        AddItem(32);
        AddItem(33);
        AddItem(34);
        AddItem(35);
        AddItem(36);        
        //RemoveItem(5);//removes items from certain spot.
        print (InventoryContains(0));        

    }
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            showInventory = !showInventory;
        }
    }
    // Update is called once per frame
    void OnGUI ()
    {
        tooltip = "";
        GUI.skin = skin;
        if(showInventory)
        {
            DrawInventory();
            if (showTooltip)
            {
                GUI.Box(new Rect(Event.current.mousePosition.x + 15f, Event.current.mousePosition.y, 200, 200), tooltip);
            }
            if (draggingItem)
            {
                GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 50, 50), draggedItem.itemIcon);
            }
        }		
        
	}
    void DrawInventory() //setting up inventory grid
    {
        Event e = Event.current;
        int i = 0;

        GUI.Box(new Rect(50, 50, slotsX * 60, slotsY * 60), "", skin.GetStyle("Slot"));
        for(int y = 0; y < slotsY; y++)
        {
            for(int x = 0; x < slotsX; x++)
            {
                Rect slotRect = new Rect(ICON_XOFFSET + (x * 39), ICON_YOFFSET+(y * 39), 50, 50);
                slots[i] = inventory[i];
                if (slots[i].itemName != null)
                {
                   GUI.DrawTexture(slotRect, slots[i].itemIcon);
                    if (slotRect.Contains(e.mousePosition))
                    {
                        tooltip = CreateTooltip(slots[i]);
                        showTooltip = true;
                        if (e.button == 0 && e.type == EventType.MouseDrag && !draggingItem)//drag items from or into inventory
                        {
                            draggingItem = true;
                            prevIndex = i;
                            draggedItem = slots[i];
                            inventory[i] = new Item();
                        }
                        if (e.type == EventType.MouseUp && draggingItem)
                        {
                            inventory[prevIndex] = inventory[i];//can drag and drop and switchout inv items
                            inventory[i] = draggedItem;
                            draggingItem = false;
                            draggedItem = null;
                        }
                    }
                    else
                    {
                        if (slotRect.Contains(e.mousePosition))//able to drag and drop in any inventory spot.
                        {
                            if (e.type == EventType.MouseUp && draggingItem)
                            {
                                inventory[i] = draggedItem;
                                draggingItem = false;
                                draggedItem = null;
                            }
                        }
                    }
                    if (tooltip == "")
                    {
                        showTooltip = false;
                    }
                }
                i++;
                // draw items in slots here...
            }
        }
    }
    string CreateTooltip (Item item)//hover mouse over item and it displays name of item
    {
        tooltip = item.itemName + "\n\n" + item.itemDesc;
        return tooltip;
    }
    void RemoveItem (int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemID == id)
            {
                inventory[i] = new Item();
                break;
            }
        }
    }
    void AddItem(int id) //base the item of the invetory instead of the database, helps not messing it up from the index.
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemName == null)
            {
                for (int j = 0; j < database.items.Count; j++)
                {
                    if (database.items[j].itemID == id)
                    {
                        inventory[i] = database.items[j];
                    }
                }                
                break;
            }
        }
    }   
    bool InventoryContains(int id)//Inventory check method
    {
        bool result = false;
        for (int i = 0; i < inventory.Count; i++)
        {
            result = inventory[i].itemID == id;//checking condition
            if (result)
            {
                break;
            }
        }
        return result;
    }
}
