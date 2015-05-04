using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    public GameObject exclamationIcon;
    //todo animaatio
    public bool isStopped;
    public float walkingSpeed;
    public bool isMoving;
    public float speed;
    //private bool isAnimPlaying;

    // Use this for initialization
    private void Start()
    {
        isStopped = false;
        walkingSpeed = 5f;

        ShowExclamation(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isStopped)
            walkingSpeed = 5f;
        else if(isStopped)
            walkingSpeed = 0;

        if (Input.GetKeyUp(KeyCode.LeftArrow) && Input.GetKeyUp(KeyCode.RightArrow))
            isMoving = false;

        if (isMoving)
            speed = 1;
        else
            speed = 0;

        Debug.Log(exclamationIcon.activeSelf + " huutomerkki");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float walk = Input.GetAxis("Horizontal") * walkingSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //isAnimPlaying = true;
            isMoving = true;
            transform.Translate(walk, 0, 0);
            
            
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //isAnimPlaying = true;
            isMoving = true;
            transform.Translate(walk, 0, 0);
        }
    }

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