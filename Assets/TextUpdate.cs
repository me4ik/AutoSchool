using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour
{
    // Этот скрипт тебе нужно будет закинуть на текст, он обновляет значение постоянно
    private TextMeshPro advText;

    private void Awake()
    {
        advText = GetComponent<TextMeshPro>();
    }

    void FixedUpdate()
    {
        advText.text = TextLogic.AdvText;
    }
}
