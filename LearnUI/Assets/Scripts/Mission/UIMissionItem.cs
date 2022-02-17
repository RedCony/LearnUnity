using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class UIMissionItem : MonoBehaviour
{
    public enum eState
    {
        None=-1,
        Doing,
        Done,
        Complete
    }

    public Image icon;
    public Text textname;
    public Image rewardicon;
    public Text textreward;
    public Slider slider;
    public GameObject[] arrstateGo;
    public eState state = eState.Doing;
    public UIStarContainer UIStarContainer;

    private int id;

    public void Init(int id,string iconname,string missionName,string rewardIconName, int rewardval)
    {
        this.id = id;
        this.textname.text = missionName;
        SpriteAtlas atlas = AssetManager.GetInstance().GetAtlas(AssetManager.eAtlas.MissionAtlas);
        this.icon.sprite = atlas.GetSprite(iconname);
        this.icon.SetNativeSize();
        this.rewardicon.sprite = atlas.GetSprite(rewardIconName);
        this.rewardicon.SetNativeSize();
        this.textreward.text = rewardval.ToString();
        

        var info = InfoManager.GetInstance().GetMissionInfo(this.id);
        if (info == null)
        {
            this.slider.value = 0;
            this.SetState(eState.Doing);
            this.UIStarContainer.Init();
        }
        else
        {
            var data = DataManager.GetInstance().GetData<MissionData>()[this.id];
            var per = (float)data.goal / info.process;
            this.slider.value = per;

            this.UIStarContainer.UpdateStars(info.star);

            this.SetState((eState)info.state);
        }
    }

    public void SetState(eState state)
    {
        foreach (var go in this.arrstateGo)
        {
            go.SetActive(false);
        }
        this.state = state;
        this.arrstateGo[(int)this.state].SetActive(true);
    }
}
