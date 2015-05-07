using UnityEngine;
using System.Collections;

public class CalculateSpeed : MonoBehaviour
{
    public Vector3 currVel;
    private Vector3 prevPos;

    void Start()
    {
        StartCoroutine(CalcVelocity());
    }

    IEnumerator CalcVelocity()
    {
        while (Application.isPlaying)
        {
            // Position at frame start
            prevPos = transform.position;
            // Wait till it the end of the frame
            yield return new WaitForEndOfFrame();
            // Calculate velocity: Velocity = DeltaPosition / DeltaTime
            currVel = (prevPos - transform.position) / Time.deltaTime;
        }
    }
}
