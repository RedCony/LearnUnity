using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class UIInventory : MonoBehaviour
{
    public UIItem[] uiItems;
    public SpriteAtlas atlas;

    ItemInfo uiItemInfo;

    public void Init(ItemInfo[] itemInfos, Dictionary<int, ItemData> dic)
    {
        for (int i = 0; i < uiItems.Length; i++)
        {
            UIItem uiItem = uiItems[i];

            if (i > itemInfos.Length - 1)
            {
                uiItemInfo = null;
                uiItem.Init(null, uiItemInfo);
            }
            else
            {
                uiItemInfo = itemInfos[i];
                ItemData itemData = dic[uiItemInfo.id];
                //화면에 디스플레이 
                Sprite sp = atlas.GetSprite(itemData.spriteName);
                uiItem.Init(sp, uiItemInfo);
            }
        }
    }

}
