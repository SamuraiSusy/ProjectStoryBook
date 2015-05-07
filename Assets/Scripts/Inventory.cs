using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public GUISkin skin;

    public List<Item> inventory = new List<Item>();

    public int slotX, slotY;

    private Database database;
    private PlayerControl playerControl;

    private int[] slotIndex;
    private int selected;

    private bool show;
    
    // Use this for initialization
	private void Start ()
    {
        database = GameObject.FindGameObjectWithTag("Holder").GetComponent<Database>();
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();

        slotIndex = new int[slotX * slotY];

        for(int i = 0; i < (slotX * slotY); i++)
        {
            inventory.Add(new Item());
            slotIndex[i] = i;
        }

        selected = 0;

        show = false;

        AddItem(2);
	}
	
	// Update is called once per frame
	private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            selected = SelectSlot(inventory, selected, "up");
        if (Input.GetKeyDown(KeyCode.DownArrow))
            selected = SelectSlot(inventory, selected, "down");

        if (Input.GetKeyUp (KeyCode.I))
		{
			show = !show;
			playerControl.isStopped = false;
		}

        if(Input.GetKeyDown(KeyCode.F1))
        {
            for(int i = 0; i < inventory.Count;i++)
            {
                Debug.Log("inventory: [" + i + "] " + inventory[i] + " " + inventory[i].id + " " + inventory[i].name);
            }
        }
	}

    private void OnGUI()
    {
        if (show)
        {
            playerControl.isStopped = true;
            Draw();
        }
    }

    private void Draw()
    {
        GUI.skin = skin;

        Rect iconRect = new Rect(200, 200, 100, 100);
        Rect textRect = new Rect(200, 300, 100, 50);
        GUI.Box(iconRect, "", "box");
        GUI.Box(textRect, "", "box");
        int i = 0;
        for(int y = 0; y < slotY; y++)
        {
            for(int x = 0; x < slotX; x++)
            {
                bool[] buttons = new bool[slotX * slotY];
                Rect slotRect = new Rect(Screen.width / 2 + x * 60, Screen.height / 2 + y * 60, 50, 50);

                GUI.SetNextControlName(slotIndex[i].ToString());

                buttons[i] = GUI.Button(slotRect, "", "box");

                if(inventory[i].id != null)
                {
                    GUI.DrawTexture(slotRect, inventory[i].icon);

                    if (GUI.GetNameOfFocusedControl() == slotIndex[i].ToString())
                    {
                        GUI.DrawTexture(iconRect, inventory[i].icon);
                        // when item has been removed still shows its description
                        GUI.Box(textRect, inventory[i].description, "box");
                    }

                    if (buttons[i])
                    {
                        Debug.Log("inv" + inventory[i].id+ " i " + i);
                        DeleteItem(inventory[i].id);
                    }

                    GUI.FocusControl(slotIndex[selected].ToString());
                }

                i++;
            }
        }
    }

    private int SelectSlot(List<Item> slotList, int selected, string dir)
    {
        if(dir == "up")
        {
            if (selected == 0)
                selected = slotList.Count - 1;
            else
                selected -= 1;
        }

        if(dir == "down")
        {
            if (selected == slotList.Count - 1)
                selected = 0;
            else
                selected += 1;
        }

        return selected;
    }

    public void AddItem(int id)
    {
        for(int i = 0; i < inventory.Count; i++)
        {
            if(inventory[i].name == null)
            {
                for(int j = 0; j < database.items.Count; j++)
                {
                    if(database.items[j].id == id)
                    {
                        inventory[i] = database.items[j];
                    }
                }
                break;
            }
        }
    }

    public void DeleteItem(int id)
    {
        for(int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].id == id)
            {
                inventory[i].icon = null;
            }
        }
    }

    public bool InventoryContains(int id)
    {
        bool result = false;

        for (int i = 0; i < inventory.Count; i++)
        {
            result = inventory[i].id == id;
            if (result)
            {
                break;
            }
        }
        return result;
    }
}
