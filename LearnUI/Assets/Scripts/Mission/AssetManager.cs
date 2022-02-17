using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class AssetManager 
{
    public enum eAtlas {MissionAtlas = 10000}

    private static AssetManager instance;
    private Dictionary<eAtlas, SpriteAtlas> dicAtlases;

    private AssetManager()
    {
        this.dicAtlases = new Dictionary<eAtlas, SpriteAtlas>();
    }

    public static AssetManager GetInstance()
    {
        if (AssetManager.instance == null) { AssetManager.instance = new AssetManager(); }
        return AssetManager.instance;
    }
    public void LoadAtlas(eAtlas eAtlas,string path) 
    {
        SpriteAtlas atlas = Resources.Load<SpriteAtlas>(path);
        this.dicAtlases.Add(eAtlas, atlas);
        Debug.LogFormat("Loaded mission_atlas : {0}", this.dicAtlases.Count);
    }

    public SpriteAtlas GetAtlas(eAtlas eAtlas)
    {
        return this.dicAtlases[eAtlas];
    }
}
