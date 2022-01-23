using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
    public Button btnGo;
    public Button btnStop;
    public Image hpGauge;
    public Text goldcoinText;
    public Player player;
    private int coinAmount;
    // Start is called before the first frame update
    void Start()
    {
        this.UpdateCoinAmountText();

        player.OnGetCoin = (amount) => {
            this.coinAmount += amount;
            this.UpdateCoinAmountText();
        };

        player.OnHit = () =>
        {
            var per = this.player.GetHp() / this.player.GetMaxHp();
            this.hpGauge.fillAmount = per;  
        };

        this.btnGo.onClick.AddListener(() => {
            player.MoveStart();
        });
        this.btnStop.onClick.AddListener(() => {
            player.MoveStop();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateCoinAmountText()
    {
        this.goldcoinText.text = this.coinAmount.ToString();
    }
}
