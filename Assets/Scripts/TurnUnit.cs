using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnUnit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.transform.Rotate(0, 90, 0);
    }
}
