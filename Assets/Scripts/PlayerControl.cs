using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    public GameObject exclamationIcon;
    public bool isStopped;
    private Vector3 lastPos;
    public float speed;
    private bool facingRight;
    private bool once, once2, once3;
    private Animator anim;
    private CalculateSpeed calculateSpeed;
    private FadeOut fadeOut;

    // Use this for initialization
    private void Start()
    {
        isStopped = false;
        lastPos = gameObject.transform.position;

        anim = GetComponent<Animator>();
        calculateSpeed = GetComponent<CalculateSpeed>();
        fadeOut = GameObject.FindGameObjectWithTag("Holder").GetComponent<FadeOut>();

        ShowExclamation(false);
    }

    // Update is called once per frame
    private void Update()
    {
    //    Debug.Log(isStopped + " isstopped");

    //    if (gameObject.transform.position != lastPos)
    //       isStopped = false;
    //    else
    //        isStopped = true;

		
		lastPos = gameObject.transform.position;

        //if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) && isStopped && !once2)
        //{
        //    isStopped = false;
        //    once2 = true;
        //}
        //if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) && !isStopped && once2)
        //{
        //    isStopped = true;
        //    once2 = false;
        //}

        if (isStopped)
            speed = 0;
        else
            speed = 5; // keksi keino, jolla voi asettaa sen unityn arvoon :oo

        // fliping the sprite of player
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isStopped && !once)
        {
            Flip();
            once = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isStopped && once)
        {
            Flip();
            once = false;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float walk = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        anim.SetFloat("speed", Mathf.Abs(walk));

        transform.Translate(new Vector3(walk, 0));
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

    public void ShowExclamation(bool show)
    {
        exclamationIcon.SetActive(show);
    }
}