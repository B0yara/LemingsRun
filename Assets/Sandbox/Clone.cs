using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Clone : MonoBehaviour
{
    public Transform transformBone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = transformBone.position;
        transform.rotation = transformBone.rotation;
    }
}
