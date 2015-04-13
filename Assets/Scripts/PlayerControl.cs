using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    private bool hitStart;

    public bool[] isOnLevel;

    // Use this for initialization
    private void Start()
    {
        speed = 5f;

        isOnLevel = new bool[11];
        IsOnLevelTriggers();
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
            transform.Translate(walk, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(walk, 0, 0);
        }
    }

    private void IsOnLevelTriggers()
    {
        bool lvl1 = false;
        bool lvl2 = false;
        bool lvl3 = false;
        bool lvl4 = false;
        bool lvl5 = false;
        bool lvl6 = false;
        bool lvl7 = false;
        bool lvl8 = false;
        bool lvl9 = false;
        bool lvl10 = false;
        bool lvl11 = false;

        isOnLevel[0] = lvl1;
        isOnLevel[1] = lvl2;
        isOnLevel[2] = lvl3;
        isOnLevel[3] = lvl4;
        isOnLevel[4] = lvl5;
        isOnLevel[5] = lvl6;
        isOnLevel[6] = lvl7;
        isOnLevel[7] = lvl8;
        isOnLevel[8] = lvl9;
        isOnLevel[9] = lvl10;
        isOnLevel[0] = lvl11;
    }

    private void OnCollisionStay2D(Collision2D col)
    {

    }

    private void OnCollisionExit2D(Collision2D col)
    {

    }
}