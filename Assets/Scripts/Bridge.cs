using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField]
    GameObject firstSash;
    [SerializeField]
    GameObject secondSash;
    [SerializeField]
    bool open;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.RED_CLICK, TurningBrige);
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        if (open)
        {
            firstSash.transform.localRotation = Quaternion.Euler(-130, 180, 0);
            secondSash.transform.localRotation = Quaternion.Euler(-130, 0, 0);
            
        }
        else
        {
            firstSash.transform.localRotation = Quaternion.Euler(-90, 180, 0);
            secondSash.transform.localRotation = Quaternion.Euler(-90, 0, 0);
            
        }
    }
    private void TurningBrige()
    {

        open = !open;
    
    }
}
