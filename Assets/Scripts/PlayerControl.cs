using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    public GameObject exclamationIcon;
    public bool isStopped;
    public float speed;
    public bool isMoving;
    private bool facingRight;
    private bool once, once2;
    //private Animator anim;
    private CalculateSpeed calculateSpeed;

    // Use this for initialization
    private void Start()
    {
        isStopped = false;
        speed = 5f;

        //anim = GetComponent<Animator>();
        calculateSpeed = GetComponent<CalculateSpeed>();

        ShowExclamation(false);
    }

    // Update is called once per frame
    private void Update()
    {
        //Debug.Log(Mathf.Abs(calculateSpeed.currVel.x) + " current speed");
        ///anim.SetFloat("speed", Mathf.Abs(calculateSpeed.currVel.x));

        if (!isStopped)
            speed = 5f;
        else if(isStopped)
            speed = 0;

        Debug.Log(isStopped + " isstopped");

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
        }

        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            isMoving = false;
        }

        // fliping the sprite of player
        if (Input.GetKeyDown(KeyCode.RightArrow) && !once)
        {
            Flip();
            once = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && once)
        {
            Flip();
            once = false;
        }


        //Debug.Log(exclamationIcon.activeSelf + " huutomerkki");
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
            isMoving = true;
            transform.Translate(walk, 0, 0);
            
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            isMoving = true;
            transform.Translate(walk, 0, 0);
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    //private void Move2()
    //{
    //    float h = Input.GetAxis("Horizontal");
    //    float walk = h * speed * Time.deltaTime;
    //    int moving
    //    anim.SetFloat("speed", walk);
    //    Debug.Log("walk " + walk);

    //    if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        transform.Translate(Vector3.right * walk);
    //    }
    //    else if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        transform.Translate(Vector3.right * walk);
    //    }
    //}

    //public bool ShowExclamationMark(bool show)
    //{
    //    return show;
    //}

    public void ShowExclamation(bool show)
    {
        exclamationIcon.SetActive(show);
    }

    private void OnCollisionStay2D(Collision2D col)
    {

    }

    private void OnCollisionExit2D(Collision2D col)
    {

    }
}