using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

public class DataManager
{
    private static DataManager instance;

    Dictionary<int, WeaponData> dicWeaponDatas;

    Dictionary<int, MonsterData> dicMonsterDatas;

   

    private DataManager() 
    {
        this.dicWeaponDatas = new Dictionary<int, WeaponData>();
        this.dicMonsterDatas = new Dictionary<int, MonsterData>();
    }

    public static DataManager GetInstance()
    {
        if (DataManager.instance == null)
        {
            DataManager.instance = new DataManager();
        }
        return DataManager.instance;
    }

    public void LoadWeaponData()
    {
        string path = "Data/Weapon_Data";
        TextAsset textAsset = Resources.Load<TextAsset>(path);
        string json = textAsset.text;
       
        WeaponData[] weaponDatas = JsonConvert.DeserializeObject<WeaponData[]>(json);
        for ( int id = 0; id < weaponDatas.Length; id++)
        {
            WeaponData weapon = weaponDatas[id];
           // Debug.LogFormat("{0},{1},{2},{3}", weapon.id, weapon.name, weapon.damage, weapon.prefabName);
            dicWeaponDatas.Add(weapon.id, weapon);
        }
       
    }
    public WeaponData GetWeaponData(int id)
    {
       return this.dicWeaponDatas[id]; 
    }

    public void LoadMonsterData()
    {
        string path = "Data/Monster_Data";
        TextAsset textAsset = Resources.Load<TextAsset>(path);
        string json = textAsset.text;

        MonsterData[] monsterDatas = JsonConvert.DeserializeObject<MonsterData[]>(json);
        for (int id = 0; id < monsterDatas.Length; id++)
        {
            MonsterData monster = monsterDatas[id];
            // Debug.LogFormat("{0},{1},{2},{3}", monster.id, monster.name, monster.damage, monster.prefabName);
            dicMonsterDatas.Add(monster.id, monster);
        }
    }

    public MonsterData GetMonsterData(int id)
    {
        return this.dicMonsterDatas[id]; 
    }



}
