using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStage : MonoBehaviour
{
    
    public GameObject uistageslotPrefab;
    public GameObject grid;

    private int length;
    private DataManager dataManager;
    private UIStageSlot UIStageSlot;

    void Start()
    {
        //dataManager.Displayall();
        //Debug.Log(dataManager.GetCount());
        //this.UIStageSlot=this.uistageslotPrefab.GetComponent<UIStageSlot>();
        //this.grid.GetComponent<Transform>();


    }
   
    void Update()
    {
        
        /*
        for (int i=0;i< length;i++)
        {
            var go = Instantiate(uistageslotPrefab);
            go.transform.parent = grid.transform;
        }
       */
    }
}
