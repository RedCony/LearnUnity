using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager 
{
    private static InfoManager instance;
    public GameInfo gameInfo;

    private InfoManager()
    {
    }

    public static InfoManager GetInstance()
    {
        if (InfoManager.instance == null) InfoManager.instance = new InfoManager();
        return InfoManager.instance;
    }
}
