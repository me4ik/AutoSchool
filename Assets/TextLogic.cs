using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLogic : MonoBehaviour
{
    static public string AdvText; // статическая переменная текста подсказки
    public string SetText; //Текст на который будет меняться AdvText после пересечения триггера

    public bool NeedStop = false;

    private void OnTriggerEnter(Collider other)
    {
        AdvText = SetText;
        Debug.Log(AdvText);                          //Этот скрипт нужно кидать на триггеры скорости, или на любой другой триггер,
                                                     //чтобы изменить текст подсказки
         if (NeedStop)
        {
            TimeStop.isPaused = true;        //в инспекторе можно включить флажок, чтобы при пересечении этого триггера время стопалось
        }
    }
}
