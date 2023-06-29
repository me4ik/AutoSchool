using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeerKick : MonoBehaviour
{
    private Rigidbody MooseRB;
    Animator Anim;
    public MooseTrigger mTrig;
    private GameObject Car;
    
    public float kickSpeed = 100f;

    bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        MooseRB = GetComponent<Rigidbody>();
        Car = GameObject.FindWithTag("Car");
    }

    void FixedUpdate()
    {
      if(isHit)
      {
       MooseRB.velocity = transform.right * kickSpeed * Time.deltaTime;
      }
    }

    void OnTriggerEnter(Collider other)
    {
          if(other.CompareTag("Car"))
          {
                  mTrig.IsWalk = false;
                  isHit = true;
                 Anim.Play("ComeDown");
              Invoke("LoadThisAgain", 1f);                
          }
    }

    void LoadThisAgain()
    {
    GameObject.Destroy(Car);
        SceneManager.LoadScene(0);
    }
}
