using UnityEngine;
using System.Collections;

// ota käyttöön toinen kamera, kun seinä tulee vastaan
// collideri, joka triggeröi toisen kameran, bool on/off


public class MoveCameras : MonoBehaviour
{

    public Camera movingCamera;
    private Camera mainCam;
    private bool isItEnabled;
    private bool enabledOnce, twice;

    public float camX, camY;

	// Use this for initialization
	void Start ()
    {
        mainCam = Camera.main;
        isItEnabled = false;
        enabledOnce = false;
        twice = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
    //    if (isItEnabled)
    //        MoveOtherCamera();
	}

    private void MoveOtherCamera()
    {
        movingCamera.transform.position = new Vector3(camX, camY, -10);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            movingCamera.transform.position = new Vector3(camX, camY, -10);
            movingCamera.enabled = true;
            //mainCam.enabled = false;
        }
    }

    //private void OnTriggerStay2D(Collider2D col)
    //{
    //    if(col.gameObject.tag == "Player" && !isItEnabled && !enabledOnce)
    //    {
    //        // enabloi toinen kamera, kävelee seinää kohti
    //        movingCamera.enabled = true;
    //        mainCam.enabled = false;

    //        isItEnabled = true;
    //        enabledOnce = true;
    //    }

    //    if (col.gameObject.tag == "Player" && isItEnabled && !enabledOnce)
    //    {
    //        // disabloi toinen kamera, main käyttöön, kävelee pois seinältä
    //        mainCam.enabled = true;
    //        movingCamera.enabled = false;

    //        isItEnabled = false;
    //        enabledOnce = true;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D col)
    //{
    //    if (col.gameObject.tag == "Player" && isItEnabled)
    //    {
    //        enabledOnce = false;
    //    }
    //}
}
