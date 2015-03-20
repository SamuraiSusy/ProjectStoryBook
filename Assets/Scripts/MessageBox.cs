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
    public int count;
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
	
	// Update is called once per frame
	void Update ()
    {
        if(showMessages)
        {
            WriteMessages();
        }
	}

    private void OnGUI()
    {
        if(showBox)
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
        for(int i = 0; i < messages.dialogues.Length; i++)
        {
            if(curTextBoxContent == messages.dialogues[i])
            {
                if(count < messages.dialogues[i].Length)
                {
                    if(Input.GetButtonUp("Collect"))
                    {
                        currentMessage = PrintMessages(messages.dialogues[i], count);
                        count++;


                    }

                    // the new thing, does not quite work
                    if (count == messages.dialogues[i].Length - 1)
                    {
                        if (messages.dialogues[i][messages.dialogues[i].Length - 1] == "$")
                        {
                            //int count2 = 0;
                            answer.showButtons = true;
                            Debug.Log("here i am");
                            //if(count2 < messages.choises[i].Length)
                            //{
                            //    if (Input.GetButtonUp("Collect"))
                            //    {
                            //        currentMessage = PrintMessages(messages.choises[i], count2);
                            //        count2++;
                            //    }
                            //    else
                            //        count2 = 0;
                            //}
                            curTextBoxContent = messages.choises[i];
                        }
                        else
                        {
                            if (count >= messages.dialogues[i].Length)
                            {
                                showBox = false;
                                showMessages = false;
                                changeContent.triggers[i] = false;
                                currentMessage = "";
                                count = 0;
                            }
                        }
                    }
                }

            }
            else if(curTextBoxContent == messages.choises[i])
            {
                answer.ChangeChoiseMessages();
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