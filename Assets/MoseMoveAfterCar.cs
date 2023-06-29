using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoseMoveAfterCar : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        CarLogic2.CurPoint = 1;
    }
}
