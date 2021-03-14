using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviour : MonoBehaviour
{
    
    [SerializeField]
    [Range(0,10f)]
    float speed;
    float gravity=  -9.8f;
    public bool isRunning = false;
   public Animator anim;
  CharacterController controller;
    Vector3 direction = Vector3.zero;
    GameController gameController;
    public bool isLeftJumping = false;
    public bool isRightJumping = false;
    public bool isCrowling = false;

    void Start()
    {
        Messenger.AddListener(GameEvent.RUN, Run);

        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("IsLeftJumping", isLeftJumping);
        anim.SetBool("IsRightJumping", isRightJumping);
        anim.SetBool("IsCrowling", isCrowling);
        if (!controller.isGrounded)
        {
            
            direction.y =  gravity;
        }
        else
        {
            if (isRunning)
            {
                direction = transform.TransformDirection(Vector3.forward * speed);
            }
            else
            {
                direction = transform.TransformDirection(Vector3.zero);
            }
            direction.y = 0;
        }
         anim.SetBool("isRuning", isRunning);
        controller.Move(direction * Time.deltaTime);

        if(transform.position.y<0)
        {
            Messenger<GameObject>.Broadcast(GameEvent.UNIT_DISABLED, gameObject);
        }
    }
    private void Run()
    {
        isRunning = !isRunning;
    }
    public void StartDancing()
    {
        isRunning = false;
        anim.SetBool("isRuning", isRunning);
        anim.SetTrigger("isDancing");
    }
   
    
}
