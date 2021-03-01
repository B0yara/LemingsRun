using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField]
    float startRotation;
    [SerializeField]
    GameObject turningPart;
    public float rotationSpeed;
    Quaternion newRotation;
    private void Awake()
    {
        Messenger<float>.AddListener(GameEvent.ANGLE_CHANGED, Rotate);
    }
    void Start()
    {
        turningPart.transform.localRotation = Quaternion.Euler(-90, 0, startRotation);
       
    }
    private void Update()
    {
        turningPart.transform.localRotation = Quaternion.Lerp
             (turningPart.transform.localRotation, newRotation, rotationSpeed);
    }

    // Update is called once per frame

    private void Rotate(float angle)
    {
         newRotation = Quaternion.Euler(-90, 0, startRotation + angle);
       
       
    }
}
