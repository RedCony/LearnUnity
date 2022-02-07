using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

public class Myinfoinventory : MonoBehaviour
{
    public GameObject uilistitemprefab;
    public SpriteAtlas spriteAtlas;
    public Transform horizontalgrid;
    public UIlistItem[] uIlistItems;

    private Dictionary<int, ItemData> dic ;


    private void LoadItemInfos()
    {
        var path = string.Format("{0}/items_info.json", Application.persistentDataPath);
        print(path);
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            print(json);
            //역직렬화
            var itemInfos = JsonConvert.DeserializeObject<ItemInfo[]>(json);
            foreach(var info in itemInfos)
            {
                Debug.LogFormat("ID:{0} count:{1}", info.id, info.count);
                var go= Instantiate<GameObject>(this.uilistitemprefab,this.horizontalgrid);
                var uilistitem = go.GetComponent<UIlistItem>();
                ItemData data = this.dic[info.id];
                var sp = this.spriteAtlas.GetSprite(data.spritename);
                uilistitem.Init(info.id,sp,info.count);
            }
        }
        else
        {
            print("파일을 찾을 수 없습니다.");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadItemInfos();
        LoadItemData();
        InitInventory();
    }

    private void LoadItemData()
    {
        var json = Resources.Load<TextAsset>("item_data").text;
        this.dic = JsonConvert.DeserializeObject<ItemData[]>(json).ToDictionary(x => x.id);
    }
    private void InitInventory()
    {
        int i = 0;
        foreach(var data in this.dic.Values)
        {
            var sp = this.spriteAtlas.GetSprite(data.spritename);
            var uilistitem = this.uIlistItems[i++];
            uilistitem.Init(data.id, sp, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
