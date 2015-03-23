using UnityEngine;
using System.Collections;

public class NextArea : MonoBehaviour
{
    private GameObject player;
    private PlayerMovement plMov;

    public float playerPosX, playerPosY;
    public float cameraX, cameraY;

    private void Start()
    {
        Debug.Log("mo");
        player = GameObject.FindGameObjectWithTag("Player");
        plMov = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        playerPosX = -5;
        playerPosY = -15;
        cameraX = 0;
        cameraY = -12.1f;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.transform.position = new Vector3(playerPosX, playerPosY);
            if(player.transform.position.y <= cameraY)
            {
                plMov.lvl1 = false;
                Camera.main.transform.position = new Vector3(cameraX, cameraY, -10);
                plMov.lvl2 = true;
            }
        }
    }
}