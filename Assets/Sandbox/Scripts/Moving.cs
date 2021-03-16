using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public Transform target;
    Rigidbody rb;
    public Vector3 direction;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(direction,Space.World);
        transform.RotateAround(target.transform.position,direction, speed * Time.deltaTime);
    }
}
