using System.Collections;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    public static bool isPaused = false;
    private float timeScaleTarget = 0f;
    private float timeScaleVelocity = 0f;
    public float smoothTime = 0.2f;

    void Update()
    {

        timeScaleTarget = isPaused ? 0f : 1f;
       
        Time.timeScale = Mathf.SmoothDamp(Time.timeScale, timeScaleTarget, ref timeScaleVelocity, smoothTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPaused = false;
        } 
              
    }
}
