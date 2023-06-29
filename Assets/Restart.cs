using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
private GameObject Car;
    void Start(){
        Car = GameObject.FindWithTag("Car");
    }

    void OnTriggerEnter(Collider other)
    {
        Invoke("Restartt", 4f);
    }

    void Restartt()
    {
         GameObject.Destroy(Car);
        SceneManager.LoadScene(0);
    }
}
