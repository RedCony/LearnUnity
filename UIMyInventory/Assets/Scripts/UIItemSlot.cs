using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemSlot : MonoBehaviour
{
    public Image icon;
    public Text countText;
    public Button btn;
    public int id;

    public GameObject selectedGo;

    public System.Action<int> selectedAction;

    public void Start()
    {
        this.btn.onClick.AddListener(() =>
        {
            //print("test");
            //this.selectedGo.SetActive(!this.selectedGo.activeInHierarchy);
            this.selectedAction(this.id);
        });
    }

    public void Init(int id,Sprite sp, int count)
    {
        this.id = id;
        this.icon.sprite = sp;
        this.countText.text = count.ToString();
        this.icon.gameObject.SetActive(true);
        this.countText.gameObject.SetActive(true);
       
    }
}
