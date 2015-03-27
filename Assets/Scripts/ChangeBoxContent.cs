using UnityEngine;
using System.Collections;

public class ChangeBoxContent : MonoBehaviour
{
    private MessageBox ms;
    private MessagePlaceholders messages;
    public bool[] triggers;
    private string[] triggerNames;
    private bool collidedTrigger1, collidedTrigger2 = false;

	// Use this for initialization
	private void Start ()
    {
        ms = GameObject.FindGameObjectWithTag("MessageBox").GetComponent<MessageBox>();
        messages = GameObject.FindGameObjectWithTag("MessageBox").GetComponent<MessagePlaceholders>();

        SetUpTriggerNames();
        SetUpTriggersArray();
	}
	
	// Update is called once per frame
	private void Update ()
    {
	    for(int i = 0; i < triggers.Length; i++)
        {
            if(triggers[i])
            {
                ms.showBox1 = true;
                ms.showMessages = true;
                ms.curTextBoxContent = messages.dialogues[i];

                if (ms.count == messages.dialogues[i].Length - 1 && messages.dialogues[i][messages.dialogues[i].Length - 1] == "$")
                {
                    ms.showBox1 = false;
                    ms.showBox2 = true;
                    ms.curTextBoxContent = messages.choises[i];
                }
            }
        }
	}

    private void SetUpTriggerNames()
    {
        // the script may have to be reattached to go when
        // there is more trigger names
        triggerNames = new string[2];
        triggerNames[0] = "DiaTrig";
        triggerNames[1] = "DiaTrig2";
    }

    private void SetUpTriggersArray()
    {
        triggers = new bool[2];
        triggers[0] = collidedTrigger1;
        triggers[1] = collidedTrigger2;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        for(int i = 0; i < triggerNames.Length; i++)
        {
            if(col.gameObject.tag == triggerNames[i])
            {
                triggers[i] = true;
            }
        }
    }
}