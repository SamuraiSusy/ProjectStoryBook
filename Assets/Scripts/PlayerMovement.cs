using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public GameObject InvGO;
    Inventory inv;
	// Use this for initialization
	void Start ()
    {
        speed = 5f;
        inv = InvGO.GetComponent<Inventory>();
	}
	//22
	// Update is called once per frame
	void Update ()
    {
        if(transform.position.x > 32)
        {
            Application.LoadLevel(0);
        }
        if (inv.showInventory)
        {
            speed = 0;
        }
        else
            speed = 5;
	}

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float walk = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(walk, 0, 0);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(walk, 0, 0);
        }

        float stopCameraStart = -4.4f;
        float stopCameraEnd = 22f;
        if(transform.position.x < stopCameraStart)
        {
            Camera.main.transform.position = new Vector3(0f, 0, -10);
        }
        if (transform.position.x > stopCameraEnd)
        {
            Camera.main.transform.position = new Vector3(26.5f, 0, -10);
        }
    }
}