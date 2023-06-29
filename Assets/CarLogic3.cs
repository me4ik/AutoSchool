using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CarLogic3 : MonoBehaviour
{
     private Rigidbody rb;
     public Transform[] points;  
     
     public static int CurPoint = 0;

    public float speed = 1500f;

    private float slowSpeed;
    private float standartSpeed;   //переменные скоростей
    private float fastSpeed;
    private float veryslow;

    bool IsPinch = false;
    static public bool Stop = false;

    public bool Standart = true;
    public bool Speeding = false;  //логические переменные для изменения скорости
    public bool Slowing = false;
    public bool VerySlow = false;
    public float timeScaleVelocity = 0f;

    public float ChangeTime = 0.1f; //Скорость изменения скорости машины (чем больше тем быстрее)

    public SteamVR_Input_Sources hand;

    void Start()
    {
        slowSpeed = speed / 2f;
        fastSpeed = speed * 1.5f;  //определение медленной, быстрой и стандартных скоростей
        standartSpeed = speed;
        veryslow = speed / 1.5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SteamVR_Actions._default.GrabPinch.GetStateDown(hand))
        {
            IsPinch = true;
        }

        if (SteamVR_Actions._default.GrabPinch.GetStateUp(hand))
        {
            IsPinch = false;
        }

        if (IsPinch && !Stop)
        {
            ChangeSpeed();
            transform.position = Vector3.MoveTowards(transform.position, points[CurPoint].position, speed * Time.deltaTime);
        }
        else if (!Stop)
        {
            speed = Mathf.SmoothDamp(speed, 5f, ref timeScaleVelocity, 2f);
            transform.position = Vector3.MoveTowards(transform.position, points[CurPoint].position, speed * Time.deltaTime);
        }
        else if (Stop)
        {
            speed = Mathf.SmoothDamp(speed, 0f, ref timeScaleVelocity, 1f);
            transform.position = Vector3.MoveTowards(transform.position, points[CurPoint].position, speed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Slow"))
        {
            Slowing = true;
            Standart = false;
            Speeding = false;
             VerySlow = false;
        }

        if (other.CompareTag("Fast"))
        {
            Slowing = false;
            Standart = false;               // изменение логических переменных при заходе в разные триггеры
            Speeding = true;
             VerySlow = false;
        }

        if (other.CompareTag("Standart"))
        {
            Slowing = false;
            Standart = true;
            Speeding = false;
             VerySlow = false;
        }

        if (other.CompareTag("Vslow"))
        {
            Slowing = false;
            Standart = false;
            Speeding = false;
            VerySlow = true;
        }
    }


    public void SlowSpeed()
    {
        speed = Mathf.SmoothDamp(speed, slowSpeed, ref timeScaleVelocity, ChangeTime);
    }

    public void StandartSpeed()
    {
        speed = Mathf.SmoothDamp(speed, standartSpeed, ref timeScaleVelocity, ChangeTime);     //методы для плавного изменения скоростей
    }

    public void FastSpeed()
    {
        speed = Mathf.SmoothDamp(speed, fastSpeed, ref timeScaleVelocity, ChangeTime);
    }

    public void vSlowSpeed()
    {
        speed = Mathf.SmoothDamp(speed, veryslow, ref timeScaleVelocity, ChangeTime);
    }

    void ChangeSpeed()
    {
        if (Standart)
        {
            StandartSpeed();
        }

        if (Speeding)
        {
            FastSpeed();               // изменение скорости в зависимости от значений логических переменных
        }

        if (Slowing)
        {
            SlowSpeed();
        }

        if (VerySlow)
        {
          vSlowSpeed();
        }
    }

    static public void SetStop()
    {
        Stop = true;
    }

    static public void NoStop()
    {
        Stop = false;
    }
}
