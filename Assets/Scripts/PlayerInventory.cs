using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour
{
    private ItemDatabase database;
    public GUISkin skin;
    public int slotsX, slotsY;
    public bool[] inventory;
    private Item[] tempICON;
    public bool showInventory;
    private bool showTooltip;
    private string tooltip;
    private bool inventoryFull;

	// Use this for initialization
	private void Start ()
    {
        database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
        showInventory = false;
        showTooltip = false;
        inventoryFull = false;

        inventory = new bool[slotsX * slotsY];
        tempICON = new Item[slotsX * slotsY];
        for(int i = 0; i < (slotsX * slotsY); i++)
        {
            tempICON[i] = new Item();
        }

        AddItem(0);
        Debug.Log(tempICON[0].itemName);
	}
	
	// Update is called once per frame
	private void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.I))
        {
            showInventory = !showInventory;
        }
	}

    private void OnGUI()
    {
        GUI.skin = skin;

        if (showInventory)
            DrawInventory();
    }

    private void DrawInventory()
    {
        int i = 0;
        for(int y = 0; y < slotsY; y++)
        {
            for(int x = 0; x < slotsX; x++)
            {
                Rect slotRect = new Rect(Screen.width / 2 + x * 60, Screen.height / 2 + y * 60, 50, 50);
                inventory[i] = GUI.Button(slotRect, tempICON[i].itemName, skin.GetStyle("Slot"));

                if(inventory[i])
                {
                    //removeitem
                    Debug.Log("hellohelloyay");
                }
            }
            i++;
        }
    }

    public void AddItem(int id)
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            if(tempICON[i].itemName == null)
            {
                for(int j = 0; j < database.items.Count; j++)
                {
                    if (database.items[j].itemID == id)
                    {
                        tempICON[i] = database.items[j];
                    }
                }
            }
            break;
        }
    }

    private void RemoveItem(int id)
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            if(tempICON[i].itemID == id)
            {
                tempICON[i] = new Item();
                break;
            }
        }
    }

    private string CreateTooltip(Item item)
    {
        tooltip = "";
        tooltip += tooltip += "<color=#610144>" + item.itemName + "</color>\n\n" + item.itemDescription;

        return tooltip;
    }
}