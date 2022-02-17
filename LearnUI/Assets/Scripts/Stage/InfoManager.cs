using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

public class InfoManager 
{
    private static InfoManager instance;
    public GameInfo gameInfo;

    private Dictionary<int, MissionInfo> dicMissionInfos = new Dictionary<int, MissionInfo>();
    private InfoManager()
    {
    }

    public static InfoManager GetInstance()
    {
        if (InfoManager.instance == null) InfoManager.instance = new InfoManager();
        return InfoManager.instance;
    }
    public ItemInfo GetItemInfo(int id)
    {
        return gameInfo.itemInfos.Find(x=>x.id==id);
    }
    /*
    public MissionInfo GetMissionInfo(int id)
    {
        return gameInfo.missionInfos.Find(x => x.id == id);
    }
    */

    public void LoadMissionInfo()
    {
        var json = File.ReadAllText(Application.persistentDataPath + "/mission_info.json");

        this.dicMissionInfos = JsonConvert.DeserializeObject<MissionInfo[]>(json).ToDictionary(x => x.id);
    }

    public bool HasMissionInfo(int key)
    {
        return this.dicMissionInfos.ContainsKey(key);
    }

    public MissionInfo GetMissionInfo(int key)
    {
        return this.dicMissionInfos[key];
    }
}
