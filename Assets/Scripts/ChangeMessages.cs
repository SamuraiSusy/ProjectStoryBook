using UnityEngine;
using System.Collections;

public class ChangeMessages : MonoBehaviour
{
    private MessageBox ms;
    private MessagePlaceholders messages;
    public bool[] triggers = new bool[3];
    public bool[] triggersA = new bool[3];
    public bool collidedDialogueTrigger;
    public bool collidedDialogue2Trigger;

	// Use this for initialization
	private void Start ()
    {
        ms = GameObject.FindGameObjectWithTag("MessageBox").GetComponent<MessageBox>();
        messages = GameObject.FindGameObjectWithTag("MessageBox").GetComponent<MessagePlaceholders>();
        triggers[0] = collidedDialogueTrigger;
        triggersA[0] = collidedDialogue2Trigger;

        collidedDialogueTrigger = false;
        collidedDialogue2Trigger = false;
	}
	
	// Update is called once per frame
	private void Update ()
    {
        // if player collides with right object text box starts to run
	    if(collidedDialogueTrigger)
        {
            ms.showBox = true;
            ms.showMessages = true;
            ms.curTextBoxContent = messages.dialogues[0];
        }
        if(collidedDialogue2Trigger)
        {
            ms.showBox = true;
            ms.showMessages = true;
            //ms.curTextBoxContent = messages.dialoguesWithAnswers[0];
        }
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.tag == "DiaTrig")
        {
            collidedDialogueTrigger = true;
        }
        if (col.gameObject.tag == "DiaTrig2")
        {
            collidedDialogue2Trigger = true;
        }
    }
}
