using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLogic : MonoBehaviour
{
    static public string AdvText; // статическая переменная текста подсказки
    public string SetText; //Текст на который будет меняться AdvText после пересечения триггера
    private AudioSource speech;
    public float ContinueDelay = 3f;

    public bool NeedStop = false;

    void Awake()
    {
        AdvText = "Здравстуйте, вы находитесь в виртуальной модели опасной ситуации на дороге. \n (Для продолжения нажмите на курок)";
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
            Debug.Log("Пауза");
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
