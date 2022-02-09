using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class StageMain : MonoBehaviour
{
    public GameObject uistageslotPrefab;
    public GameObject grid;

    private int length;
    private UIStageSlot UIStageSlot;
    void Start()
    {
        DataManager.GetInstance().LoadItemData();
        DataManager.GetInstance().LoadStageData();
        DataManager.GetInstance().StageMissionData();
        Debug.Log("<color=yellow>data load complete!</color>");

        bool newbie = this.IsNewbie();
        Debug.LogFormat("신규유저 여부:{0}", newbie);
        if (newbie)
        {
            this.CreateAndSaveGameInfo();
        }
        else 
        {
            this.LoadGameInfo();
        }
        Debug.Log("<color=cyan>ready to play!!!</color>");

        this.UIStageSlot = this.uistageslotPrefab.GetComponent<UIStageSlot>();
        this.grid.GetComponent<Transform>();
        this.length = DataManager.GetInstance().GetCount();
        this.CrateSlots();
    }
    private void LoadGameInfo()
    {
        string path = Application.persistentDataPath + "/game_info.json";
        //print(path);
        var json = File.ReadAllText(path);
        InfoManager.GetInstance().gameInfo = JsonConvert.DeserializeObject<GameInfo>(json);
        Debug.LogFormat("game_info loaded : {0}", InfoManager.GetInstance().gameInfo);
    }
    private bool IsNewbie()
    {
        string path = Application.persistentDataPath + "/game_info.json";
        //print(path);
        return !File.Exists(path);
    }
    private void CreateAndSaveGameInfo()
    {
        InfoManager.GetInstance().gameInfo = new GameInfo();
        var json = JsonConvert.SerializeObject(InfoManager.GetInstance().gameInfo);
        //print(json);
        string path = Application.persistentDataPath + "/game_info.json";
        //print(path);
        File.WriteAllText(path, json);
        //print("saved game_info.json");
    }
    void CrateSlots()
    {
        for (int i = 0; i < length; i++)
        {
            var go = Instantiate(uistageslotPrefab);
            go.transform.parent = grid.transform;
        }
    }
    void Update()
    {
       

    }
}
