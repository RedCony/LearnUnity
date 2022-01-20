using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed=1;
    public float radius = 1.0f;
    public Transform leftBoundaryPoint;
    public Transform rightBoundaryPoint;
    public System.Action<float> OnHit;
    public System.Action OnDie;
    public float maxHp;

    private float hp;
    public float HP
    {
        get { return this.hp; }
        set { hp = Mathf.Clamp(value, 0, maxHp); }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
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

    public void Hit(float damage)
    {
        HP -= damage;
       
        if(HP <= 0)
        {
            this.HP = 0;
        }
        
        OnHit(GetPercentageByHp());
        if (HP == 0)
        {
            this.OnDie();
        }
    }
    private float GetPercentageByHp()
    {
        return HP / this.maxHp;
    } 
}
