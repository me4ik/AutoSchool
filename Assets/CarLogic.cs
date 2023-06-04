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

    private float ChangeRate = 2f; //�������� ��������� �������� ������ (��� ������ ��� �������)

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
        //TimeStop.isPaused = true;

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
        speed = Mathf.Lerp(speed, slowSpeed, ChangeRate * Time.deltaTime);
    }

    public void StandartSpeed()
    {
        speed = Mathf.Lerp(speed, standartSpeed, ChangeRate * Time.deltaTime);      //������ ��� �������� ��������� ���������
    }

    public void FastSpeed()
    {
        speed = Mathf.Lerp(speed, fastSpeed, ChangeRate * Time.deltaTime);
    }

}
