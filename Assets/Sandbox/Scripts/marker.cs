using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MudBun;

public class marker : MonoBehaviour
{
    [SerializeField]
    MudMaterial material;
    [SerializeField]
    GameObject mark;

    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Топ");

        Quaternion rotation = Quaternion.LookRotation(Vector3.up);

        GameObject markI = Instantiate(mark, transform.position, rotation);
        markI.GetComponent<SpriteRenderer>().color = material.Color + material.Emission;
        StartCoroutine(Remove(markI));

    }

    private IEnumerator Remove(GameObject mark)
    {
        yield return new WaitForSeconds(2f);
        Destroy(mark.gameObject);
    }
}
