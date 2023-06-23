using System.Collections;
using UnityEngine;
using Valve.VR;

public class TimeStop : MonoBehaviour
{
    public static bool isPaused = false;
    public SteamVR_Input_Sources hand;

    private float timeScaleTarget = 0f;
    private float timeScaleVelocity = 0f;
    public float smoothTime = 0.2f;

    void Update()
    {

        timeScaleTarget = isPaused ? 0f : 1f;
        Debug.Log(Time.timeScale);

        Time.timeScale = Mathf.SmoothDamp(Time.timeScale, timeScaleTarget, ref timeScaleVelocity, smoothTime);

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
}
