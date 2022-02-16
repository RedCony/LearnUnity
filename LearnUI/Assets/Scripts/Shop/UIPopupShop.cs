using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class UIPopupShop : MonoBehaviour
{
    public enum eTabMenuType { None = -1, Gold, Gem, SoulGem }

    public Button btnClose;
    public UITabMenu[] uITabMenus;
    
    public Transform[] contentsTrans;
    public GameObject shoplistitemPrefab;

    public SpriteAtlas atlas;
   

    public void Init()
    {
        this.btnClose.onClick.AddListener(() => {
            this.Close();
        });
        
        //gold
        var shopGoldDatas=DataManager.GetInstance().GetShopGoldDatas();
       
        for (int i = 0; i < shopGoldDatas.Count; i++)
        {
            

            GameObject goldGo = Instantiate(this.shoplistitemPrefab, contentsTrans[0]);
            var uishoplistitem = goldGo.GetComponent<UIShoplistitem>();
            ShopData data = shopGoldDatas[i];
            uishoplistitem.Init(i,data,atlas);

            /*
            uishoplistitem.OnclickAction = (id) => {
                Debug.Log(id);

            };
            */
        }

        //gem
        var shopgemDatas = DataManager.GetInstance().GetShopGemDatas();

        for (int i = 0; i < shopgemDatas.Count; i++)
        {
            
            GameObject gemGo = Instantiate(this.shoplistitemPrefab, contentsTrans[1]);
            var uishoplistitemgem = gemGo.GetComponent<UIShoplistitem>();
            ShopData data = shopgemDatas[i];
            uishoplistitemgem.Init(i, data, atlas);

            /*
            uishoplistitem.OnclickAction = (id) => {
                Debug.Log(id);

            };
            */
        }
        //soulgem
        var shopsoulgemDatas = DataManager.GetInstance().GetShopSoulGemDatas();

        for (int i = 0; i < shopsoulgemDatas.Count; i++)
        {
            
            GameObject soulgemGo = Instantiate(this.shoplistitemPrefab, contentsTrans[2]);
            var uishoplistitemsoulgem = soulgemGo.GetComponent<UIShoplistitem>();
            ShopData data = shopsoulgemDatas[i];
            uishoplistitemsoulgem.Init(i, data, atlas);

            /*
            uishoplistitem.OnclickAction = (id) => {
                Debug.Log(id);

            };
            */
        }
    }
    public void Open(eTabMenuType eTabMenuType)
    {
        foreach(var tabmenu in this.uITabMenus)
        {
            tabmenu.InActive();
        }

        int index = (int)eTabMenuType;

        var targetTabMenu = this.uITabMenus[index];
       
        targetTabMenu.Active();
       

        this.gameObject.SetActive(true);
    }
    public void Close()
    {
        this.gameObject.SetActive(false);
    }
}
