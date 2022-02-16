using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITabMenu : MonoBehaviour
{
   
    public GameObject activeGo;
    public GameObject inActiveGo;
    public GameObject scrollview;

    

    public void Active()
    {
        this.activeGo.SetActive(true);
        this.inActiveGo.SetActive(false);
        this.scrollview.SetActive(true);
    }
    public void InActive()
    {
        this.activeGo.SetActive(false);
        this.inActiveGo.SetActive(true);
        this.scrollview.SetActive(false);
    }
}
