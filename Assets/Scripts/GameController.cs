using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    List<GameObject> units;
    public int countUnits;
    Transform start;
    [SerializeField]
    GameObject prebafUnit;
    int finishedUnits;
 
   
  
    
    
    public  Cinemachine.CinemachineTargetGroup cinemachine;
    // Start is called before the first frame update
    void Start()
    {
        start = GameObject.FindGameObjectWithTag("Start").GetComponent<Transform>();
        finishedUnits = 0;
        units.Clear();
        SpawnUnits(countUnits);
        Messenger.AddListener(GameEvent.UNIT_FINISHED, UnitFinished);
        Messenger<GameObject>.AddListener(GameEvent.UNIT_DISABLED, RemoveUnit);

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnUnits(int count)
    {
        
        for (int i =0;i<count;i++)
        {
            units.Add(Instantiate(prebafUnit, start.position + Vector3.left * i, start.rotation));
            Debug.Log(units[i]);
            cinemachine.AddMember(units[i].transform, 1, 0.5f);
        }
    }
    void UnitFinished()
    {

        finishedUnits++;

        if (units.Count == finishedUnits)
        {
            Messenger<int>.Broadcast(GameEvent.ALL_FINISHED, finishedUnits);
        }
    }
    public void RemoveUnit(GameObject unit)
    {
        cinemachine.RemoveMember(unit.transform);
        units.Remove(unit);
        Destroy(unit.gameObject);
        
        if(units.Count==0)
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        Messenger.Broadcast(GameEvent.GAME_OVER);
        Messenger.RemoveListener(GameEvent.UNIT_FINISHED, UnitFinished);
        Messenger<GameObject>.RemoveListener(GameEvent.UNIT_DISABLED, RemoveUnit);
    }
    
}
