using UnityEngine;
using System.Collections;
// tee sa,a scripti oikealle reunalle
public class StopCameraLeft : MonoBehaviour
{
    public Camera otherCamera;
    private Camera kamera;
    private PlayerControl player;
    private Vector3 playerPos;

    private Vector3 worldPos;
    public float worldX, worldY, worldY2; // 2 max
    public float newCameraX, newCameraY;

    private bool didCollide, cameraReturned;
    private bool callOnce, callOnce2;

    private Vector3 posi, worldpos; // for debugging

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
        if(worldY < playerPos.y &&
            playerPos.y < worldY2)
        {
            if (playerPos.x <= worldX)
            {
                otherCamera.transform.position = new Vector3(newCameraX, newCameraY, -10f);
                otherCamera.enabled = true;
            }
        }
    }

    private void ReturnCameraPos()
    {
        otherCamera.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            didCollide = true;

            if (didCollide && cameraReturned)
            {
                cameraReturned = false;
                callOnce2 = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (didCollide)
                cameraReturned = false;

            if(didCollide && !cameraReturned)
            {
                didCollide = false;
                cameraReturned = true;
                callOnce = false;
            }
        }
    }
}