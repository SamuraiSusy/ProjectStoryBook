using UnityEngine;
using System.Collections;

public class TextBoxFirstLine : MonoBehaviour
{
    private MessageBox box;
    public string firstLine;

	// Use this for initialization
	private void Start ()
    {
        box = GameObject.FindGameObjectWithTag("MessageBox").GetComponent<MessageBox>();
        box.currentMessage = firstLine;
	}
}