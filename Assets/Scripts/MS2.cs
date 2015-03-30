using UnityEngine;
using System.Collections;

// avoid putting anything useless to ongui, it messes up stuff..
public class MS2 : MonoBehaviour
{
    public GUISkin skin;
    public bool showBox;
    private MessagePlaceholders messages;
    private ChangeBoxContent changeContent;
    private ChoiseButtons answer;
    public string currentMessage;
    public int count, count2;
    public string[] curTextBoxContent;

    // Use this for initialization
    private void Start()
    {
        showBox = false;
        messages = GetComponent<MessagePlaceholders>();
        changeContent = GameObject.FindGameObjectWithTag("Player").GetComponent<ChangeBoxContent>();
        answer = GetComponent<ChoiseButtons>();
        currentMessage = "";
        count = 0;
        count2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (showBox && Input.GetButtonUp("Collect"))
        {
            WriteMessages();
        }
    }

    private void OnGUI()
    {
        if (showBox)
        {
            DrawBox();
        }
    }

    private void DrawBox()
    {
        GUI.skin = skin;
        Rect mssbox = new Rect((Screen.width / 2) - (Screen.width / 2.9f), Screen.height / 1.4f, Screen.width / 1.4f, Screen.height / 3.7f);
        GUI.TextField(mssbox, currentMessage, skin.GetStyle("Message"));
    }

    // draws the messages to the text box
    private void WriteMessages()
    {

        for (int i = 0; i < messages.dialogues.Length; i++)
        {
            if (curTextBoxContent.GetHashCode() == messages.dialogues[i].GetHashCode())
            {
                if (count < messages.dialogues[i].Length)
                {
                    currentMessage = PrintMessages(messages.dialogues[i], count);
                    count++;
                    if (count == messages.dialogues[i].Length - 1)
                    {
                        if (messages.dialogues[i][messages.dialogues[i].Length - 1] == "$")
                        {
                            showBox = false;
                            curTextBoxContent = messages.choises[i];
                            answer.showButtons = true;
                        }
                    }

                    else if (curTextBoxContent.GetHashCode() == messages.dialogues[i].GetHashCode() && count >= messages.dialogues[i].Length)
                    {
                        showBox = false;
                        //showMessages = false;
                        changeContent.triggers[i] = false;
                        currentMessage = "";
                        count = 0;
                    }
                }
            }
        }
    }

    // generates the message shown in the message box
    private string PrintMessages(string[] messageArray, int messageID)
    {
        currentMessage = "";
        currentMessage += messageArray[messageID];

        return currentMessage;
    }
}