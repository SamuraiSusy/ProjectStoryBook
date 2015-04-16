using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour
{
    public GUITexture texture;

    public float fadeSpeed = 1.5f; // change to private when the speed has been chosen
    private bool fadeOut, fadedOut;

    private void Awake()
    {
        texture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
    }

    private void Start()
    {
        texture.color = Color.clear;
        texture.enabled = false;
        fadeOut = false;
        fadedOut = false;
    }
	
	// Update is called once per frame
	private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            fadeOut = true;
            texture.enabled = true;
        }

        if(fadeOut)
            FadeToBlack();

        if (texture.color.a >= 0.95f)
        {
            fadeOut = false;
            fadedOut = true;
        }

        if(fadedOut)
        {
            FadeToClear();
            if(texture.color.a <= 0.05f)
            {
                texture.color = Color.clear;
                texture.enabled = false;
                fadedOut = false;
            }
        }
	}

    private void FadeToClear()
    {
        texture.color = Color.Lerp(texture.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    private void FadeToBlack()
    {
        texture.color = Color.Lerp(texture.color, Color.black, fadeSpeed * Time.deltaTime);
    }
}
