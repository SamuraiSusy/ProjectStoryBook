using UnityEngine;
using System.Collections;

public class ReturnCameras : MonoBehaviour
{

    public Camera movingCam;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            //Camera.main.enabled = true;
            movingCam.enabled = false;
        }
    }
}
