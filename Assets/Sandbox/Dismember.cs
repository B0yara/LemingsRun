using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dismember : MonoBehaviour
{
   public UnitBehaviour unit;
    public  List<BodyPart> bodyParts;
    public BodyPart leftFoot;
    public BodyPart rightFoot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Healing()
    {
        BodyPart needHealing = null;
        foreach (BodyPart bp in bodyParts)
            {
            if (!bp.gameObject.activeSelf)
                 {
                    if (needHealing == null)
                         { 
                              needHealing = bp;
                         }
                    if (needHealing.priority<bp.priority)
                         {
                             needHealing = bp;
                         }
                 }
            }
        needHealing.gameObject.SetActive(true);
    }

    public void FootHurt()
    {
        int i = 0;
        if (leftFoot.gameObject.activeSelf)
            i++;
        if (rightFoot.gameObject.activeSelf)
            i++;
        if(i==0)
        {
            unit.isCrowling = true;
        }
        if(i==1)
        {
            if(leftFoot.gameObject.activeSelf)
            {
                unit.isLeftJumping=true;
            }
            else
            {
                unit.isRightJumping = true;
            }
        }
    }
}
