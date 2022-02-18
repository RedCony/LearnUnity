using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsInfo 
{
    public int difficulty;
    public float bgm;
    public float sfx;
    public int notice;
    public int savePower;
    public int languageId;

    public SettingsInfo()
    {
        var data = DataManager.GetInstance().GetLanguageData(Application.systemLanguage);
        this.languageId = data.id;


    }
}
