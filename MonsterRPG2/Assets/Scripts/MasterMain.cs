using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MasterMain : MonoBehaviour
{
    public Player player;
    //public Enemy enemy; //���������� ���� ���� ���� �ϱ� ����
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
        */ //������ ��ȭ�� ���ؼ� ��� ���� ������ ���� �����

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
                        //this.enemy.Hit(); //4�ܰ� ���� �ʿ���
                    }
                      break;
                  case Player.eAttackType.Attack02:
                    {
                        CreateFx();
                        //this.enemy.Hit();//4�ܰ� ���� �ʿ���
                    }
                      break;
            }
  
          };
        this.btnAttack.onClick.AddListener(() => {
            //this.player.Attack();//4�ܰ迡�� �ʿ���
            // this.player.Attack(this.enemy);//5�ܰ迡�� �����
            //list�� �ִ� enemy ã��
            this.OrderPlayerAttack();
        });
    }

    private void OrderPlayerAttack()
    {
        var target = this.SearchTarget();
        if (target == null)
        {
            this.player.Idle(); //Ž���� ���� �������� ���� ��
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
            */ // �� �Լ� ���ٴ� ����Ʈ���� ���� �ϴ°��� ����.
           
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
