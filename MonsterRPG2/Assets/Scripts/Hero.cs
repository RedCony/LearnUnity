using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;


public class Hero : MonoBehaviour
{
    Animator animator;

    Coroutine coroutine;

    public float attackPow;
    public float speed;
   

    private float radius;
    private float distance;

    public UnityAction OnImpact;
    public UnityAction OnHit;

    public Slime slime;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.speed = 2f;
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
        this.animator.Play("WaldForwardBattle", -1, 0);
        this.transform.LookAt(slime.transform.position);
        while (true)
        {
            var dis = Vector3.Distance(this.transform.position, slime.transform.position);
            if(dis <= 0.1f)
            {
                break;
            }
            this.transform.Translate(Vector3.forward * this.speed * Time.deltaTime);
        }
        yield return null;
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
        yield return null;
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
        this.distance = Vector3.Distance(this.transform.position, this.slime.transform.position);
    }
}
