using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHome : MonoBehaviour
{
    [Range(0, 1.0f)]
    public float hpFillAmount;
    [Range(0, 1.0f)]
    public float expFillAmount;

    public Button btnSquare;
    public Button btnFacebook;

    public Slider hpSlider;
    public Slider expSlider;

    public Button btnItems;
    public Button btnShop;
    public Button btnMessages;
    public Button btnMission;
    public Button btnRanking;
    public Button btnSettings;

    public Button btnBudgetLife;
    public Button btnBudgetGold;
    public Button btnBudgetDiamond;
    public Button btnFriends;


    enum eMenuType
    {
        btnitems,btnShop,btnMessages,btnMission,btnRanking,btnSettings
    }
    void Start()
    {
        this.btnSquare.onClick.AddListener(() => {
            Debug.Log("click");
        });
        this.btnFacebook.onClick.AddListener(() => {
            Debug.Log("facebook");
        });
        this.btnItems.onClick.AddListener(() => {
            Debug.Log("item");
        });
        this.btnShop.onClick.AddListener(() => {
            Debug.Log("shop");
        });
        this.btnMessages.onClick.AddListener(() => {
            Debug.Log("messages");
        });
        this.btnMission.onClick.AddListener(() => {
            Debug.Log("mission");
        });
        this.btnRanking.onClick.AddListener(() => {
            Debug.Log("ranking");
        });
        this.btnSettings.onClick.AddListener(() => {
            Debug.Log("settings");
        });

        this.btnBudgetLife.onClick.AddListener(() => {
            Debug.Log("heart");
        });
        this.btnBudgetGold.onClick.AddListener(() => {
            Debug.Log("gold");
        });
        this.btnBudgetDiamond.onClick.AddListener(() => {
            Debug.Log("diamond");
        });
        this.btnFriends.onClick.AddListener(() => {
            Debug.Log("friends");
        });







    }

    // Update is called once per frame
    void Update()
    {
        this.hpSlider.value = this.hpFillAmount;
        this.expSlider.value = this.expFillAmount;
    }
}
