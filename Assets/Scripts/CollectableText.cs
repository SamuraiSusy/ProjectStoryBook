using UnityEngine;
using System.Collections;
//POISTETAAN
public class CollectableText : MonoBehaviour
{
    public GUISkin skin;
    // kiinnitä ykso jokaiseen objektiin!!!11!
    //public string first;
    public int itemID;
    public string[] text;
    public string text2;
    private bool collided;
    private bool show, show2;
    private bool showButtons;
    private string temp;
    private int count;

    public string[] buttons = new string[2];
    private int selected;

    private PlayerControl playerControl;
    private Inventory inventory;
    private Examine examine;

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
        examine = GetComponent<Examine>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && show || show2)
        {
            playerControl.isStopped = false;
            WhichText();
        }

        if(showButtons)
            WhichButton();

        if (!show)
        {
            examine.showExaminedItem = false;
        }
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

        if (show || show2 && examine.examinedItem != null)
        {
            GUI.Box(boxRect, temp, "Wilhelm");
            examine.showExaminedItem = true;
        }
        else if (show || show2 && examine.examinedItem == null)
        {
            GUI.Box(boxRect, temp, "Wilhelm");
            examine.showExaminedItem = false;
        }

        if (showButtons)
            CreateButtons();

    }

    private void CreateButtons()
    {
        GUI.SetNextControlName(buttons[0]);
        if (GUI.Button(new Rect(0, 0, 100, 100), buttons[0], "Wilhelm"))
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
        if (GUI.Button(new Rect(0, 100, 100, 100), buttons[1], "Wilhelm"))
        {
            count = 0;
            show2 = false;
            temp = text[count];
            showButtons = false;
        }

        GUI.FocusControl(buttons[selected]);
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
        }
    }
}