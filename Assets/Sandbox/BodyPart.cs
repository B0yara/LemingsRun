using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MudBun;

public class BodyPart : MonoBehaviour
{
    [SerializeField]
    private int priority;
    MudMaterial material;
    [SerializeField]
    GameObject mark;
    // Start is called before the first frame update
    void Start()
    {
         material = GetComponent<MudMaterial>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Топ");
        Vector3 position = collision.contacts[0].point;
        Quaternion rotation = Quaternion.LookRotation(collision.contacts[0].normal);
        
       GameObject markI = Instantiate(mark, position, rotation);
        markI.GetComponent<SpriteRenderer>().color = material.Color+material.Emission;
        StartCoroutine(Remove(markI));
    }
    private IEnumerator Remove (GameObject mark)
    {
        yield return new WaitForSeconds(1f);
        Destroy(mark.gameObject);
    }
}
