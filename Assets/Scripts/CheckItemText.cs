using UnityEngine;
using System.Collections;

public class CheckItemText : MonoBehaviour
{
    public GUISkin skin;
    // kiinnitä ykso jokaiseen objektiin!!!11!
    //public string first;
    public int itemID;
    public string[] text;
    public string[] text2;
    private bool collided;
    private bool show, show2;
    private string temp;
    private int count;

    private string[] buttons = { "kylla", "ei" };
    private int selected;

    private PlayerControl playerControl;
    private Inventory inventory;
    private DestroyCreateEnable destroyCreate;

    public GameObject prefab;
    public GameObject destroiableGO;
    public float newX, newY;

    // Use this for initialization
    private void Start()
    {
        collided = false;
        show = false;
        show2 = false;
        count = 0;

        selected = 0;

        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        inventory = GameObject.FindGameObjectWithTag("Holder").GetComponent<Inventory>();
        destroyCreate = GetComponent<DestroyCreateEnable>();

        if (!inventory.InventoryContains(itemID))
            temp = text[0];
        else
            temp = text2[0];
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && show || show2)
        {
            playerControl.isStopped = false;
            WhichText();
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
                temp = text[0];
                show = false;
            }
        }

        else if (show2)
        {
            temp = text2[count];
            count++;

            if (count == text2.Length)
            {
                CreateTeleporter();
                show2 = false;
            }
        }
    }

    private void CreateTeleporter()
    {
        destroyCreate.CreateGO(prefab, new Vector3(newX, newY));
        destroyCreate.DestoryGameObject(destroiableGO, 0);
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        Rect boxRect = new Rect(300, 300, 150, 100);
        if (show || show2)
            GUI.Box(boxRect, temp, "box");
    }

    //private void CreateButtons()
    //{
    //    GUI.SetNextControlName(buttons[0]);
    //    if (GUI.Button(new Rect(0, 0, 100, 100), buttons[0], "box"))
    //    {
    //        inventory.AddItem(itemID);
    //        count = 0;
    //        show2 = false;
    //        temp = text[count];
    //        showButtons = false;
    //        playerControl.isStopped = false;
    //        Destroy(this.gameObject);
    //    }

    //    GUI.SetNextControlName(buttons[1]);
    //    if (GUI.Button(new Rect(0, 100, 100, 100), buttons[1], "box"))
    //    {
    //        count = 0;
    //        show2 = false;
    //        temp = text[count];
    //        showButtons = false;
    //    }

    //    GUI.FocusControl(buttons[selected]);
    //}

    //private int ButtonSelection(string[] buttonsArray, int selectedItem, string direction)
    //{
    //    if (direction == "up")
    //    {
    //        if (selectedItem == 0)
    //        {
    //            selectedItem = buttonsArray.Length - 1;
    //        }
    //        else
    //        {
    //            selectedItem -= 1;
    //        }
    //    }

    //    if (direction == "down")
    //    {
    //        if (selectedItem == buttonsArray.Length - 1)
    //        {
    //            selectedItem = 0;
    //        }
    //        else
    //        {
    //            selectedItem += 1;
    //        }
    //    }
    //    return selectedItem;
    //}

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
            if (!inventory.InventoryContains(itemID))
                show = true;
            else
                show2 = true;
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