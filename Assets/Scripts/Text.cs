﻿using UnityEngine;
using System.Collections;
//POISTETAAN
public class Text : MonoBehaviour
{
    public GUISkin skin;
    // kiinnitä ykso jokaiseen objektiin!!!11!
    public string[] text; // jätä viimeinen kenttä(indeksi) tyhjäksi
    private bool show;
    private string current;
    private int count;

    private bool collided;

    private PlayerControl playerControl;
    private Examine examine;

	// Use this for initialization
	private void Start ()
    {
        show = false;
        current = "";
        count = 0;

        collided = false;

        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        examine = GetComponent<Examine>();

        examine.enabled = false;
	}
	
	// Update is called once per frame
	private void Update ()
    {
        if(show)
            playerControl.isStopped = true;

	    if(Input.GetKeyUp(KeyCode.Space) && show)
        {
            current = text[count];
            count++;

            if(count == text.Length)
            {
                count = 0;
                current = "";
                show = false;
                examine.showExclamation = false;
                playerControl.isStopped = false;
            }
        }

        if (!show)
        {
            examine.showExaminedItem = false;
        }
	}

    private void OnGUI()
    {
        GUI.skin = skin;
        Rect boxRect = new Rect(300, 300, 150, 100);
        if (show && examine.examinedItem != null)
        {
            GUI.Box(boxRect, current, "Wilhelm");
            examine.showExaminedItem = true;
        }
        else if (show && examine.examinedItem == null)
        {
            GUI.Box(boxRect, current, "Wilhelm");
            examine.showExaminedItem = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            collided = true;
            //examine.enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (collided && Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.Space))
        {
            show = true;
            collided = false;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            collided = false;
            //examine.enabled = false;
        }
    }
}
