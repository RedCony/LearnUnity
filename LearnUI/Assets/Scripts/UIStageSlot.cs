using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStageSlot : MonoBehaviour
{
    public Text stageNum;
    public GameObject stargrid;
    public GameObject starPrefab;

    private int id;

    public void Init(int id,string stagenum)
    {
        this.id = id;
        this.stageNum.text = stageNum.ToString();
    }
}
