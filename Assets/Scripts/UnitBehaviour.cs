using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviour : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField]
    [Range(0,0.1f)]
    float speed;
    public bool isRunning = false;
   public Animator anim;
  
  
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isRunning)
        {
          
             rigidBody.AddRelativeForce( Vector3.forward * speed, ForceMode.VelocityChange);  
        }

         anim.SetBool("isRuning", isRunning);
        if(Input.GetKeyUp(KeyCode.F))
        {
            anim.SetTrigger("isDancing");
        }
        
       
    }
}
