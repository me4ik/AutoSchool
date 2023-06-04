using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour
{
    private Text advText;  // Этот скрипт тебе нужно будет закинуть на текст, он обновляет значение постоянно

    private void Awake()
    {
        advText = GetComponent<Text>();
    }

    void FixedUpdate()
    {
        advText.text = TextLogic.AdvText;
    }
}
