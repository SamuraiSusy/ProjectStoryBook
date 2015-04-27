using UnityEngine;
using System.Collections;

public class Text : MonoBehaviour
{
    public GUISkin skin;
    // kiinnitä ykso jokaiseen objektiin!!!11!
    public string[] text; // jätä viimeinen kenttä(indeksi) tyhjäksi
    private bool show;
    private string current;
    private int count;

    private bool collided;

    private Examine examine;

	// Use this for initialization
	private void Start ()
    {
        show = false;
        current = text[0];
        count = 0;

        collided = false;

        examine = GameObject.FindGameObjectWithTag("Examine").GetComponent<Examine>();
	}
	
	// Update is called once per frame
	private void Update ()
    {
	    if(Input.GetKeyUp(KeyCode.Space) && show)
        {
            examine.showExaminedItem = true;
            current = text[count];
            count++;

            if(count == text.Length)
            {
                count = 0;
                current = text[0];
                show = false;
                examine.showExclamation = false;
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
        if (show)
            GUI.Box(boxRect, current, "box");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            collided = true;
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
        }
    }
}
