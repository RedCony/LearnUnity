using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class AtlasTest : MonoBehaviour
{
    public Image image;
    public SpriteAtlas spriteAtlas;
    // Start is called before the first frame update
    void Start()
    {
        Sprite sp = spriteAtlas.GetSprite("Icon_ItemIcon_Gem");
        image.sprite = sp;
        image.SetNativeSize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
