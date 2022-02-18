using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using UnityEngine.U2D;

public class SettingsMain : MonoBehaviour
{
    public Button btnSettings;
    public UIPopupSettings UIPopupSettings;
    private SettingsInfo info;
    void Start()
    {
        DataManager.GetInstance().LoadLanguageData();

        if (PlayerPrefs.HasKey("settings_info"))
        {
            Debug.Log("셋팅 데이터 있음");
            //있으면 불러와서 역직렬화 해서 저장
            var json = PlayerPrefs.GetString("settings_info");

            this.info = JsonConvert.DeserializeObject<SettingsInfo>(json);
            Debug.LogFormat("languageID : {0}", info.languageId);

            var data = DataManager.GetInstance().GetLanguageData(info.languageId);

        }
        else
        {
            Debug.Log("셋팅 데이터 없음");
            //없다면 새로 만들어서 (기본값으로)
            this.info = new SettingsInfo();
            //직렬화
            var json = JsonConvert.SerializeObject(info);
            Debug.Log(json);
            //저장(playerprefs)
            PlayerPrefs.SetString("settings_info", json);
        }

        this.UIPopupSettings.Init(this.info);

        this.UIPopupSettings.btnclose.onClick.AddListener(() => {
            this.UIPopupSettings.Close();
        });
        this.btnSettings.onClick.AddListener(() => {
            this.UIPopupSettings.Open(this.info);
        });
        this.UIPopupSettings.toggleEasy.onValueChanged.AddListener((active) => {
            Debug.LogFormat("easymode: {0}", active);
        });
        this.UIPopupSettings.toggleMedium.onValueChanged.AddListener((active) => {
            Debug.LogFormat("mediummode: {0}", active);
        });
        this.UIPopupSettings.toggleHard.onValueChanged.AddListener((active) => {
            Debug.LogFormat("hardmode: {0}", active);
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
