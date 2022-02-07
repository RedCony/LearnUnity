using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using Newtonsoft.Json;
using System.Linq;
using System.IO;

public class MiniTestMain : MonoBehaviour
{
    public List<UIItemSlot> slots;
    public Button btn;
    public SpriteAtlas atlas;

    private Dictionary<int, ItemData> dic;
    private List<MyItemInfo> myItemInfos;

    private int selectedSlotId = -1;
    void Start()
    {
        this.LordData();

        this.InitUI();

        this.btn.onClick.AddListener(() =>
        {
            this.LoadMyItemInfo();
            this.UpdateUI();
        });
    }
    private void InitUI()
    {
        foreach(var slot in this.slots)
        {
            slot.selectedAction = (id) => 
            {
                if (id == 0) { return; }

                if (this.selectedSlotId != id)
                {
                    this.InvisibleSelectedMark();
                    this.selectedSlotId = id;
                    this.VisibleSelectedMark();
                }
                else
                {
                    this.InvisibleSelectedMark();
                    this.selectedSlotId = -1;
                }
            };
        }
    }

    private void InvisibleSelectedMark()
    {
        foreach (var slot in this.slots)
        {
            slot.selectedGo.SetActive(false);
        }
    }

    private void VisibleSelectedMark()
    {
        foreach (var slot in this.slots)
        {
            if (slot.id == this.selectedSlotId)
            {
                slot.selectedGo.SetActive(true);
            }
        }
    }
    private void LoadMyItemInfo()
    {
        var path = Application.persistentDataPath + "/my_item_infos.json";
        var json = File.ReadAllText(path);

        if(this.myItemInfos!= null) { this.myItemInfos.Clear(); }
        
        this.myItemInfos = JsonConvert.DeserializeObject<MyItemInfo[]>(json).ToList();
    }
    private void UpdateUI()
    {
        for(int i = 0; i < this.slots.Count; i++)
        {
            if (i < this.myItemInfos.Count)
            {
                var info = this.myItemInfos[i];
                //print(info);
                var data = this.dic[info.id];
                var sp = this.atlas.GetSprite(data.spriteName);
                //print(sp);

                var slot = this.slots[i];
                slot.Init(info.id, sp, info.count);
            }
        }
    }

    private void LordData()
    {
        var path = "MiniTest/Data/item_data";
        var textAsset = Resources.Load<TextAsset>(path);
        var json = textAsset.text;
        print(json);
        this.dic = JsonConvert.DeserializeObject<ItemData[]>(json).ToDictionary(x=>x.id);
    }
}
