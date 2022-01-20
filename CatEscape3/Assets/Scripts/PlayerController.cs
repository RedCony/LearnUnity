using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float speed=1;
    public float radius = 1.0f;
    public Transform leftBoundaryPoint;
    public Transform rightBoundaryPoint;
    public System.Action<float> OnHit;
    public System.Action OnDie;
    public float maxHp;

    public float hp;
    public float HP
    {
        get { return this.hp; }
        set { hp = Mathf.Clamp(value, 0, maxHp); }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        this.maxHp = 10;
        
        this.hp = this.maxHp;
    }
    public void Init(float maxHp, Transform leftBoundary, Transform rightBoundary, Vector3 initPos)
    {
        this.maxHp = maxHp;
        this.hp = this.maxHp;
        this.leftBoundaryPoint = leftBoundary;
        this.rightBoundaryPoint = rightBoundary;
        this.transform.position = initPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMain.isGameOver) return;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.Translate(Vector2.left * this.speed);
            CheckBoundary();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.Translate(Vector2.right * this.speed);
            CheckBoundary();
        }
        
    }
    private void CheckBoundary()
    {
        var pos = this.transform.position;
        pos.x = Mathf.Clamp(this.transform.position.x, this.leftBoundaryPoint.position.x, this.rightBoundaryPoint.position.x);
        this.transform.position = pos;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.radius);
    }

    public void Hit(int damage)
    {
        this.hp -= damage;

        if(hp <= 0)
        {
            this.hp = 0;
        }
        float decresingHP = this.hp / this.maxHp;
        this.OnHit(decresingHP);
        if (hp <= 0)
        {
            this.OnDie();
        }
    }
    public float GetPercentageByHp()
    {
        return this.hp / this.maxHp;
    } 
}
