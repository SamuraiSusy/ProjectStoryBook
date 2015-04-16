using UnityEngine;
using System.Collections;

public class StopCamera : MonoBehaviour
{
    private Camera kamera;
    private PlayerControl player;
    private Vector3 playerPos;

	// Use this for initialization
	void Start ()
    {
        kamera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerPos = player.transform.position;
        StopLvl1();
	}

    private void StopLvl1()
    {
        if(playerPos.y < kamera.WorldToViewportPoint(new Vector3(0, -1.4f)).y &&
            playerPos.y > kamera.WorldToViewportPoint(new Vector3(0, 4.5f)).y)
        {
            // left
            if(playerPos.x <= kamera.WorldToViewportPoint(new Vector3(-8.8f, 0)).x)
            {
                kamera.transform.position = new Vector3(-8.75f, -1.22f, -10f);
            }
            // right
            if (playerPos.x <= kamera.WorldToViewportPoint(new Vector3(-10.4f, 0)).x)
            {

            }
        }
    }
}
