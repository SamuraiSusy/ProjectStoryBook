using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

	// Use this for initialization
	void Start ()
    {
        speed = 5f;
	}
	//22
	// Update is called once per frame
	void Update ()
    {
        if(transform.position.x > 32)
        {
            Application.LoadLevel(0);
        }
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

        float stopCamera = 22f;
        if (transform.position.x > stopCamera)
        {
            Camera.main.transform.position = new Vector3(26.5f, 0, -10);
        }
    }
}
