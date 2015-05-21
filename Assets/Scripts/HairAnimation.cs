using UnityEngine;
using System.Collections;

public class HairAnimation : MonoBehaviour
{
    private Animator anim;
    private Animation animation1;

    private void Start()
    {
        anim = GetComponent<Animator>();
        animation1 = GetComponent<Animation>();
    }

    private void Update()
    {
        Debug.Log(animation1.IsPlaying("Hair"));
        if (Input.GetKeyUp(KeyCode.Q))
        {
            animation1.Play();
        }
    }
}
