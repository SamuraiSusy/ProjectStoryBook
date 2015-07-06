using UnityEngine;
using System.Collections;
// POISTETAAN
public class ChangeCamera : MonoBehaviour
{
    public Camera otherCamera; // moveable camera
    private Camera mcam; // main camera
    private PlayerControl player;
    private Vector3 playerPos; // position of player
    private Vector3 worldPos; // point where the camera changes when player reaches it
    public float worldPosX, worldPosY;
    private Vector3 otherCameraPos; // position of other camera
    public float newCamX, newCamY;
    private Vector3 dbpos, dbworld; // mouse and world position debugging
    private bool mainActive;
    private bool once, once2;
    public bool isLeft, isRight; // right or left side of the map
                                  // set in inspector!

	// Use this for initialization
	private void Start ()
    {
        mcam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        worldPos = new Vector3(worldPosX, worldPosY);
        otherCameraPos = new Vector3(newCamX, newCamY, -10);
        otherCamera.enabled = false;
        mainActive = true;
        once = false;
        once2 = false;
	}
	
	// Update is called once per frame
	private void Update ()
    {
        playerPos = player.transform.position;
        DebugWorldPosition();

        MoveCamera();
        ReturnCamera();
        Debug.Log(playerPos);
	}

    // enables other camera
    private void MoveCamera()
    {
        if (playerPos == worldPos && mainActive && !once)
        {
            Debug.Log(1);
            otherCamera.enabled = true;
            mainActive = false;
            once = true;
            Debug.Log("called once move camera");
        }
    }

    // disables other camera
    private void ReturnCamera()
    {
        if (isLeft)
        {
            if (playerPos.x > worldPosX && playerPos.y == worldPosY && !mainActive && once)
            {
                otherCamera.enabled = false;
                mainActive = true;
                once = false;
                Debug.Log("called return camera from left once");
            }
        }
        else if (isRight)
        {
            if(playerPos.x < worldPosX && playerPos.y == worldPosY && !mainActive && once)
            {
                otherCamera.enabled = false;
                mainActive = true;
                once = false;
                Debug.Log("called return camera from right once");
            }
        }
    }

    private void DebugWorldPosition()
    { // SCREEN to WORLD POINT
        dbpos = Input.mousePosition;
        dbworld = mcam.ScreenToWorldPoint(dbpos);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Debug.Log(dbworld + " world pos");
    }
}
// pelaaja tavoittaa pisteen, kamera vaihtuu
// ei törmäystä