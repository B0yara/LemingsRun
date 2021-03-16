using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Center : MonoBehaviour
{
    public Transform target;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();
        rb.centerOfMass = target.position;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
