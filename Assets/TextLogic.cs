using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLogic : MonoBehaviour
{
    static public string AdvText; // ����������� ���������� ������ ���������
    public string SetText; //����� �� ������� ����� �������� AdvText ����� ����������� ��������

    private void OnTriggerEnter(Collider other)
    {
        AdvText = SetText;
        Debug.Log(AdvText);                          //���� ������ ����� ������ �� �������� ��������, ��� �� ����� ������ �������,
                                                     //����� �������� ����� ���������
    }
}
