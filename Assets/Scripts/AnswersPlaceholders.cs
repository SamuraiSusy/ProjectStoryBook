using UnityEngine;
using System.Collections;

public class AnswersPlaceholders : MonoBehaviour
{
    public string[][] answersArray;
    private string[] answersToDialogue2;

	// Use this for initialization
	private void Awake ()
    {
        SetUpAnswersToDialogue2();
        SetUpAnswersArray();
	}

    private void SetUpAnswersArray()
    {
        answersArray = new string[1][];

        answersArray[0] = answersToDialogue2;
    }

    private void SetUpAnswersToDialogue2()
    {
        answersToDialogue2 = new string[]
        {
            "kylla",
            "ei"
        };
    }
}
