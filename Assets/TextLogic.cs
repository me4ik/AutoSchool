using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLogic : MonoBehaviour
{
    static public string AdvText; // статическая переменная текста подсказки
    public string SetText; //Текст на который будет меняться AdvText после пересечения триггера

    public bool NeedStop = false;

    void Awake()
    {
        AdvText = "Здравстуйте, вы находитесь в виртуальной модели опасной ситуации на дороге. \n (Для продолжения дотроньтесь до текста)";
    }

    private void OnTriggerEnter(Collider other)
    {

        AdvText = SetText;
                              
         if (NeedStop && other.CompareTag("Car"))
        {
            TimeStop.isPaused = true;        //в инспекторе можно включить флажок, чтобы при пересечении этого триггера время стопалось
            Debug.Log("Пауза");
        }
    }
}
