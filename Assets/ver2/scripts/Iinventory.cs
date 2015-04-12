using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Iinventory : MonoBehaviour
{
    public List<Itemm> inventory = new List<Itemm>();

    public int slotX, slotY;

    private Database database;

    private int[] slotIndex;
    private int selected;

    private bool show;
    
    // Use this for initialization
	void Start ()
    {
        database = GameObject.FindGameObjectWithTag("Database").GetComponent<Database>();

        slotIndex = new int[slotX * slotY];

        for(int i = 0; i < (slotX * slotY); i++)
        {
            inventory.Add(new Itemm());
            slotIndex[i] = i;
        }

        selected = 0;

        show = false;

        AddItem(1);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            selected = SelectSlot(inventory, selected, "up");
        if (Input.GetKeyDown(KeyCode.DownArrow))
            selected = SelectSlot(inventory, selected, "down");

        if (Input.GetKeyUp(KeyCode.I))
            show = !show;
	}

    private void OnGUI()
    {
        if(show)
            Draw();
    }

    private void Draw()
    {
        int i = 0;
        for(int y = 0; y < slotY; y++)
        {
            for(int x = 0; x < slotX; x++)
            {
                bool[] buttons = new bool[slotX * slotY];
                Rect slotRect = new Rect(Screen.width / 2 + x * 60, Screen.height / 2 + y * 60, 50, 50);

                GUI.SetNextControlName(slotIndex[i].ToString());

                buttons[i] = GUI.Button(slotRect, "");

                if(inventory[i].id != null)
                {
                    GUI.DrawTexture(slotRect, inventory[i].icon);

                    if (buttons[i])
                    {
                        DeleteItem(i);
                    }

                    GUI.FocusControl(slotIndex[selected].ToString());
                }

                i++;
            }
        }
    }

    private int SelectSlot(List<Itemm> slotList, int selected, string dir)
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
            if(inventory[i].id == id)
            {
                inventory[i] = new Itemm();
            }
        }
    }
}
