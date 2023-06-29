using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLogic : MonoBehaviour
{
    static public string AdvText; // ����������� ���������� ������ ���������
    public string SetText; //����� �� ������� ����� �������� AdvText ����� ����������� ��������
    private AudioSource speech;

    public bool NeedStop = false;

    void Awake()
    {
        AdvText = "�����������, �� ���������� � ����������� ������ ������� �������� �� ������. \n (��� ����������� ������� �� �����)";
    }

    void Start()
    {
        speech = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        AdvText = SetText;
        speech.Play();
                              
         if (NeedStop /*&& other.CompareTag("Car")*/)
        {
            TimeStop.isPaused = true;        //� ���������� ����� �������� ������, ����� ��� ����������� ����� �������� ����� ���������
            Debug.Log("�����");
        }
    }
}
