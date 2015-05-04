﻿using UnityEngine;
using System.Collections;

public class PaintingWomanWithPin : MonoBehaviour
{
    public GUISkin skin;
    // kiinnitä ykso jokaiseen objektiin!!!11!
    //public string first;
    public int itemID;
    public string[] text; // tämän pituus saa olla saman pituinen kuin tekstiä on
    public string text2;
    private bool collided;
    private bool show, show2;
    private bool showButtons;
    private string temp;
    private int count;

    private string[] buttons = { "Take it.", "Leave it." };
    private int selected;

    private PlayerControl playerControl;
    private Inventory inventory;
    private Examine examine;
    private DestroyCreateEnable destroyCreateEnable;

    // hairpinless woman
    public GameObject prefab;
    public GameObject destroiableGO;

    // Use this for initialization
    private void Start()
    {
        collided = false;
        show = false;
        show2 = false;
        showButtons = false;
        count = 0;
        temp = text[0];

        selected = 0;

        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        inventory = GameObject.FindGameObjectWithTag("Holder").GetComponent<Inventory>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && show || show2)
        {
            playerControl.isStopped = false;
            WhichText();
        }

        if (showButtons)
            WhichButton();
    }

    private void WhichText()
    {
        if (show)
        {
            temp = text[count];
            count++;

            if (count == text.Length)
            {
                count = 0;
                temp = text2;
                show = false;
                show2 = true;
            }
        }

        else if (show2)
        {
            temp = text2;
            showButtons = true;
        }
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        Rect boxRect = new Rect(300, 300, 150, 100);
        if (show || show2)
            GUI.Box(boxRect, temp, "box");

        if (showButtons)
            CreateButtons();
    }

    private void CreateButtons()
    {
        GUI.SetNextControlName(buttons[0]);
        if (GUI.Button(new Rect(0, 0, 100, 100), buttons[0], "box"))
        {
            inventory.AddItem(itemID);
            count = 0;
            show2 = false;
            temp = text[count];
            showButtons = false;
            playerControl.isStopped = false;
            Destroy(this.gameObject);
        }

        GUI.SetNextControlName(buttons[1]);
        if (GUI.Button(new Rect(0, 100, 100, 100), buttons[1], "box"))
        {
            count = 0;
            show2 = false;
            temp = text[count];
            showButtons = false;
        }

        GUI.FocusControl(buttons[selected]);
    }

    private void TakePin()
    {
        destroyCreateEnable.CreateGO(prefab, new Vector3(7.35f, -40.1f));
        destroyCreateEnable.DestoryGameObject(destroiableGO, 0);
    }

    private int ButtonSelection(string[] buttonsArray, int selectedItem, string direction)
    {
        if (direction == "up")
        {
            if (selectedItem == 0)
            {
                selectedItem = buttonsArray.Length - 1;
            }
            else
            {
                selectedItem -= 1;
            }
        }

        if (direction == "down")
        {
            if (selectedItem == buttonsArray.Length - 1)
            {
                selectedItem = 0;
            }
            else
            {
                selectedItem += 1;
            }
        }
        return selectedItem;
    }

    private void WhichButton()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selected = ButtonSelection(buttons, selected, "up");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selected = ButtonSelection(buttons, selected, "down");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            collided = true;
            examine.enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (collided && Input.GetKeyDown(KeyCode.Space))
        {
            collided = false;
            show = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            collided = false;
            examine.enabled = false;
        }
    }
}