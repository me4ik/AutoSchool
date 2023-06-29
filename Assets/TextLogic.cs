using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLogic : MonoBehaviour
{
    static public string AdvText; // ����������� ���������� ������ ���������
    public string SetText; //����� �� ������� ����� �������� AdvText ����� ����������� ��������
    private AudioSource speech;
    public float ContinueDelay = 3f;

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
                              
         if (NeedStop && other.CompareTag("Car"))
        {
            speech.Play();
            CarLogic3.Stop = true;
            Invoke("NonStop",ContinueDelay);
            Debug.Log("�����");
        }
        else if (other.CompareTag("Car"))
        {
          speech.Play();
        }

    }

    private void NonStop()
    {
        CarLogic3.Stop = false;
    }
}
