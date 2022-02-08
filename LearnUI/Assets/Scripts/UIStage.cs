using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStage : MonoBehaviour
{
    
    public GameObject uistageslotPrefab;
    public GameObject grid;

    private int length;
    GameInfo gameInfo;
   

    void Start()
    {
        
        this.uistageslotPrefab.GetComponent<UIStageSlot>();
        this.grid.GetComponent<Transform>();
        length = gameInfo.stageInfos.Count;
        Debug.Log(length);
        
    }
   
    void Update()
    {
        
        for (int i=0;i< length;i++)
        {
            var go = Instantiate(uistageslotPrefab);
            go.transform.parent = grid.transform;
        }
       
    }
}
