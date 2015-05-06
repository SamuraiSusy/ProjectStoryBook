using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    public GameObject exclamationIcon;
    //todo animaatio
    public bool isStopped;
    public float speed;
    public bool isMoving;

    private Animator anim;

    // Use this for initialization
    private void Start()
    {
        isStopped = false;
        speed = 5f;

        anim = GetComponent<Animator>();

        ShowExclamation(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isStopped)
            speed = 5f;
        else if(isStopped)
            speed = 0;

        if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("moving", isMoving);
        }

        else if (Input.GetKeyUp(KeyCode.LeftArrow) && Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("moving", isMoving);
            isMoving = false;
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
        //exclamationIcon.SetActive(show);
    }

    private void OnCollisionStay2D(Collision2D col)
    {

    }

    private void OnCollisionExit2D(Collision2D col)
    {

    }
}