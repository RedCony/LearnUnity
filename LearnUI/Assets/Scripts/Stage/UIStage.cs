using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStage : MonoBehaviour
{
    
    public GameObject uistageslotPrefab;
    public GameObject grid;

    //private int length;
    private UIStageSlot UIStageSlot;

    void Start()
    {
        //this.UIStageSlot=this.uistageslotPrefab.GetComponent<UIStageSlot>();
        //this.grid.GetComponent<Transform>();
        //this.length = DataManager.GetInstance().GetCount();
        //CrateSlots();
        //Debug.Log(length);
    }
   
    void Update()
    {
        
       
    }
    /*
    void CrateSlots()
    {
        for (int i = 0; i < length; i++)
        {
            var go = Instantiate(uistageslotPrefab);
            go.transform.parent = grid.transform;
        }
    }
    */
}
