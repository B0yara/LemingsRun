using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIController : MonoBehaviour
{
     public  GameObject gameOver;
      public GameObject controller;
    public GameObject finish;
    public  Text text;
    Scenes scenes;
    

    private void Start()
    {
        Messenger.AddListener(GameEvent.GAME_OVER, GameOver);
        Messenger<int>.AddListener(GameEvent.ALL_FINISHED, Finish);
        scenes = FindObjectOfType<Scenes>();
    }
    public void OnAngleValue(float angle)
    {
        Messenger<float>.Broadcast(GameEvent.ANGLE_CHANGED, angle);
    }
    public void OnRedClick()
    {
        Messenger.Broadcast(GameEvent.RED_CLICK);
    }
    public void OnYellowClick()
    {
        Messenger.Broadcast(GameEvent.RUN);
    }
    public void Retry()
    {
        scenes.Retry();
    }
    void Finish(int units)
    {
        finish.SetActive(true);

        StartCoroutine(Scores(units));
        Messenger.RemoveListener(GameEvent.GAME_OVER, GameOver);
        Messenger<int>.RemoveListener(GameEvent.ALL_FINISHED, Finish);
    }
    void GameOver()
    {
        gameOver.SetActive(true);
        controller.SetActive(false);
        Messenger.RemoveListener(GameEvent.GAME_OVER, GameOver);
        Messenger<int>.RemoveListener(GameEvent.ALL_FINISHED, Finish);
    }

    private IEnumerator Scores(int uc)
    {
        int score=0;
        float i = 0;
       while(score<=uc*100) 
       {    
            
            text.text = score.ToString();
            score = (int)(uc * 100 * i);
            i += Time.deltaTime;
           yield return null;
        }
    }
}
