using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       UnitBehaviour ub= other.GetComponent<UnitBehaviour>();
        if(ub!=null)
        {
            ub.StartDancing();
        }
    }
}
