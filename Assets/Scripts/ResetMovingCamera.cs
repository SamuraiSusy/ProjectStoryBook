using UnityEngine;
using System.Collections;

public class ResetMovingCamera : MonoBehaviour
{
    public Camera movingCam;

	// Use this for initialization
	void Start ()
    {
        movingCam.transform.position = Camera.main.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
