using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;


public class Hero : MonoBehaviour
{
    Animator animator;

    Coroutine coroutine;

    Rigidbody rigidbody;

    GameObject target;

    [Header("추격속도")]
    [SerializeField] [Range(1f, 4f)] float moveSpeed = 2f;
    [Header("근접 거리")]
    [SerializeField] [Range(0f, 7f)] float contactDistance = 1f;

    public UnityAction OnImpact;
    public UnityAction OnHit;
   

    public float attackPow;
    public float attackRange;
    public float speed;
   

    private float radius;
    private float distance;
    private Vector3 targetTran;
    private Vector3 heroTran;

  
    private bool canHit = true;
    private bool follow = false;

    


    //public Slime slime;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.speed = 1f;
        this.rigidbody = GetComponent<Rigidbody>();
        this.target = GameObject.FindGameObjectWithTag("Monster");
        this.targetTran = target.transform.position;
        this.heroTran = this.transform.position;

    }

   

    private void OnTriggerEnter(Collider other)
    {
        follow = true;
    }
    private void OnTriggerExit(Collider other)
    {
        follow = false;
    }

    public void Move()
    {
        if (this.coroutine != null)
        {
            StopCoroutine(this.coroutine);
        }
        this.StartCoroutine(this.MoveRoutine());
    }

    IEnumerator MoveRoutine()
    {
            this.animator.Play("WalkForwardBattle", -1, 0);
            this.transform.LookAt(targetTran);
            while (true)
            {
                var dis = Vector3.Distance(heroTran, targetTran);
                if (dis <= 0.1f)
                {
                        break;
                }
                this.transform.Translate(Vector3.forward * this.speed * Time.deltaTime);
                yield return null;
            }
        this.animator.Play("Idle_Battle", -1, 0);
    }

    public void AutoAttack()
    {
        if (this.coroutine != null)
        {
            StopCoroutine(this.coroutine);
        }
        this.StartCoroutine(this.AutoAttackRoutine());
    }

    IEnumerator AutoAttackRoutine()
    {
        while (true)
        {
            this.animator.Play("Attack01", -1, 0);
            yield return new WaitForSeconds(0.4998f - 0.15f);
            this.OnImpact();
            yield return new WaitForSeconds(0.833f - (0.4998f + 0.15f));
            animator.Play("Idle_Battle", -1, 0);
            this.OnHit();
        }
        
      
    }
    public void Attack01()
    {
        if(this.coroutine != null)
        {
            StopCoroutine(this.coroutine);
        }
        this.StartCoroutine(this.AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        this.animator.Play("Attack01", -1, 0);
        yield return new WaitForSeconds(0.4998f-0.15f);
        this.OnImpact();
        yield return new WaitForSeconds(0.833f - (0.4998f + 0.15f));
        animator.Play("Idle_Battle", -1, 0);
    }
    public void Attack02()
    {
        if (this.coroutine != null)
        {
            StopCoroutine(this.coroutine);
        }
        this.StartCoroutine(this.Attack02Routine());
    }

    IEnumerator Attack02Routine()
    {
        this.animator.Play("Attack01", -1, 0);
        yield return new WaitForSeconds(0.4998f - 0.15f);
        this.OnImpact();
        yield return new WaitForSeconds(0.833f - (0.4998f + 0.15f));
        animator.Play("Idle_Battle", -1, 0);
        Debug.Log("1번 공격");

        yield return new WaitForSeconds(2f);
        this.animator.Play("Attack01", -1, 0);
        yield return new WaitForSeconds(0.4998f - 0.15f);
        this.OnImpact();
        yield return new WaitForSeconds(0.833f - (0.4998f + 0.15f));
        animator.Play("Idle_Battle", -1, 0);
        Debug.Log("2번 공격");

        yield return new WaitForSeconds(2f);
        this.animator.Play("Attack01", -1, 0);
        yield return new WaitForSeconds(0.4998f - 0.15f);
        this.OnImpact();
        yield return new WaitForSeconds(0.833f - (0.4998f + 0.15f));
        animator.Play("Idle_Battle", -1, 0);
        Debug.Log("3번 공격");

        yield return new WaitForSeconds(2f);
        this.animator.Play("Attack01", -1, 0);
        yield return new WaitForSeconds(0.4998f - 0.15f);
        this.OnImpact();
        yield return new WaitForSeconds(0.833f - (0.4998f + 0.15f));
        animator.Play("Idle_Battle", -1, 0);
        Debug.Log("4번 공격");

    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void CalcDistance()
    {
        this.distance = Vector3.Distance(heroTran,targetTran);
    }
}
