using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMain : MonoBehaviour
{
    public Button btnSoulGem;
    public Button btnGold;
    public Button btnGem;
    public UIPopupShop UIPopupShop;
    public Button btnTabSoulGem;
    public Button btnTabGold;
    public Button btnTabGem;



    void Start()
    {

        DataManager.GetInstance().LoadShopData();
        DataManager.GetInstance().LoadBudgetData();
        
        this.UIPopupShop.Init();

        this.btnSoulGem.onClick.AddListener(() => {
            this.UIPopupShop.Open(UIPopupShop.eTabMenuType.SoulGem);
        });
        this.btnGold.onClick.AddListener(() => {
            this.UIPopupShop.Open(UIPopupShop.eTabMenuType.Gold);
        });
        this.btnGem.onClick.AddListener(() => {
            this.UIPopupShop.Open(UIPopupShop.eTabMenuType.Gem);
        });
        this.btnTabSoulGem.onClick.AddListener(() => {
            this.UIPopupShop.Open(UIPopupShop.eTabMenuType.SoulGem);
        });
        this.btnTabGold.onClick.AddListener(() => {
            this.UIPopupShop.Open(UIPopupShop.eTabMenuType.Gold);
        });
        this.btnTabGem.onClick.AddListener(() => {
            this.UIPopupShop.Open(UIPopupShop.eTabMenuType.Gem);
        });
    }

    void Update()
    {
        
    }
}
