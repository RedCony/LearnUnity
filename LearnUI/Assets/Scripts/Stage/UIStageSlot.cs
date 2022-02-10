using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class UIStageSlot : MonoBehaviour
{
    public enum eState
    {
        None = -1,
        Open,
        Lock
    }

    public Text stageNum;
    public Image icon;
    public Image iconlock;
    public SpriteAtlas atlas;
    public Button btn;

    public GameObject stargrid;
    public GameObject starPrefab;
    public GameObject openGo;
    public GameObject lockGo;

    public eState State
    {
        get; private set;
    }

    public int Id
    {
        get; private set;
    }
    
    public void Init(int id,int num)
    {
        this.Id = id;
        this.stageNum.text = num.ToString();
        this.State = eState.None;
        this.Lock();
    }
    public void Open()
    {
        this.State = eState.Open;
        this.openGo.SetActive(true);
        this.lockGo.SetActive(false);
    }
    public void Lock()
    {
        this.State = eState.Lock;
        this.openGo.SetActive(false);
        this.lockGo.SetActive(true);
    }
    /*
    void Start()
    {
        this.count = InfoManager.GetInstance().gameInfo.stageInfos.Count;
    }
    void Update()
    {
        if (count == 0)
        {
            var sp = this.atlas.GetSprite("Frame_StageFrame_d");
            icon.sprite = sp;
            iconlock.gameObject.SetActive(true);
        }
        else
        {
            var sp = this.atlas.GetSprite("Frame_StageFrame_s");
            icon.sprite = sp;
            iconlock.gameObject.SetActive(false);
        }
    }
    */
}
