using UnityEngine;
using System.Collections;

// avoid putting anything useless to ongui, it messes up stuff..
public class MessageBox : MonoBehaviour
{
    public GUISkin skin;
    public bool showBox;
    private MessagePlaceholders messages;
    private ChangeBoxContent changeContent;
    private ChoiseButtons answer;
    public bool showMessages;
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
        showMessages = false;
        currentMessage = "";
        count = 0;
    }

    int currentMessageID = 0;

    // Update is called once per frame
    void Update()
    {

        if (showBox && Input.GetButtonDown("Collect"))
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
        GUI.Box(mssbox, currentMessage, skin.GetStyle("Message"));
    }

    // draws the messages to the text box
    private void WriteMessages()
    {
        for (int i = 0; i < messages.dialogues.Length; i++)
        {
            if (curTextBoxContent == messages.dialogues[i])
            {
                if (count < messages.dialogues[i].Length)
                {
                    currentMessage = PrintMessages(messages.dialogues[i], count);
                    count++;
                    Debug.Log("-1");
                    if (count == messages.dialogues[i].Length - 1)
                    {
                        Debug.Log("0");
                        if (messages.dialogues[i][messages.dialogues[i].Length - 1] == "$")
                        {
                            Debug.Log("1");
                            count2 = 0;
                            answer.showButtons = true;
                            curTextBoxContent = messages.choises[i];
                        }
                    }

                    else if (curTextBoxContent == messages.dialogues[i] && count >= messages.dialogues[i].Length)
                    {
                        Debug.Log("2");
                        showBox = false;
                        showMessages = false;
                        changeContent.triggers[i] = false;
                        currentMessage = "";
                        count = 0;
                        // Debug.Log("täälkö?");
                        //    Debug.Log(count2);
                    }

                }
            }

            else if (curTextBoxContent == messages.choises[i])
            {
                Debug.Log("3");
                showBox = true;
                if (count2 < messages.choises[i].Length)
                {
                    Debug.Log("4");
                    if (Input.GetButtonUp("Collect"))
                    {
                        Debug.Log("5");
                        currentMessage = PrintMessages(messages.choises[i], count2);
                        count2++;
                    }

                    if (curTextBoxContent == messages.choises[i] && count2 >= messages.choises[i].Length)
                    {
                        Debug.Log("6");
                        showBox = false;
                        showMessages = false;
                        changeContent.triggers[i] = false;
                        currentMessage = "";
                        count = 0;
                        count2 = 0;
                    }
                }
            }
        }
    }

    private void UpdateMessage()
    {
        for (int i = 0; i < messages.dialogues.Length; i++)
        {
            bool t = false;
            if (curTextBoxContent == messages.dialogues[i])
            {
                if (count < messages.dialogues[i].Length)
                {
                    if (Input.GetButtonUp("Collect"))
                    {
                        currentMessage = PrintMessages(messages.dialogues[i], count);
                        count++;
                        Debug.Log("-1");
                        if (count == messages.dialogues[i].Length - 1)
                        {
                            Debug.Log("0");
                            if (messages.dialogues[i][messages.dialogues[i].Length - 1] == "$")
                            {
                                Debug.Log("1");
                                count2 = 0;
                                answer.showButtons = true;
                                curTextBoxContent = messages.choises[i];
                            }
                        }

                        else if (t == false && curTextBoxContent == messages.dialogues[i] && count >= messages.dialogues[i].Length)
                        {
                            Debug.Log("2");
                            showBox = false;
                            showMessages = false;
                            changeContent.triggers[i] = false;
                            currentMessage = "";
                            count = 0;
                            // Debug.Log("täälkö?");
                            //    Debug.Log(count2);
                        }
                    }
                }
            }

            else if (curTextBoxContent == messages.choises[i])
            {
                t = true;
                Debug.Log("3");
                showBox = true;
                if (count2 < messages.choises[i].Length)
                {
                    Debug.Log("4");
                    if (Input.GetButtonUp("Collect"))
                    {
                        Debug.Log("5");
                        currentMessage = PrintMessages(messages.choises[i], count2);
                        count2++;
                    }

                    if (curTextBoxContent == messages.choises[i] && count2 >= messages.choises[i].Length)
                    {
                        Debug.Log("6");
                        showBox = false;
                        showMessages = false;
                        changeContent.triggers[i] = false;
                        currentMessage = "";
                        count = 0;
                        count2 = 0;
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