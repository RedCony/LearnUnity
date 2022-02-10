using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;


public class UIStageReady : MonoBehaviour
{
    public struct UIStageReadyParam
    {
        public string stageName;
        public string missionName;
        public List<string> itemSpriteNames;
        public List<int> itemCounts;
    }

    public Button btnStart;
    public Button btnClose;
    public Text textstagename;
    public Text textMissiondata;
    public Image[] itemIconImages;
    public Text[] itemCountTexts;
    public SpriteAtlas atlas;
    public Transform grid;
    
    public void Open(UIStageReadyParam param)
    {
        this.textstagename.text = param.stageName;
        this.textMissiondata.text = param.missionName;

        for (int i = 0; i < this.itemIconImages.Length; i++)
        {
            var sp = this.atlas.GetSprite(param.itemSpriteNames[i]);
            this.itemIconImages[i].sprite = sp; //������ ���� 
            this.itemIconImages[i].SetNativeSize(); //����׷� ���� 
            this.itemCountTexts[i].text = param.itemCounts[i].ToString();   //���� ���� 
        }

        this.gameObject.SetActive(true);
    }
    public void Init()
    {

    }
}
