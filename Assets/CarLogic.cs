using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class CarLogic : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 1500f;
    private float slowSpeed;
    private float standartSpeed;   //���������� ���������
    private float fastSpeed;

    private bool Standart = true;
    private bool Speeding = false;  //���������� ���������� ��� ��������� ��������
    private bool Slowing = false;
    private float timeScaleVelocity = 0f;

    private float ChangeTime = 2f; //�������� ��������� �������� ������ (��� ������ ��� �������)

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        slowSpeed = speed / 1.3f;
        fastSpeed = speed * 1.3f;  //����������� ���������, ������� � ����������� ���������
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
            FastSpeed();               // ��������� �������� � ����������� �� �������� ���������� ����������
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
            Standart = false;               // ��������� ���������� ���������� ��� ������ � ������ ��������
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
        speed = Mathf.SmoothDamp(speed, standartSpeed, ref timeScaleVelocity, ChangeTime);     //������ ��� �������� ��������� ���������
    }

    public void FastSpeed()
    {
        speed = Mathf.SmoothDamp(speed, fastSpeed, ref timeScaleVelocity, ChangeTime);
    }
}
