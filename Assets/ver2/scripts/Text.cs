using UnityEngine;
using System.Collections;

public class Text : MonoBehaviour
{
    // kiinnitä ykso jokaiseen objektiin!!!11!
    public string first;
    public string[] text;
    private bool show;
    private string temp;
    private int count;

	// Use this for initialization
	void Start ()
    {
        show = false;
        temp = first;
        count = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyUp(KeyCode.Space) && show)
        {
            temp = text[count];
            count++;

            if(count == text.Length)
            {
                count = 0;
                temp = first;
                show = false;
            }
        }
	}

    private void OnGUI()
    {
        Rect boxRect = new Rect(300, 300, 150, 100);
        if (show)
            GUI.Box(boxRect, temp);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
        {
            show = true;
        }
    }
}
