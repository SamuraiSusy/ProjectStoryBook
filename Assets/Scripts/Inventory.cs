using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public int slotsX, slotsY;
    public GUISkin skin;
    public List<Item> inventory = new List<Item>();
    public List<Item> slots = new List<Item>();
    private ItemDatabase itemDatabase;
    public bool showInventory;
    private bool showTooltip;
    private string tooltip;

	// Use this for initialization
	void Start ()
    {
        // add empty items to inventory slots
        for(int i = 0; i < (slotsX * slotsY); i++)
        {
            slots.Add(new Item());
            inventory.Add(new Item());

        }

        itemDatabase = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
        AddItem(1);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            showInventory = !showInventory;
        }
	}

    void OnGUI()
    {
        tooltip = "";
        GUI.skin = skin;
        if (showInventory)
        {
            DrawInventory();
        }
        if(showTooltip)
        {
            GUI.Box(new Rect(Event.current.mousePosition.x + 15, Event.current.mousePosition.y, 100, 100), tooltip, skin.GetStyle("Tooltip"));
        }
    }

    void DrawInventory()
    {
        int i = 0;
        for (int y = 0; y < slotsY; y++)
        {
            for (int x = 0; x < slotsX; x++)
            {
                // in Unity make guiskin to use custom gui elements
                Rect slotRect = new Rect(Screen.width / 2 + x * 60, Screen.height / 2 + y * 60, 50, 50);
                GUI.Box(slotRect,"", skin.GetStyle("Slot"));
                slots[i] = inventory[i];

                if(slots[i].itemID != null)
                {
                    GUI.DrawTexture(slotRect, slots[i].itemIcon);
                    if(slotRect.Contains(Event.current.mousePosition))
                    {
                        tooltip = CreateTooltip(slots[i]);
                        showTooltip = true;
                        if(Input.GetKeyDown(KeyCode.Mouse0))
                        {
                            RemoveItem(slots[i].itemID);
                        }
                    }
                }
                // fix null texture passed to GUI.DrawTexture
                //else
                //{
                //    GUI.DrawTexture(slotRect, new Texture2D);
                //}
                if (tooltip == null || tooltip == "")
                    showTooltip = false;
                i++;
            }
        }
    }

    public void AddItem(int id)
    {
        // do not add more than one same type of item, cannot remove them separately
        for(int i = 0; i < inventory.Count; i++)
        {
            // use itemname
            if(inventory[i].itemName == null)
            {
                for (int j = 0; j < itemDatabase.items.Count; j++)
                {
                    if(itemDatabase.items[j].itemID == id)
                    {
                        inventory[i] = itemDatabase.items[j];
                    }
                }
                break;
            }
        }
    }

    void RemoveItem(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemID == id)
            {
                // doesnt delete the slot, only fills it with empty item
                inventory[i] = new Item();
                break;
            }
        }
    }

    // if has to be check if item is in inventory (puzzle tadaa)
    bool InventoryContains(int id)
    {
        bool result = false;

        for (int i = 0; i < inventory.Count; i++)
        {
            result = inventory[i].itemID == id;
            if(result)
            {
                break;
            }
        }
        return result;
    }

    string CreateTooltip(Item item)
    {
        tooltip = item.itemDescription;

        return tooltip;
    }
}