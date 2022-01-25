using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HeroMain : MonoBehaviour
{
    public Hero hero;
    public Slime slime;

    public Button btnAttack;


    private float distance;

    //RaycastHit hit;



   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            btnAttack.onClick.AddListener(() => { hero.Move(); });
            hero.OnHit = () => { hero.AutoAttack(); };
            hero.OnImpact = () => { slime.GetHit(); };
        }


        /*
        if (Input.GetMouseButtonDown(0))
        {
            btnAttack.onClick.AddListener(() => { hero.Attack02();});
            hero.OnImpact = () => { slime.GetHit(); };
        }
        //slime.GetHit();

        /*
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.red, 2f);

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.collider.tag.Equals("Player"))
                {
                    var hero1 = hit.collider.gameObject.GetComponent<Hero>();
                    //hero1.Attack01();
                    btnAttack.onClick.AddListener(() => { hero.Attack01(); });
                   

                }
            }
        }
       */
    }
    public void CalcDistance()
    {
        this.distance = Vector3.Distance(this.hero.transform.position, this.slime.transform.position);
    }
}
