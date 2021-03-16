using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MudBun;

public class Health : MonoBehaviour
{
    public MudSharedMaterialBase material;
    public List<MudMaterial> spheres;
    // Start is called before the first frame update
    void Start()
    {
        foreach(MudMaterial m in spheres)
        {
            m.SharedMaterial = material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponentInParent<Dismember>().Healing(material);
        
        Debug.Log("Heal");
        Destroy(gameObject);
    }
}
