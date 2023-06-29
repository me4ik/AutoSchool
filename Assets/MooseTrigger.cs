using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooseTrigger : MonoBehaviour
{
    public GameObject Moose;
    private Rigidbody MooseRB;
    public Animator Anim;
    public bool IsWalk = false;

    void Start()
    {
        MooseRB = Moose.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (IsWalk)
        {
            MooseRB.velocity = 500f * Time.deltaTime * -transform.forward;
        }
    }

    void OnTriggerEnter(Collider other)
    {
      /*if(other.CompareTag("Car"))
      {*/
        IsWalk = true;
        Anim.Play("WalkForward");
      /*}*/
    }
}
