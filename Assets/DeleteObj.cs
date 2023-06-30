using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObj : MonoBehaviour
{

    public float Secs = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destr", Secs);
    }

    void Destr()
    {
        Destroy(gameObject);
    }
}
