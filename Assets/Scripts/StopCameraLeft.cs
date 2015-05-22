using UnityEngine;
using System.Collections;

public class StopCameraLeft : MonoBehaviour
{
    public Camera otherCamera; // still camera
    private Camera kamera;  // main camera
    private PlayerControl player;
    private Vector3 playerPos;

    private Vector3 worldPos; // vector that defines player's position when colliding happens
    public float worldX, worldY; // where player should collide the collider
    public float newCameraX, newCameraY; // still camera position

    private bool didCollide, cameraReturned;
    private bool callOnce, callOnce2;

    private Vector3 worldpos, posi; // for debugging

	// Use this for initialization
	void Start ()
    {
        otherCamera.enabled = false;
        kamera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();

        worldPos = new Vector3(worldX, worldY, -10);

        didCollide = false;
        cameraReturned = true;
        callOnce = false;
        callOnce2 = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        DebugWorldPosition();

        playerPos = player.transform.position;

        if(didCollide && !callOnce)
        {
            MoveCameraToLeft();
            callOnce = true;
        }

        if(!didCollide && cameraReturned && !callOnce2)
        {
            ReturnCameraPos();
            cameraReturned = false;
            callOnce2 = true;
        }
	}

    private void DebugWorldPosition()
    { // SCREEN to WORLD POINT
        posi = Input.mousePosition;
        worldpos = kamera.ScreenToWorldPoint(posi);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Debug.Log(worldpos + " world pos");
    }

    private void MoveCameraToLeft()
    {
            //Debug.Log(playerPos.x);
            if (playerPos.x <= worldX)
            {
                //Debug.Log(1);
                otherCamera.transform.position = new Vector3(newCameraX, newCameraY, -10f);
                otherCamera.enabled = true;
            }
    }

    private void ReturnCameraPos()
    {
        otherCamera.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            didCollide = true;
        }
    }

    //private void OnTriggerStay2D(Collider2D col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        if (didCollide)
    //            cameraReturned = false;
    //    }
    //}

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (didCollide)
            {
                cameraReturned = false;
            }
            if (didCollide && !cameraReturned)
            {
                cameraReturned = true;
                didCollide = false;
                callOnce = false;
                callOnce2 = false;
            }
        }
    }
}