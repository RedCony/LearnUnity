using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class MyInfoMain : MonoBehaviour
{
    public UIHeroInfo UIHeroInfo;
    public UIInventory uiInventory;

    void Start()
    {
        //item_data.json 데이터를 로드한다 
        var textAsset = Resources.Load<TextAsset>("item_data");
        var itemDatajson = textAsset.text;
        //역직렬화
        ItemData[] itemDatas = JsonConvert.DeserializeObject<ItemData[]>(itemDatajson);
        Dictionary<int, ItemData> dicItemDatas = new Dictionary<int, ItemData>();
        foreach (var itemData in itemDatas)
        {
            dicItemDatas.Add(itemData.id, itemData);
        }
        //print(dicItemDatas.Count);





        //Debug.Log(Application.persistentDataPath);
        var json = File.ReadAllText(Application.persistentDataPath + "/hero_info.json");
        //print(json);

        //역직렬화 string -> object (HeroInfo객체)
        HeroInfo heroInfo= JsonConvert.DeserializeObject<HeroInfo>(json);
        //Debug.Log(heroInfo.attack);

        this.UIHeroInfo.Init(heroInfo.userName,heroInfo.Level, heroInfo.attack, heroInfo.defense, heroInfo.health, heroInfo.gold, heroInfo.gem);
       
        
        //아이템 획득
        var itemInfo0 = this.GetItem(100);
        var itemInfo1 = this.GetItem(101);
        var itemInfo2 = this.GetItem(102);
        var itemInfo3 = this.GetItem(103);
        var itemInfo4 = this.GetItem(104);
        var itemInfo5 = this.GetItem(105);
        var itemInfo6 = this.GetItem(106);
        var itemInfo7 = this.GetItem(107);
        var itemInfo8 = this.GetItem(108);
        var itemInfo9 = this.GetItem(109);
        var itemInfo10 = this.GetItem(110);
        var itemInfo11 = this.GetItem(111);
        var itemInfo12 = this.GetItem(112);



        //배열에 넣는다.
        List<ItemInfo> list = new List<ItemInfo>();
        list.Add(itemInfo0);
        list.Add(itemInfo1);
        list.Add(itemInfo2);
        list.Add(itemInfo3);
        list.Add(itemInfo4);
        list.Add(itemInfo5);
        list.Add(itemInfo6);
        list.Add(itemInfo7);
        list.Add(itemInfo8);
        list.Add(itemInfo9);
        list.Add(itemInfo10);
        list.Add(itemInfo11);
        list.Add(itemInfo12);

        //직렬화 (object -> json)
        var itemsJson = JsonConvert.SerializeObject(list);

        Debug.Log(itemsJson);

        //파일로 저장
        var path = Application.persistentDataPath + "/items_info.json";
        Debug.Log(path);
        File.WriteAllText(path, itemsJson);
        

        var path1 = Application.persistentDataPath + "/items_info.json";
        var itemsJson1 = File.ReadAllText(path1);

        //역직렬화  (string -> object)
        var itemInfos = JsonConvert.DeserializeObject<ItemInfo[]>(itemsJson1);

        //uiinventory에게 배열 전달 
        this.uiInventory.Init(itemInfos, dicItemDatas);
    }
    public ItemInfo GetItem(int id)
    {
        return new ItemInfo(id);
    }

}
