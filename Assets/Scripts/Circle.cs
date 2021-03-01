using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField]
    float startRotation;
    [SerializeField]
    GameObject turningPart;

    private void Awake()
    {
        Messenger<float>.AddListener(GameEvent.ANGLE_CHANGED, Rotate);
    }
    void Start()
    {
        turningPart.transform.localRotation = Quaternion.Euler(-90, 0, startRotation);
    }

    // Update is called once per frame
    
    private void Rotate(float angle)
    {
        turningPart.transform.localRotation = Quaternion.Euler(-90, 0, startRotation+angle);
    }
}
