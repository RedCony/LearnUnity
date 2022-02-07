using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class UIlistItem : MonoBehaviour
{
    public Image icon;
    public Text countText;

    private int id;

    public void Init(int id,Sprite sp,int count)
    {
        this.id = id;
        this.icon.sprite = sp;
        this.countText.text = count.ToString();
    }
}
