using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MudBun;

public class BodyPart : MonoBehaviour
{
    [SerializeField]
    public int priority;
    MudMaterial material;
    [SerializeField]
    GameObject mark;
    public  BodyPart chain;
    public GameObject blop;
   public GameObject parent;
    
    // Start is called before the first frame update
    void Start()
    {
         material = GetComponent<MudMaterial>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void Hurt()
    {
        
        if (chain!=null)
        {
            chain.Hurt();
        }
        blop.GetComponent<MudMaterial>().Color=material.Color;
        blop.GetComponent<MudMaterial>().Emission = material.Emission;
        Instantiate(blop, transform.position, Quaternion.identity,parent.transform);
   
           

        gameObject.SetActive(false);
        if (priority == 5)
        {
            parent.GetComponent<Dismember>().FootHurt();
        }
    }
        
       
       
}
