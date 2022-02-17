using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionMain : MonoBehaviour
{
    public Transform contentTrans;
    public GameObject uiMissionItemPrefab;
    void Start()
    {
        InfoManager.GetInstance().LoadMissionInfo();

        AssetManager.GetInstance().LoadAtlas(AssetManager.eAtlas.MissionAtlas, "Atlas/MissionAtlas");
        DataManager.GetInstance().LoadData<BudgetMissionData>("budjet_mission_data");
        DataManager.GetInstance().LoadData<MissionData>("mission_data");

        var dic = DataManager.GetInstance().GetData<MissionData>();
        var dic2 = DataManager.GetInstance().GetData<BudgetMissionData>();

        foreach(var data in dic.Values)
        {
            var missionName = string.Format(data.name, data.goal);
            var budgetMidata = dic2[data.reward_id];
            Debug.LogFormat("{0}, {1}, {2} {3}", data.id, missionName, budgetMidata.spriteName, data.reward_val);

            var go = Instantiate<GameObject>(this.uiMissionItemPrefab,this.contentTrans);
            var missionItem = go.GetComponent<UIMissionItem>();
            missionItem.Init(data.id,data.spriteName,missionName, budgetMidata.spriteName,data.reward_val);
        }
    }

    
    void Update()
    {
        
    }
}
