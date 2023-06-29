using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class CarLogic : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 1500f;

    private float slowSpeed;
    private float standartSpeed;   //переменные скоростей
    private float fastSpeed;
    private float veryslow;

    private bool Standart = true;
    private bool Speeding = false;  //логические переменные для изменения скорости
    private bool Slowing = false;
    private bool VerySlow = false;
    private float timeScaleVelocity = 0f;

    private float ChangeTime = 10f; //Скорость изменения скорости машины (чем больше тем быстрее)

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        slowSpeed = speed / 3f;
        fastSpeed = speed * 1.5f;  //определение медленной, быстрой и стандартных скоростей
        standartSpeed = speed;
        veryslow = speed / 3;
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = speed * Time.deltaTime * transform.forward;
        
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

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Slow"))
        {
            Slowing = true;
            Standart = false;
            Speeding = false;
        }

        if (other.CompareTag("Fast"))
        {
            Slowing = false;
            Standart = false;               // изменение логических переменных при заходе в разные триггеры
            Speeding = true;
        }

        if (other.CompareTag("Standart"))
        {
            Slowing = false;
            Standart = true;
            Speeding = false;
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
}
