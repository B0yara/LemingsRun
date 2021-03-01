using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviour : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField]
    [Range(0,10f)]
    float speed;
    float gravity=  -9.8f;
    public bool isRunning = false;
   public Animator anim;
  CharacterController controller;
    Vector3 direction = Vector3.zero;

    void Start()
    {

        
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(!controller.isGrounded)
        {
            
            direction.y =  gravity;
        }
        else
        {
            if (isRunning)
            {
                direction = transform.TransformDirection(Vector3.forward * speed);
            }
            direction.y = 0;
        }
         anim.SetBool("isRuning", isRunning);
        if(Input.GetKeyUp(KeyCode.F))
        {
            anim.SetTrigger("isDancing");
        }

        controller.Move(direction * Time.deltaTime);
    }
}
