using UnityEngine;
using System.Collections;

public class StopCamera : MonoBehaviour
{
    public Camera cameralvl1left, cameralvl1rigth;
    private Vector3 posLvl1Left, posLvl1Right;

	// Use this for initialization
	void Start ()
    {
        cameralvl1left.enabled = false;
        posLvl1Left = cameralvl1left.ScreenToViewportPoint(new Vector3(-20.83f, -0.08f, -10f));
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if(camera.enabled)
        //{
        //    camera.transform.position = posLvl1Left;
        //}
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log(col.gameObject.tag);
            //Camera.main.enabled = false;
            cameralvl1left.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            cameralvl1left.enabled = false;
            //Camera.main.enabled = true;
        }
    }
}
