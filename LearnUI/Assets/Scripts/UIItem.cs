using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public Image icon;
    public Text count;
    public Button btninfo;

    public UIItemInfo UIItemInfo;


    void Start()
    {
        //this.UIItemInfo = FindObjectOfType("UIItemInfo");
        this.btninfo.onClick.AddListener(() => {
            UIItemInfo.Open();
        });
    }
    public void Init(Sprite sp,ItemInfo itemInfo)
    {
        if (sp == null)
        {
            this.icon.gameObject.SetActive(false);
        }
        else
        {
            icon.sprite = sp;
            icon.SetNativeSize();
            this.icon.gameObject.SetActive(true);
            this.count.text = itemInfo.count.ToString();
          
        }
    }
}
