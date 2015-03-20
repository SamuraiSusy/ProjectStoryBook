using UnityEngine;
using System.Collections;

public class TextBoxFirstLine : MonoBehaviour
{
    private MessageBox box;

	// Use this for initialization
	void Start ()
    {
        box = GameObject.FindGameObjectWithTag("MessageBox").GetComponent<MessageBox>();

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}