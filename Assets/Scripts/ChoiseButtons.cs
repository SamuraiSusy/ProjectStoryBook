using UnityEngine;
using System.Collections;

public class ChoiseButtons : MonoBehaviour
{
    public GUISkin skin;
    public bool showButtons;
    public string[] buttons;
    public int selectedButton;
    public float butL, butT, butW, butH;

    private MessageBox box;
    private MessagePlaceholders messages;
    private AnswersPlaceholders answer;
    
	// Use this for initialization
	private void Start ()
    {
        box = GetComponent<MessageBox>();
        answer = GetComponent<AnswersPlaceholders>();
		messages = GetComponent<MessagePlaceholders>();
        showButtons = false;
        buttons = answer.answersArray[0];
        butL = Screen.width / 1.3f;
        butT = Screen.height / 1.8f;
        butW = Screen.width / 6.4f;
        butH = Screen.height / 9.6f;

        selectedButton = 0;
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
            selectedButton = ButtonSelection(buttons, selectedButton, "down");

        if (Input.GetKeyDown(KeyCode.UpArrow))
            selectedButton = ButtonSelection(buttons, selectedButton, "up");
    }
	
    private void OnGUI()
    {
        if(showButtons)
            ButtonControl(buttons);
    }

    // function that allows button control with keyboard
    private void ButtonControl(string[] buttonsArray)
    {
        GUI.skin = skin;
        float offset = 0f;

        //for(int i = 0; i < buttonsArray.Length; i++)
        //{
        //    GUI.SetNextControlName(buttonsArray[i]);
        //    buttonID[i] = GUI.Button(new Rect(butL, butT + offset, butW, butH), buttonsArray[i], skin.GetStyle("Button"));

        //    if (i == messages.choises.Length - 1)
        //    {
        //        if (buttonID[0])
        //        {
        //            box.currentMessage = messages.choises[i - 1][box.count2];
        //            showButtons = false;
        //            Debug.Log("juu1");
        //        }
        //        if (buttonID[1])
        //        {
        //            box.currentMessage = messages.choises[i][box.count2];
        //            showButtons = false;
        //            Debug.Log("ei1");
        //        }
        //    }
        //    else
        //    {
        //        if (buttonID[0])
        //        {
        //            box.currentMessage = messages.choises[i][box.count2];
        //            showButtons = false;
        //            Debug.Log("juu2");
        //        }
        //        if (buttonID[1])
        //        {
        //            box.currentMessage = messages.choises[i + 1][box.count2];
        //            showButtons = false;
        //            Debug.Log("ei2");
        //        }
        //    }

        //    offset += butH;
        //}
        //GUI.FocusControl(buttonsArray[selectedButton]);

        GUI.SetNextControlName(buttonsArray[0]);

        if (GUI.Button(new Rect(butL, butT + offset, butW, butH), buttonsArray[0], skin.GetStyle("Button")))
        {
            box.currentMessage = messages.choises[0][box.count2];
            Debug.Log("juu");
            showButtons = false;
        }

        GUI.SetNextControlName(buttonsArray[1]);
        offset += butH;

        if (GUI.Button(new Rect(butL, butT + offset, butW, butH), buttonsArray[1], skin.GetStyle("Button")))
        {
            box.currentMessage = messages.choises[1][box.count2 + 1];
            Debug.Log("ei");
            showButtons = false;
        }

        GUI.FocusControl(buttonsArray[selectedButton]);
    }

    // function that allows button control with keyboard
    private int  ButtonSelection(string[] buttonsArray, int selectedButton, string direction)
    {
        if(direction == "down")
        {
            if (selectedButton == buttonsArray.Length - 1)
                selectedButton = 0;
            else
                selectedButton += 1;
        }

        if(direction == "up")
        {
            if (selectedButton == 0)
                selectedButton = buttonsArray.Length - 1;
            else
                selectedButton -= 1;
        }

        return selectedButton;
    }
}