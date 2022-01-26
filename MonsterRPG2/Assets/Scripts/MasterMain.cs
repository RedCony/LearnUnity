using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MasterMain : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public Button btnAttack;
    // Start is called before the first frame update
    void Start()
    {
        this.player.OnAttackImpact = (impactType) =>{
              switch (impactType)
              {
                  case Player.eAttackType.Attack01:
                    {
                        this.enemy.Hit();
                    }
                      break;
                  case Player.eAttackType.Attack02:
                    {
                        this.enemy.Hit();
                    }
                      break;
            }
  
          };
        this.btnAttack.onClick.AddListener(() => {
            this.player.Attack();
        
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
