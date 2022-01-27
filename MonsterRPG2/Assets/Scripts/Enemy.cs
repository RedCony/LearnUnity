using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    private Coroutine coroutine;

    private float hp;

    public UnityAction OnDieAction;

    /*
    public float Hp
    {
        get { return this.hp; }
        set
        {
            if (this.hp <= 0) return;
            this.hp -= value;

            this.hp = Mathf.Clamp(this.hp, 0, this.maxHp);
        }
    }
    */
    public float maxHp;

    public GameObject model;
    
    void Start()
    {
        this.animator = this.model.GetComponent<Animator>();
        this.hp = maxHp;
    }

    
    void Update()
    {
        
    }
    public bool IsDie()
    {
        return this.hp <= 0;
    }

    public void Hit(float damage) //5단계에 필요한 데미지 인수 추가 함 ,hp if,else문 추가 4단계에선 else문의 문장만 필요
    {
        this.hp -= damage;

        if (this.hp <= 0)
        {
            this.hp = 0;
            //die 호출
            this.Die();
        }
        else
        {
            if (this.coroutine != null)
            {
                StopCoroutine(this.coroutine);
            }
            this.coroutine = StartCoroutine(this.HitRoutine());
        }

       
    }

    private IEnumerator HitRoutine()
    {
        this.animator.Play("GetHit", -1, 0);
        yield return new WaitForSeconds(0.833f);
        this.animator.Play("IdleBattle", -1, 0);
    }

    private void Die()
    {
        this.OnDieAction();

        this.animator.Play("Die", -1, 0);
        this.StartCoroutine(this.WaitForSec(1.33f, () => 
        {
            Destroy(this.gameObject);
        }));
    }

    private IEnumerator WaitForSec(float sec,System.Action callbak)
    {
        yield return new WaitForSeconds(sec);
        callbak();
    }
}
