using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemstageready : MonoBehaviour
{
    public Image icon;
    public Text count;
   

    public GameObject checkObj;

    public void Init(Sprite sp, ItemInfo itemInfo)
    {
         icon.sprite = sp;
         icon.SetNativeSize();
         this.count.text = itemInfo.count.ToString();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
