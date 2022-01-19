using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    public PlayerController player;
    public UIGame uIGame;
    public ArrowGenerator arrowGenerator;
    public Transform leftBoundary;
    public Transform rightBoundary;
    public static bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init()
    {
        this.player.Init(10, this.leftBoundary, this.rightBoundary, new Vector3(0, -3.6f, 0));

        this.player.OnHit = (fillAmount) =>
        {
            this.uIGame.UPdateHpGauge(fillAmount);
        };

        this.player.OnDie = () =>
        {
            if (!GameMain.isGameOver)
            {
                GameMain.isGameOver = true;
                Debug.Log("player is dead");

                this.uIGame.GameOver();
            }
        };
    }
}
