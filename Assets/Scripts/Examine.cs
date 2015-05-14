using UnityEngine;
using System.Collections;

public class Examine : MonoBehaviour
{
    public GUISkin skin;
    public Texture2D examinedItem;

    private PlayerControl playerControl;
    public bool showExaminedItem;
    public bool showExclamation;

    private bool onceTrue, onceFalse;

	// Use this for initialization
	private void Start ()
    {
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();

        onceTrue = false;
        onceFalse = false;
	}
	
	// Update is called once per frame
	private void Update ()
    {
        if (showExclamation)
        {
            playerControl.ShowExclamation(true);
        }
        if (!showExclamation)
        {
            playerControl.ShowExclamation(false);
        }

	}

    private void OnGUI()
    {
        GUI.skin = skin;

        if (showExaminedItem && examinedItem != null)
            DrawExaminedItem();
    }


    // myös vaihtoehto, jossa ei piirretä sitä
    // = pelkkä huutomerkki
    private void DrawExaminedItem()
    {
        Rect itemRect = new Rect(100, 200, 150, 150);
        GUI.Box(itemRect, examinedItem, "Wilhelm");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            showExclamation = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            showExclamation = false;
        }
    }
}
