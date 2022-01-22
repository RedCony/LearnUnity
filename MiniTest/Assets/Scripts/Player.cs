using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject flagGo;
    private bool canMove = false;
    public Text distanceText;
    private float distance;
    public float hp;
    public float maxHp;
    public float radius = 1.0f;
    public float trapRadius = 1.0f;
    public GameObject trapGo;
    private bool canHit = true;
    public UnityAction OnHit;
    public UnityAction<int> OnGetCoin;

    private List<GoldCoin> coins = new List<GoldCoin>();
    // Start is called before the first frame update
    void Start()
    {
        this.maxHp = 10;
        this.hp = this.maxHp;

        //this.flagGo = GameObject.Find("flag");
        //this.trapGo = GameObject.Find("trap2");

        //this.distanceText = GameObject.Find("distanceText").GetComponent<Text>();
        this.CalcDistance();
        this.UpdateDistanceText();

        this.coins = GameObject.FindObjectsOfType<GoldCoin>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.canMove)
        {
            this.CalcDistance();
            this.UpdateDistanceText();

            var dis = Vector2.Distance(this.trapGo.transform.position, this.transform.position);
            if (dis < this.radius + this.trapRadius)
            {
                if (this.canHit)
                {
                    Debug.Log("¾Æ¾æ!");
                    this.hp -= 1;
                    this.canHit = false;
                    this.OnHit();
                }
            }

            for (int i = 0; i < this.coins.Count; i++)
            {
                GoldCoin coin = this.coins[i];
                var dis2 = Vector2.Distance(this.transform.position, coin.transform.position);
                if (dis2 < this.radius + coin.radius)
                {
                    Destroy(coin.gameObject);
                    coins.Remove(coin);

                    this.OnGetCoin(coin.amount);

                }
            }


            if (distance > 0.2)
                this.transform.Translate(Vector2.right * this.speed * Time.deltaTime);
        }
    }

    public float GetMaxHp()
    {
        return this.maxHp;
    }

    public float GetHp()
    {
        return this.hp;
    }

    private void CalcDistance()
    {
        this.distance = Vector2.Distance(this.transform.position, this.flagGo.transform.position);
    }

    private void UpdateDistanceText()
    {
        this.distanceText.text = distance.ToString() + "m";
    }

    public void MoveStart()
    {
        this.canMove = true;
    }

    public void MoveStop()
    {
        this.canMove = false;
    }
   
}
