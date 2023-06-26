using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour
{
    // ���� ������ ���� ����� ����� �������� �� �����, �� ��������� �������� ���������
    private TextMeshPro advText;

    private void Awake()
    {
        advText = GetComponent<TextMeshPro>();
        
    }

    void FixedUpdate()
    {
        advText.text = TextLogic.AdvText;
    }

    public void ClearText()
    {

    advText.text = "...";

    }

    public void SetText(string textS)
    {
        advText.text = textS;
    }
}
