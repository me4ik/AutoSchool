using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailsForce : MonoBehaviour
{
       Terrain trn;
       public float Details = 1000f;


    // Start is called before the first frame update
    void Start()
    {
        trn = GetComponent<Terrain>();
    }

    // Update is called once per frame
    void Update()
    {
        trn.detailObjectDistance = Details;
    }
}
