using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class DataManager
{
    private static DataManager instance;
    private Dictionary<int, StageData> dicStageDatas;
    private Dictionary<int, StageMissionData> dicStageMissiondatas;
    private Dictionary<int, ItemData> dicItemDatas;

    
    private DataManager() { }

    public static DataManager GetInstance()
    {
        if (DataManager.instance == null) DataManager.instance = new DataManager();
        return DataManager.instance;
    }

    public void LoadStageData()
    {
        var json = Resources.Load<TextAsset>("stage_data").text;
        this.dicStageDatas = JsonConvert.DeserializeObject<StageData[]>(json).ToDictionary(x => x.id);
        Debug.LogFormat("Loaded stage_data : {0}", this.dicStageDatas.Count);
        GetCount();
    }

    public void LoadItemData()
    {
        var json = Resources.Load<TextAsset>("item_data").text;
        this.dicItemDatas = JsonConvert.DeserializeObject<ItemData[]>(json).ToDictionary(x => x.id);
        Debug.LogFormat("Loaded item_data : {0}", this.dicItemDatas.Count);
    }

    public void StageMissionData()
    {
        var json = Resources.Load<TextAsset>("stagemission_data").text;
        this.dicStageMissiondatas = JsonConvert.DeserializeObject<StageMissionData[]>(json).ToDictionary(x => x.id);
        Debug.LogFormat("Loaded stage_mission_data : {0}", this.dicStageMissiondatas.Count);
    }

    public int GetCount()
    {
        return this.dicStageDatas.Count;
    }
    public void Displayall()
    {
        foreach (KeyValuePair<int, StageData> kv in dicStageDatas)
        {
            Debug.LogFormat("name : {0}", kv.Value.name);
        }
    }
    public Dictionary<int,StageData> DicStageDatas()
    {
        return this.dicStageDatas;
    }

    public Dictionary<int, StageMissionData> DicStageMissiondatas()
    {
        return this.dicStageMissiondatas;
    }

    public Dictionary<int, ItemData> DicItemDatas()
    {
        return this.dicItemDatas;
    }
}
