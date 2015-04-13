using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour
{
    public GameObject player;
    private PlayerControl playerControl;

    public float point;
    public float cameraX, cameraY;

    private string[] buttons = { "kylla", "ei" };
    private int selected;
    private bool showButtons, move;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();

        showButtons = false;
        move = false;
    }

    private void Update()
    {
        if(showButtons)
            WhichButton();
    }

    private void OnGUI()
    {
        if(showButtons)
            CreateButtons();
    }

    private void CreateButtons()
    {
        GUI.SetNextControlName(buttons[0]);
        if (GUI.Button(new Rect(0, 0, 100, 100), buttons[0]))
        {
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
            player.transform.position = new Vector3(cameraX, cameraY);
            move = false;
        }
    }
}