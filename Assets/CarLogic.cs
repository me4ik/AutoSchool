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

    private bool Standart = true;
    private bool Speeding = false;  //логические переменные для изменения скорости
    private bool Slowing = false;
    private float timeScaleVelocity = 0f;

    private float ChangeTime = 2f; //Скорость изменения скорости машины (чем больше тем быстрее)

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        slowSpeed = speed / 1.3f;
        fastSpeed = speed * 1.3f;  //определение медленной, быстрой и стандартных скоростей
        standartSpeed = speed;
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
}
