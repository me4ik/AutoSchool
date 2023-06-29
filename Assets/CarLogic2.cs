using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLogic2 : MonoBehaviour
{
     private Rigidbody rb;
     public Transform[] points;  
     
     public static int CurPoint = 0;

    public float speed = 1500f;

    private float slowSpeed;
    private float standartSpeed;   //���������� ���������
    private float fastSpeed;
    private float veryslow;

    public bool Standart = true;
    public bool Speeding = false;  //���������� ���������� ��� ��������� ��������
    public bool Slowing = false;
    public bool VerySlow = false;
    public float timeScaleVelocity = 0f;

    public float ChangeTime = 0.1f; //�������� ��������� �������� ������ (��� ������ ��� �������)

    void Start()
    {
        slowSpeed = speed / 2f;
        fastSpeed = speed * 1.5f;  //����������� ���������, ������� � ����������� ���������
        standartSpeed = speed;
        veryslow = speed / 3;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSpeed();
        transform.position = Vector3.MoveTowards(transform.position, points[CurPoint].position, speed * Time.deltaTime);
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
            Standart = false;               // ��������� ���������� ���������� ��� ������ � ������ ��������
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
        speed = Mathf.SmoothDamp(speed, standartSpeed, ref timeScaleVelocity, ChangeTime);     //������ ��� �������� ��������� ���������
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
            FastSpeed();               // ��������� �������� � ����������� �� �������� ���������� ����������
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
}
