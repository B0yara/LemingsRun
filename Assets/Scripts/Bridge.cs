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
    public float rotationSpeed;
    Quaternion firstOpen = Quaternion.Euler(-130, 180, 0);
    Quaternion secondOpen = Quaternion.Euler(-130, 0, 0);
    Quaternion firstClosed = Quaternion.Euler(-90, 180, 0);
    Quaternion secondClosed = Quaternion.Euler(-90, 0, 0);
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
        
            firstSash.transform.localRotation = Quaternion.Lerp
                (firstSash.transform.localRotation, firstOpen,rotationSpeed);
            secondSash.transform.localRotation = Quaternion.Lerp
                (secondSash.transform.localRotation, secondOpen, rotationSpeed);

        }
        else
        {
            firstSash.transform.localRotation = Quaternion.Lerp
              (firstSash.transform.localRotation, firstClosed, rotationSpeed);
            secondSash.transform.localRotation = Quaternion.Lerp
                (secondSash.transform.localRotation, secondClosed, rotationSpeed);

        }
    }
    private void TurningBrige()
    {

        open = !open;
    
    }
}
