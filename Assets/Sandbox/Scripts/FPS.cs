using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    public static float fps;
    Text text;
    private void Start()
    {
      text =   GetComponent<Text>();
        StartCoroutine(FPScorutine());
    }
    private void LateUpdate()
    {

        

    }
    void OnGUI()
    {
        fps = 1f / Time.deltaTime;

    }

    void repeat()
    {
        StartCoroutine(FPScorutine());
    }

    IEnumerator FPScorutine()
    {
        yield return new WaitForSeconds(0.5f);
        text.text =  Mathf.RoundToInt(fps).ToString();
        repeat();
    }

}
