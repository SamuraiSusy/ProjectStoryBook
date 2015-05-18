using UnityEngine;
using System.Collections;

public class HairAnimation : MonoBehaviour
{
    private Animator anim;
    private Animation animation1;
    private bool playOnce;

	// Use this for initialization
	private void Start ()
    {
        anim = GetComponent<Animator>();
        animation1 = GetComponent<Animation>();

        playOnce = false;
        anim.SetBool("played", playOnce);
	}
	
	// Update is called once per frame
	private void Update ()
    {
        if (playOnce)
            animation1.Play("Hair");
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            playOnce = true;
        }
    }
}
