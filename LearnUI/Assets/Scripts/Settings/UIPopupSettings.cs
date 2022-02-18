using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Newtonsoft.Json;

public class UIPopupSettings : MonoBehaviour
{
    public Button btnclose;
    public Toggle toggleEasy;
    public Toggle toggleMedium;
    public Toggle toggleHard;


    public SpriteAtlas atlas;
    public Image countryIcon;

    public Slider bgmSlider;
    public Slider sfxSlider;

    private EventTrigger eventTrigger;
    private EventTrigger eventTriggermedium;
    private SettingsInfo info;

    /*
    private void Awake()
    {
        this.Init();
    }
    */
    public void Init(SettingsInfo info)
    {
        this.info = info;
        this.eventTrigger = this.bgmSlider.gameObject.AddComponent<EventTrigger>();
        this.eventTriggermedium = this.toggleMedium.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback.AddListener((data) => {
            Debug.Log(bgmSlider.value);
            info.bgm = bgmSlider.value;
            info.difficulty =toggleMedium.onValueChanged.GetPersistentEventCount();
            //직렬화
            var json = JsonConvert.SerializeObject(info);
            Debug.Log(json);
            //저장(playerprefs)
            PlayerPrefs.SetString("settings_info", json);
        });
        eventTrigger.triggers.Add(entry);
        eventTriggermedium.triggers.Add(entry);
        this.bgmSlider.value = info.bgm;
       
    }
    public void Open(SettingsInfo info)
    {
        this.gameObject.SetActive(true);

        var data = DataManager.GetInstance().GetLanguageData(info.languageId);
        var sp = this.atlas.GetSprite(data.spriteName);
        this.countryIcon.sprite = sp;
        this.countryIcon.SetNativeSize();

        /*
        bgmSlider.onValueChanged.AddListener((val) => {

        });
        */
       
    }
    public void Close()
    {
        this.gameObject.SetActive(false);
    }

    
}
