using System.Collections;
using UnityEngine;
using Valve.VR;

public class TimeStop : MonoBehaviour
{
    public static bool isPaused = true;
    public SteamVR_Input_Sources hand;

    private float timeScaleTarget = 0f;
    private float timeScaleVelocity = 0f;
    public float smoothTime = 0.2f;

    void Update()
    {

        timeScaleTarget = isPaused ? 0f : 1f;
        Debug.Log(isPaused);

        //Time.timeScale = Mathf.SmoothDamp(Time.timeScale, timeScaleTarget, ref timeScaleVelocity, smoothTime);
        //Time.timeScale = Mathf.SmoothStep(Time.timeScale, timeScaleTarget, smoothTime);

        if (isPaused) TimeStopp();
        else NoTimeStopp();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPaused = false;
            Debug.Log("Больше не пауза");
        }

        if (SteamVR_Actions._default.GrabPinch.GetStateDown(hand))
        {
            isPaused = false;
            Debug.Log("Больше не пауза");
        }

    }

    public void EndTimeStop()
    {
        isPaused = false;
    }

    void TimeStopp()
    {
    Time.timeScale = Mathf.SmoothStep(Time.timeScale, 0, smoothTime);
    }

    void NoTimeStopp()
    {
    Time.timeScale = Mathf.SmoothStep(Time.timeScale, 1, smoothTime);
    }
}
