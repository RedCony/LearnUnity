using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeMain : MonoBehaviour
{
    public UIHome uIHome;
    public UILogin uILogin;
    void Start()
    {
        this.uILogin.btnClose.onClick.AddListener(() => {
            this.uILogin.Close();
        });
        this.uIHome.btnSquare.onClick.AddListener(() => {
            this.uILogin.Open();
        });
        this.uILogin.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
