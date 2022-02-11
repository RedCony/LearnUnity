using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStageLock : MonoBehaviour
{
    public struct UIStageLockParam
    {
        public string stageName;
        public int requiredlevelnum;
        
    }
    public Text stageName;
    public Text requiredlevelnum;
    public Button btnOk;
    public Button btnClose;

    public int Id
    {
        get; private set;
    }

    public void Init(int id,string name ,int num)
    {
        this.Id = id;
        this.stageName.text = name.ToString();
        this.requiredlevelnum.text = num.ToString();


    }

    void Start()
    {
        this.btnOk.onClick.AddListener(() =>
        {
            this.Close();
        });
        this.btnClose.onClick.AddListener(() =>
        {
            this.Close();
        });
    }

    public void Open()
    {
        this.gameObject.SetActive(true);
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }

    public void Open(UIStageLockParam param)
    {
        this.stageName.text = param.stageName;
        this.requiredlevelnum.text = param.requiredlevelnum.ToString();

      

        this.gameObject.SetActive(true);
    }

    void Update()
    {
        
    }
}