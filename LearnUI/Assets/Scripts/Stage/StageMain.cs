using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using static UIStageReady;
using static UIStageLock;
using System.Linq;

public class StageMain : MonoBehaviour
{
    public GameObject uistageslotPrefab;
    public GameObject grid;
    public UIStageReady uiStageReady;
    public UIStageLock UIStageLock;


    List<UIStageSlot> uiStageSlotList;
    int length;
    UIStageSlot UIStageSlot;
    
    
   
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

        InitStagePanel();
    }

    void InitStagePanel()
    {
        this.uiStageSlotList = new List<UIStageSlot>();

        int i = 0;
        foreach (StageData data in DataManager.GetInstance().GetDicStageDatas().Values)
        {
            var go = Instantiate(this.uistageslotPrefab, grid.transform);
            var panel = go.GetComponent<UIStageSlot>();
            var num = i + 1;
            panel.Init(data.id, num);
            this.uiStageSlotList.Add(panel);
            
            panel.btn.onClick.AddListener(() =>
            {
                if (panel.State == UIStageSlot.eState.Open || panel.State==UIStageSlot.eState.Clear)
                {
                    Debug.LogFormat("selected panel id: <color=white>{0}</color>", panel.Id);

                    

                    StageMissionData stageMissiondata = DataManager.GetInstance().GetMissionData(data.stage_mission_id);
                    Debug.Log(stageMissiondata);
                    Debug.LogFormat("stage mission name: {0}", stageMissiondata.missionname);
                    
                    ItemData itemData0 = DataManager.GetInstance().GetItemData(data.take_item_id_0);
                    ItemData itemData1 = DataManager.GetInstance().GetItemData(data.take_item_id_1);
                    ItemData itemData2 = DataManager.GetInstance().GetItemData(data.take_item_id_2);
                    Debug.LogFormat("item(0) sprite name: {1}", itemData0.id, itemData0.spriteName);
                    Debug.LogFormat("item(0) sprite name: {1}", itemData0.id, itemData1.spriteName);
                    Debug.LogFormat("item(0) sprite name: {1}", itemData0.id, itemData2.spriteName);

                    ItemInfo itemInfo0 = InfoManager.GetInstance().GetItemInfo(itemData0.id);
                    int item0Count = (itemInfo0 == null) ? 0 : itemInfo0.count;
                    Debug.LogFormat("item id: {0}, count: {1}", itemData0.id, item0Count);

                    ItemInfo itemInfo1 = InfoManager.GetInstance().GetItemInfo(itemData1.id);
                    int item1Count = (itemInfo1 == null) ? 0 : itemInfo1.count;
                    Debug.LogFormat("item id: {0}, count: {1}", itemData1.id, item1Count);

                    ItemInfo itemInfo2 = InfoManager.GetInstance().GetItemInfo(itemData2.id);
                    int item2Count = (itemInfo2 == null) ? 0 : itemInfo2.count;
                    Debug.LogFormat("item id: {0}, count: {1}", itemData2.id, item2Count);

                    UIStageReadyParam param = new UIStageReadyParam()
                    {
                        stageName = data.name,
                        missionName = stageMissiondata.missionname,
                        itemSpriteNames = new List<string> {
                            itemData0.spriteName,
                            itemData1.spriteName,
                            itemData2.spriteName,
                        },
                        itemCounts = new List<int> {
                            item0Count,
                            item1Count,
                            item2Count
                        }
                    };

                    this.uiStageReady.Open(param);

                }
           
                else
                {
                    UIStageLockParam uIStageLockParam = new UIStageLockParam()
                    {
                        stageName = data.name,
                        requiredlevelnum = data.require_level
                    };
                    this.UIStageLock.Open(uIStageLockParam);
                    Debug.LogFormat("<color=white>{0}</color> is locked!", panel.Id);
                }
            });

            i++;

        }

        //check stageinfo
        if (InfoManager.GetInstance().gameInfo.stageInfos.Count == 0)
        {
            //havent play yet 
            var panel = this.uiStageSlotList[0];   //첫번재 패널 
            panel.Open();
        }
        else 
        {
            
            //Debug.Log(InfoManager.GetInstance().gameInfo.stageInfos.Count);

            int lastIndex = InfoManager.GetInstance().gameInfo.stageInfos.Count-1 ;

            StageInfo lastInfo = InfoManager.GetInstance().gameInfo.stageInfos[lastIndex];

            for (int j = 0; j <= lastIndex; j++)
            {
                StageInfo clearstageInfo = InfoManager.GetInstance().gameInfo.stageInfos[j];

                this.uiStageSlotList[j].Clear(clearstageInfo.star);

                int nextId = clearstageInfo.id + 1;

                var stageDataDic = DataManager.GetInstance().GetDicStageDatas();

                var list = stageDataDic.Values.ToList();
                var nextData = stageDataDic[nextId];
                var nextIndex = list.IndexOf(nextData);

                if (nextIndex > 0 && nextIndex < DataManager.GetInstance().GetDicStageDatas().Count-1)
                {
                    //int nextIndex = 0;
                    //foreach (var pair in stageDataDic) {
                    //    if (pair.Value.id == nextId) {
                    //        break;
                    //    }
                    //    nextIndex++;
                    //}

                    // Debug.LogFormat("nextIndex: {0}", nextIndex);


                    this.uiStageSlotList[nextIndex].Open();


                }
                else
                {
                    
                    Debug.Log("스테이지 클리어");
                }

            }

            //Debug.Log(lastInfo.id);

           



            /*
            int stageinfocount = InfoManager.GetInstance().gameInfo.stageInfos.Count;

            for (int j = 0; j < stageinfocount; j++)
            {
                StageInfo clearstageInfo = InfoManager.GetInstance().gameInfo.stageInfos[j];
               
                //update slot
                this.uiStageSlotList[j].Clear(clearstageInfo.star);

                //open next(현재 스테이지 
                int nextStageId = clearstageInfo.id + 1;


                //다음 스테이지가 있는지 확인
                int nextindex = DataManager.GetInstance().GetIndexOfStageData(nextStageId);
                int stagedatacount = DataManager.GetInstance().GetDicStageDatas().Count;
                //Debug.Log(stagedatacount);

                if( nextindex > 0 && nextindex < stagedatacount)
                {
                     this.uiStageSlotList[nextStageId].Open();
                }
                else
                {
                    Debug.Log("스테이지 클리어");
                }

            }
            */
        }
    }
    
    /*
    void LoadStageInfo()
    {
        string path = Application.persistentDataPath + "/stage_info.json";
        //print(path);
        var json = File.ReadAllText(path);
        InfoManager.GetInstance().stageInfo = JsonConvert.DeserializeObject<StageInfo>(json);
        //Debug.LogFormat("stageInfo loaded : {0}", InfoManager.GetInstance().stageInfo);
    }
    */
    void LoadGameInfo()
    {
        string path = Application.persistentDataPath + "/game_info.json";
        //print(path);
        var json = File.ReadAllText(path);
        InfoManager.GetInstance().gameInfo = JsonConvert.DeserializeObject<GameInfo>(json);
        //Debug.LogFormat("game_info loaded : {0}", InfoManager.GetInstance().gameInfo);
    }
    bool IsNewbie()
    {
        string path = Application.persistentDataPath + "/game_info.json";
        //print(path);
        return !File.Exists(path);
    }
    void CreateAndSaveGameInfo()
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
        this.UIStageSlot = this.uistageslotPrefab.GetComponent<UIStageSlot>();
        this.grid.GetComponent<Transform>();
        this.length = DataManager.GetInstance().GetCount();
        for (int i = 0; i < length; i++)
        {
            var go = Instantiate(uistageslotPrefab);
            go.transform.parent = grid.transform;
        }
    }
    /*
    void CreateAndSaveStageInfo()
    {
        InfoManager.GetInstance().stageInfo = new StageInfo();
        var json = JsonConvert.SerializeObject(InfoManager.GetInstance().stageInfo);
        //print(json);
        string path = Application.persistentDataPath + "/stage_info.json";
        //print(path);
        File.WriteAllText(path, json);
        //print("saved game_info.json");
    }
    */
    void Update()
    {
       

    }
}
