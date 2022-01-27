using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MasterMain : MonoBehaviour
{
    public Player player;
    //public Enemy enemy; //프리팹으로 만들어서 랜덤 생성 하기 위함
    public Button btnAttack;
    public GameObject fxPrefab;
    public GameObject enemyPrefab;

    private List<GameObject> enemys = new List<GameObject>();

    private Enemy targetEnemy;

    void Start()
    {
        this.CreateEnemys();
        /*
        this.enemy.OnDieAction = () => {
            this.player.SetTarget(null);
        };
        */ //프리팹 변화로 인해서 사용 못함 프리팹 전에 사용함

        this.player.OnAttackComplete = (completeType) =>
        {
            this.OrderPlayerAttack();
        };

        this.player.OnAttackImpact = (impactType) =>{
              switch (impactType)
              {
                  case Player.eAttackType.Attack01:
                    {
                        CreateFx();
                        //this.enemy.Hit(); //4단계 에서 필요함
                    }
                      break;
                  case Player.eAttackType.Attack02:
                    {
                        CreateFx();
                        //this.enemy.Hit();//4단계 에서 필요함
                    }
                      break;
            }
  
          };
        this.btnAttack.onClick.AddListener(() => {
            //this.player.Attack();//4단계에서 필요함
            // this.player.Attack(this.enemy);//5단계에서 사용함
            //list에 있는 enemy 찾기
            this.OrderPlayerAttack();
        });
    }

    private void OrderPlayerAttack()
    {
        var target = this.SearchTarget();
        if (target == null)
        {
            this.player.Idle(); //탐지할 적이 없을때를 위함 것
        }
        else
        {
            this.targetEnemy = target.GetComponent<Enemy>();
            this.player.Attack(this.targetEnemy);
        }
        
    }
    private GameObject SearchTarget()
    {
        float max = 1000f;
        GameObject target = null;
        
        foreach (var go in enemys)
        {
            var dis = Vector3.Distance(go.transform.position, this.transform.position);
            if (dis < max)
            {
                max = dis;
                target = go;
            }
            /*
            if (!go.GetComponent<Enemy>().IsDie())
            {
               
            }
            */ // 불 함수 보다는 리스트에서 제거 하는것이 낫다.
           
        }
        return target;
    }
    private void CreateEnemys()
    {
        for(int i = 0; i < 3; i++)
        {
            var enemyGo = Instantiate(this.enemyPrefab);
            var randX = Random.Range(-5, 5);
            var randZ = Random.Range(-5, 5);
            var initPos = new Vector3(randX, 0, randZ);
            enemyGo.transform.position = initPos;
            enemyGo.GetComponent<Enemy>().OnDieAction = () => 
            {
                this.enemys.Remove(enemyGo);
            };
            this.enemys.Add(enemyGo);
        }
    }

    private void CreateFx()
    {
        var fxGo = Instantiate(this.fxPrefab);
        fxGo.transform.position = this.player.transform.position;
    }
    
    void Update()
    {
        
    }
}
