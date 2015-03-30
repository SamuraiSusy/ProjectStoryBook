using UnityEngine;
using System.Collections;

public class ChangeBoxContent : MonoBehaviour
{
    private MessageBox ms;
    private MessagePlaceholders messages;
    private testaus testii;
    public bool[] triggers;
    private string[] triggerNames;
    private bool collidedTrigger1, collidedTrigger2 = false;
    private bool colTrig0, colTrig1, colTrig2, colTrig3;

	// Use this for initialization
	private void Start ()
    {
        ms = GameObject.FindGameObjectWithTag("MessageBox").GetComponent<MessageBox>();
        //messages = GameObject.FindGameObjectWithTag("MessageBox").GetComponent<MessagePlaceholders>();
        testii = GameObject.FindGameObjectWithTag("MessageBox").GetComponent<testaus>();

        SetUpTriggerNames();
        SetUpTriggersArray();
	}
	
	// Update is called once per frame
	private void Update ()
    {
	    for(int i = 0; i < triggers.Length; i++)
        {
            //if(triggers[i])
            //{
            //    ms.showBox1 = true;
            //    ms.showMessages = true;
            //    ms.curTextBoxContent = messages.dialogues[i];

            //    if (ms.count == messages.dialogues[i].Length - 1 && messages.dialogues[i][messages.dialogues[i].Length - 1] == "$")
            //    {
            //        ms.showBox1 = false;
            //        ms.showBox2 = true;
            //        ms.curTextBoxContent = messages.choises[i];
            //    }
            //}

            if(triggers[i])
            {
                testii.show = true;
                //testii.curTeksti = testii.strings[i];
            }
        }
	}

    private void SetUpTriggerNames()
    {
        // the script may have to be reattached to go when
        // there is more trigger names
        triggerNames = new string[4];
        //triggerNames[0] = "DiaTrig";
        //triggerNames[1] = "DiaTrig2";
        triggerNames[0] = "trig0";
        triggerNames[1] = "trig1";
        triggerNames[2] = "trig2";
        triggerNames[3] = "trig3";
    }

    private void SetUpTriggersArray()
    {
        triggers = new bool[4];
        //triggers[0] = collidedTrigger1;
        //triggers[1] = collidedTrigger2;
        triggers[0] = colTrig0;
        triggers[1] = colTrig1;
        triggers[2] = colTrig2;
        triggers[3] = colTrig3;
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