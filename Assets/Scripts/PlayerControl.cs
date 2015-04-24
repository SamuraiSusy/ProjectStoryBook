using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    //todo animaatio
    public float speed;
    private bool isAnimPlaying;

    // Use this for initialization
    private void Start()
    {
        speed = 5f;

    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float walk = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isAnimPlaying = true;
            transform.Translate(walk, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            isAnimPlaying = true;
            transform.Translate(walk, 0, 0);
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {

    }

    private void OnCollisionExit2D(Collision2D col)
    {

    }
}