using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    public GameObject exclamationIcon;
    public bool isStopped;
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

        anim = GetComponent<Animator>();
        calculateSpeed = GetComponent<CalculateSpeed>();
        fadeOut = GameObject.FindGameObjectWithTag("Holder").GetComponent<FadeOut>();

        ShowExclamation(false);
    }

    // Update is called once per frame
    private void Update()
    {
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

        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || !fadeOut.texture.enabled)
        {
            isStopped = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || fadeOut.texture.enabled)
        {
            isStopped = true;
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

    public bool ShowExclamationMark(bool show)
    {
        return show;
    }

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