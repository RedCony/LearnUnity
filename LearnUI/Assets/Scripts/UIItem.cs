using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public Image icon;
    public Text count;
    

    public void Init(Sprite sp)
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
            
        }
    }
}
