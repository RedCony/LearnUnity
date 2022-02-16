using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.U2D;

public class UIShoplistitem : MonoBehaviour
{
    public Image icon;
    public Image budgeticon;
    public Button btnGet;
    public Text textitem;
    public Text textbonus;
    public Text textprice;


    private int id;
    private ShopData data;

    public UnityAction<int> OnclickAction;

    public void Init(int index , ShopData data,SpriteAtlas atlas)
    {
        this.textitem.text = index.ToString();
        this.data = data;
        this.id = this.data.id;
        this.icon.sprite = atlas.GetSprite(data.spriteName);
        this.icon.SetNativeSize();

        this.textitem.text = this.data.name;
        if (this.data.bonus > 0)
        {
            this.textbonus.text = string.Format("Bonus:{0}", this.data.bonus);
        }
        else
        {
            this.textbonus.gameObject.SetActive(false);
        }

        this.textprice.text = this.data.price.ToString();


        BudgetData budgetData= DataManager.GetInstance().GetBudgetDatas(this.data.budget_id);
        this.budgeticon.sprite = atlas.GetSprite(budgetData.spriteName);
        this.budgeticon.SetNativeSize();

        /*
        this.btnGet.onClick.AddListener(() => {
            this.OnclickAction(this.id);
        });
       */
    }
}
