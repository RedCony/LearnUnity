using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo 
{
    public int gold;
    public int gem;
    public int heart;
    public int score;

    public List<StageInfo> stageInfos;

    public List<ItemInfo> itemInfos;

    public GameInfo()
    {
        this.stageInfos = new List<StageInfo>();
        this.itemInfos = new List<ItemInfo>();
    }
   
}
