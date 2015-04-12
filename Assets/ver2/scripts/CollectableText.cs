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
    private bool show, show2, box;
    private bool showButtons, lo;
    private string temp;
    private int count, count2;

    private string[] buttons = { "kylla", "ei" };
    private int selected;

    private Iinventory inventory;

    // Use this for initialization
    void Start()
    {
        collided = false;
        show = false;
        show2 = false;
        box = false;
        showButtons = false;
        lo = false;
        count = 0;
        count2 = 0;
        temp = text[0];

        selected = 0;

        inventory = GameObject.FindGameObjectWithTag("Database").GetComponent<Iinventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (box)
        {
            show = true;
            box = false;
            count = 0;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            WhichText();
            count++;
        }

        WhichButton();

        Debug.Log(count);
    }

    private void WhichText()
    {
        if (show)
        {
            temp = text[count];

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
            count2 = 0;
            count = 0;
            show2 = false;
            temp = text[count];
            showButtons = false;
            Destroy(gameObject);
        }

        GUI.SetNextControlName(buttons[1]);
        if (GUI.Button(new Rect(0, 100, 100, 100), buttons[1]))
        {
            count2 = 0;
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
            box = true;
            collided = false;
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
