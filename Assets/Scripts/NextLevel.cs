using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour
{
    public Camera stillCamera; // kun teleporttaus on tapahtunut,
    public float x, y;          //asetetaan liikkumaton kamera paikoilleen
    public GUISkin skin;
    public GameObject player;
    private PlayerControl playerControl;
    private Examine examine;
    private FadeOut fadeOut;

    // player's new position
    public float cameraX, cameraY;

    private float boxW, boxH, boxL, boxT;

    public string transferText;
    //private string current;
    private string[] buttons = { "Yes.", "No." };
    private int selected;
    private bool showBox, showButtons, move;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        examine = GetComponent<Examine>();
        fadeOut = GameObject.FindGameObjectWithTag("Holder").GetComponent<FadeOut>();

        boxW = 1.14f;
        boxH = 3.6f;
        boxL = 16.56f;
        boxT = 1.55f;

        showButtons = false;
        move = false;
    }

    private void Update()
    {
        if(showBox)
            playerControl.isStopped = true;
        else
            playerControl.isStopped = false;

        if (showButtons)
        {
            WhichButton();
        }

        //Debug.Log(showButtons);
    }

    private void MovePlayer()
    {
        if(stillCamera != null)
            stillCamera.transform.position = new Vector3(x, y, -10);
        else
        {
            // jos scripti on kiinni prefabissa
            Camera prefabCam = GameObject.FindGameObjectWithTag("Still").GetComponent<Camera>();
            prefabCam.transform.position = new Vector3(x, y, -10);
        }
        player.transform.position = new Vector3(cameraX, cameraY);
    }

    private void OnGUI()
    {
        Rect boxRect = new Rect(Screen.width / boxL, Screen.height / boxT,
            Screen.width / boxW, Screen.height / boxH);
        GUI.skin = skin;
        if(showBox)
        {
            if (showButtons)
            {
                GUI.Box(boxRect, transferText, "Wilhelm");
                CreateButtons();
            }
        }
    }

    private void CreateButtons()
    {
        Rect yesRect = new Rect(Screen.width / 8, Screen.height / 1.2f, Screen.width / 8, Screen.height / 8.5f);
        Rect noRect = new Rect(Screen.width / 3.5f, Screen.height / 1.2f, Screen.width / 8, Screen.height / 8.5f);

        if (showButtons)
        {
            GUI.SetNextControlName(buttons[0]);
            if (GUI.Button(yesRect, buttons[0], "CustomButton"))
            {
                fadeOut.StartFading();
                showBox = false;
                showButtons = false;
                move = true;
                //playerControl.isStopped = false;
            }

            GUI.SetNextControlName(buttons[1]);
            if (GUI.Button(noRect, buttons[1], "CustomButton"))
            {
                showBox = false;
                showButtons = false;
                //playerControl.isStopped = false;
                move = false;
            }

            GUI.FocusControl(buttons[selected]);
        }
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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selected = ButtonSelection(buttons, selected, "up");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selected = ButtonSelection(buttons, selected, "down");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            showBox = true;
            examine.enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKeyUp(KeyCode.Space))
                showButtons = true;

            if (move)
            {
                Invoke("MovePlayer", 0.7f);
                move = false;
            }
        }


        //if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
        //{
        //    showButtons = true;
        //}
        //if (col.gameObject.tag == "Player" && move && showButtons)
        //{
        //    Invoke("MovePlayer", 0.7f);
        //    move = false;
        //}
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            examine.enabled = false;
        }
    }
}