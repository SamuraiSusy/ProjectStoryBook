using UnityEngine;
using System.Collections;

public class CollectAndCreateNew : MonoBehaviour
{
    public GUISkin skin;
    // kiinnitä ykso jokaiseen objektiin!!!11!
    //public string first;
    public int itemID;
    public string[] text;
    public string text2;
    private bool collided;
    private bool show, show2, show3; // 3 only if a sertain item is needed
    private bool showButtons;
    private string temp;
    private int count;

    public string[] buttons = new string[2];
    private int selected;

    private PlayerControl playerControl;
    private Inventory inventory;
    private Examine examine;
    private DestroyCreateEnable deastroyCreate;
    private FadeOut fadeOut;
    private Text textfield;

    public Sprite newBackgroundPicture;
    public float newImagePosX, newImagePosY;

    public GameObject prefab, prefab2, destroiableGO;
    public string gameObjectName;
    public bool activate, isActive;
    public float newX, newY, newX2, newY2;
    public bool needsItem;  // if it is required to have another item
    public int otherItemID; // to destroy this object

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
        if(playerControl == null)
        {
            Debug.LogError("playercontrol not found D:");
            this.enabled = false;
            return;
        }
        inventory = GameObject.FindGameObjectWithTag("Holder").GetComponent<Inventory>();
        examine = GetComponent<Examine>();
        deastroyCreate = GetComponent<DestroyCreateEnable>();
        fadeOut = GameObject.FindGameObjectWithTag("Holder").GetComponent<FadeOut>();
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
            CreateNew();
            Invoke("DestroyCollected", 0.9f);
        }

        GUI.SetNextControlName(buttons[1]);
        if (GUI.Button(new Rect(0, 100, 100, 100), buttons[1], "Wilhelm"))
        {
            count = 0;
            show2 = false;
            temp = text[count];
            showButtons = false;
            playerControl.isStopped = false;
        }

        GUI.FocusControl(buttons[selected]);
    }
    private void DestroyCollected()
    {
        Destroy(this.gameObject);
    }

    // creates new object, "clone"
    private void CreateNew()
    {
        Debug.Log(prefab.name);
        fadeOut.StartFading();
        deastroyCreate.CreateGO(prefab, new Vector3(newX, newY));
        if (prefab2 != null)
        {
            Debug.Log(1);
            deastroyCreate.CreateGO(prefab2, new Vector3(newX2, newY2));
            deastroyCreate.DestoryGameObject(destroiableGO, 0);
        }
        if (activate)
            EnableOrDisable();

        if (newBackgroundPicture != null)
            Invoke("CreateNewBackground", 0.5f);
    }

    private void EnableOrDisable()
    {
        deastroyCreate.EnableDisableContent(gameObjectName, isActive);
    }

    // you can for example set new background picture
    private void CreateNewBackground()
    {
        Debug.Log("hi");
        GameObject newBackground = new GameObject();
        newBackground.AddComponent<SpriteRenderer>();
        newBackground.GetComponent<SpriteRenderer>().sprite = newBackgroundPicture;
        newBackground.transform.position = new Vector3(newImagePosX, newImagePosY);
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