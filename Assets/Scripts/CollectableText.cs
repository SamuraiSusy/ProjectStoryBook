using UnityEngine;
using System.Collections;

public class CollectableText : MonoBehaviour
{

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

    private string[] buttons = { "kylla", "ei" };
    private int selected;

    private Inventory inventory;

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

        inventory = GameObject.FindGameObjectWithTag("Database").GetComponent<Inventory>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && show || show2)
        {
            WhichText();
        }

        if(showButtons)
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
        Rect boxRect = new Rect(300, 300, 150, 100);
        if (show || show2)
            GUI.Box(boxRect, temp);

        if (showButtons)
            CreateButtons();
    }

    private void CreateButtons()
    {
        GUI.SetNextControlName(buttons[0]);
        if (GUI.Button(new Rect(0, 0, 100, 100), buttons[0]))
        {
            inventory.AddItem(itemID);
            count = 0;
            show2 = false;
            temp = text[count];
            showButtons = false;
            Destroy(this.gameObject);
        }

        GUI.SetNextControlName(buttons[1]);
        if (GUI.Button(new Rect(0, 100, 100, 100), buttons[1]))
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