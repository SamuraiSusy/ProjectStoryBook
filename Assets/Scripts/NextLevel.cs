using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour
{
    public GUISkin skin;
    public GameObject player;
    public float playerBetween1, playerBetween2;
    private PlayerControl playerControl;
    private FadeOut fadeOut;

    //public float point;
    public float cameraX, cameraY;

    //public bool muttuja jonka avulla seuraava kenttä määritellään

    private string[] buttons = { "kylla", "ei" };
    private int selected;
    private bool showButtons, move;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        fadeOut = GameObject.FindGameObjectWithTag("Holder").GetComponent<FadeOut>();

        showButtons = false;
        move = false;
    }

    private void Update()
    {
    //    if (player.transform.position.y > playerBetween1 &&
    //            player.transform.position.y <= playerBetween2)
    //        this.enabled = true;
    //    else
    //        this.enabled = false;

        if (showButtons)
        {
            CreateButtons();
            WhichButton();
        }
    }

    private void MovePlayer()
    {
        player.transform.position = new Vector3(cameraX, cameraY);
    }

    private void OnGUI()
    {
        if(showButtons)
        {
            GUI.Box(new Rect(100, 100, 100, 100), "Haluatko siirtyä seuraavalle tasolle?");
            CreateButtons();
        }
    }

    private void CreateButtons()
    {
        GUI.SetNextControlName(buttons[0]);
        if (GUI.Button(new Rect(0, 0, 100, 100), buttons[0]))
        {
            fadeOut.StartFading();
            showButtons = false;
            move = true;
        }

        GUI.SetNextControlName(buttons[1]);
        if (GUI.Button(new Rect(0, 100, 100, 100), buttons[1]))
        {
            showButtons = false;
            move = false;
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
            showButtons = true;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && move)
        {
            Invoke("MovePlayer", 0.7f);
            move = false;
        }
    }
}