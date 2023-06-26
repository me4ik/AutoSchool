using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLogic : MonoBehaviour
{
    static public string AdvText; // ����������� ���������� ������ ���������
    public string SetText; //����� �� ������� ����� �������� AdvText ����� ����������� ��������

    public bool NeedStop = false;

    void Awake()
    {
        AdvText = "�����������, �� ���������� � ����������� ������ ������� �������� �� ������. \n (��� ����������� ����������� �� ������)";
    }

    private void OnTriggerEnter(Collider other)
    {

        AdvText = SetText;
                              
         if (NeedStop && other.CompareTag("Car"))
        {
            TimeStop.isPaused = true;        //� ���������� ����� �������� ������, ����� ��� ����������� ����� �������� ����� ���������
            Debug.Log("�����");
        }
    }
}
