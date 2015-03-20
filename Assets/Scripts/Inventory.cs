using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// dont try to do inventory with arrays
// if you want to navigate it with keyboard
// adding and deleting from it is a pain
public class Inventory : MonoBehaviour
{
    public int slotsX, slotsY;
    public GUISkin skin;
    public List<Item> slots = new List<Item>();
    public List<Item> inventory = new List<Item>();
    private ItemDatabase itemDatabase;
    public bool showInventory;
    private bool showTooltip;
    private string tooltip;
    private bool inventoryFull;
    private int selected;
    private int[] slotIndexes;

    // Use this for initialization
    void Start()
    {
        selected = 0;

        // add empty items to inventory slots
        for (int i = 0; i < (slotsX * slotsY); i++)
        {
            slots.Add(new Item());
            inventory.Add(new Item());
        }

        slotIndexes = new int[slotsX * slotsY];
        for (int i = 0; i < (slotsX * slotsY); i++)
        {
            slotIndexes[i] = i;
        }

        itemDatabase = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();

        AddItem(1);
        AddItem(2);
        AddItem(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            showInventory = !showInventory;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
            selected = SlotSelectionVertical(slots, selected, "up");
        if (Input.GetKeyDown(KeyCode.DownArrow))
            selected = SlotSelectionVertical(slots, selected, "down");
    }

    void OnGUI()
    {
        tooltip = "";
        GUI.skin = skin;
        if (showInventory)
            DrawInventory();

        if (showTooltip)
        {
            GUI.Box(new Rect(Screen.width / 2 + 210, Screen.height / 2 + 60, 100, 100), tooltip, skin.GetStyle("Tooltip"));
        }

        if (inventoryFull && showTooltip)
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 100), "Inventory full", skin.GetStyle("Tooltip"));
    }

    //private int SlotSelectionHorizontal(List<Item> slotList, int selectedItem, string direction)
    //{
    //    if(direction == "
    //    return selectedItem;
    //}

    private int SlotSelectionVertical(List<Item> slotList, int selectedItem, string direction)
    {
        if (direction == "up")
        {
            if (selectedItem == 0)
            {
                selectedItem = slotList.Count - 1;
            }
            else
                selectedItem -= 1;
        }

        if (direction == "down")
        {
            if (selectedItem == slotList.Count - 1)
            {
                selectedItem = 0;
            }
            else
                selectedItem += 1;
        }

        return selectedItem;
    }

    void DrawInventory()
    {
        int i = 0;
        for (int y = 0; y < slotsY; y++)
        {
            for (int x = 0; x < slotsX; x++)
            {
                bool[] buttons = new bool[slotsX * slotsY];
                // in Unity make guiskin to use custom gui elements
                Rect slotRect = new Rect(Screen.width / 2 + x * 60, Screen.height / 2 + y * 60, 50, 50);

                GUI.SetNextControlName(slotIndexes[i].ToString());

                buttons[i] = GUI.Button(slotRect, "", skin.GetStyle("Slot"));
                slots[i] = inventory[i];

                if (slots[i].itemID != null)
                {
                    GUI.DrawTexture(slotRect, slots[i].itemIcon);

                    if(GUI.GetNameOfFocusedControl() == i.ToString())
                    {
                        tooltip = CreateTooltip(slots[i]);
                        showTooltip = true;
                    }

                    if(buttons[i])
                    {
                        // ei toimi, poistaa edellisen itemin
                        //RemoveItem(slotIndexes[i]);
                    }

                    //if (slotRect.Contains(Event.current.mousePosition))
                    //{
                    //    tooltip = CreateTooltip(slots[i]);
                    //    showTooltip = true;

                    //    if (Event.current.isMouse && Event.current.type == EventType.mouseDown && Event.current.button == 1)
                    //    {
                    //        if (slots[i].itemType == Item.ItemTypes.CONSUMABLE)
                    //        {
                    //            Debug.Log("consumable");
                    //        }
                    //    }
                    //}

                    GUI.FocusControl(slotIndexes[selected].ToString());
                }
                // fix null texture passed to GUI.DrawTexture
                //else
                //{
                //    GUI.DrawTexture(slotRect, new Texture2D);
                //}
                // "fixes" a bug where tooltip is showing while it should not
                if (tooltip == null || tooltip == "" || tooltip == "<color=#610144>" + "" + "</color>\n\n" + "")
                    showTooltip = false;

                i++;
            }
        }
    }

    public void AddItem(int id)
    {
        // do not add more than one same type of item, cannot remove them separately
        for (int i = 0; i < inventory.Count; i++)
        {
            // use itemname, value of id isnt null
            if (inventory[i].itemName == null)
            {
                for (int j = 0; j < itemDatabase.items.Count; j++)
                {
                    if (itemDatabase.items[j].itemID == id)
                    {
                        inventory[i] = itemDatabase.items[j];
                    }
                }
                break;
            }
            // create a rule when inventory is full player will notice that
            //else
            //{
            //    inventoryFull = true;
            //}

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
            if (result)
            {
                break;
            }
        }
        return result;
    }

    string CreateTooltip(Item item)
    {
        tooltip = "";
        tooltip += "<color=#610144>" + item.itemName + "</color>\n\n" + item.itemDescription;

        return tooltip;
    }
}