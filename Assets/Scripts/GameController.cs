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
   
  
    
    
    public  Cinemachine.CinemachineTargetGroup cinemachine;
    // Start is called before the first frame update
    void Start()
    {
        start = GameObject.FindGameObjectWithTag("Start").GetComponent<Transform>();
        SpawnUnits(countUnits);
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnUnits(int count)
    {
        for(int i =0;i<count;i++)
        {
            Transform spawnPoint= start;
           spawnPoint.position = start.position + Vector3.left * i;
            units.Add(Instantiate(prebafUnit,spawnPoint.position,spawnPoint.rotation));
            cinemachine.AddMember(units[i].transform, 1, 0.5f);
        }
    }
    
}
