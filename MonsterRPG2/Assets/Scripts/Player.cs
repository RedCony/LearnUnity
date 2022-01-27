using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;


public class Player : MonoBehaviour
{
    public enum eAttackType { None, Attack01, Attack02 }

    private Animator animator;
    private Coroutine coroutine;
    private Enemy tartget; //5�ܰ� hp �� damage ���� �ؼ� �߰�

    private float hp;
    private const float GIZMO_DISK_THICKNESS = 1.0f;
    

    public float maxHp;
    public float damage;
    public float attackRange;

    public float attackDelay = 0.5f;
    public float impactOffset = 0.5f;

    public GameObject model;
    public GameObject fxPrefab;
    public GameObject fxPivot;

    public UnityAction<eAttackType> OnAttackImpact;
    public UnityAction<eAttackType> OnAttackComplete;

    private UnityAction OnMoveComplete;



    
    void Start()
    {
        this.animator = this.model.GetComponent<Animator>();
        this.hp = maxHp;
        this.OnMoveComplete = () => {
            this.Attack(this.tartget);
        };
    }

    
    void Update()
    {
        
    }

    public void Attack(Enemy target)
    {
        this.tartget = target; //5�ܰ� hp �� damage ���� �ؼ� �߰� 
        if(this.coroutine != null)
        {
            StopCoroutine(this.coroutine);
        }
        this.coroutine = StartCoroutine(this.AttackRoutine());
    }

    /*
    public IEnumerator AttackRoutine()
    {
        while (true)
        {
            this.animator.Play("Attack01", -1, 0);
            yield return null;
            var lenhth = this.GetClipLength();
            
            var impactTime = 0.533f - impactOffset;
            yield return new WaitForSeconds(impactTime);
            //Ÿ�ٿ��� ���ظ� �����ϴ�.
            this.tartget.Hit(this.damage);
            //�̺�Ʈ �߻�

            this.OnAttackImpact(eAttackType.Attack01);
            yield return new WaitForSeconds(lenhth-impactTime);

            this.animator.Play("Attack02", -1, 0);
            yield return null;
             lenhth = this.GetClipLength();
             impactTime = 0.399f - impactOffset;
            yield return new WaitForSeconds(impactTime);
            //Ÿ�ٿ��� ���ظ� �����ϴ�.
            this.tartget.Hit(this.damage);
            //�̺�Ʈ �߻�

            this.OnAttackImpact(eAttackType.Attack02);
            yield return new WaitForSeconds(lenhth - impactTime);

            this.animator.Play("Idle_Battle", -1, 0);
            yield return new WaitForSeconds(this.attackDelay);
        }
       
    }
    */  //4�ܰ� ���� ��ƾ
    public bool CanAttack()
    {
        var distance = Vector3.Distance(this.tartget.transform.position, this.transform.position);
        return this.attackRange >= distance;
    }

    public void Idle()
    {
        this.animator.Play("Idle_Battle", -1, 0);
    }
    public void SetTarget(Enemy target)
    {
        this.tartget = target;
    }
    private IEnumerator MoveToTarget()
    {
        this.transform.LookAt(this.tartget.transform);
        this.animator.Play("RunForwardBattle", -1, 0);
        while (true)
        {
            this.transform.Translate(Vector3.forward * 1.0f * Time.deltaTime);
           
            if (CanAttack())
            {
                this.Idle();
                this.OnMoveComplete();
                yield break;
            }
            yield return null;
        }
    }
    private bool Hastarget()
    {
        return this.tartget != null;
    }
    private IEnumerator AttackRoutine()
    {
        while (true)
        {
            //Ÿ���� hp�� 0�̸� Ÿ���� �������� ������ hastarget�� null�� �ƴϿ��� �Ѵ�.
            if (Hastarget())
            {
                //���� ���� ����
                if (this.CanAttack())
                {
                    yield return StartCoroutine(this.Attack01Routine());
                }
                else
                {
                    //���÷����� �� �������� �̵��Ѵ� �̵� ����
                    this.coroutine = StartCoroutine(this.MoveToTarget());
                    yield break;
                }
               
            }
            else
            {
                this.Idle();
                yield break;
            }
            //Ÿ���� hp�� 0�̸� Ÿ���� �������� ������ hastarget�� null�� �ƴϿ��� �Ѵ�.
            if (Hastarget())
            {
                //���� ���� ����
                yield return StartCoroutine(this.Attack02Routine());
            }

            else
            {
                this.Idle();
                yield break;
            }

        }
    }
    private IEnumerator Attack01Routine()
    {
        this.animator.Play("Attack01", -1, 0);
        yield return null;
        var lenhth = this.GetClipLength();

        var impactTime = 0.533f - impactOffset;
        yield return new WaitForSeconds(impactTime);
        //Ÿ�ٿ��� ���ظ� �����ϴ�.
        this.tartget.Hit(this.damage);
        //�̺�Ʈ �߻�

        this.OnAttackImpact(eAttackType.Attack01);
        yield return new WaitForSeconds(lenhth - impactTime);
        
        this.Idle();
        yield return new WaitForSeconds(this.attackDelay);
        this.OnAttackComplete(eAttackType.Attack01);
    }

    private IEnumerator Attack02Routine()
    {
        this.animator.Play("Attack02", -1, 0);
        yield return null;
        var lenhth = this.GetClipLength();
        var impactTime = 0.399f - impactOffset;
        yield return new WaitForSeconds(impactTime);
        //Ÿ�ٿ��� ���ظ� �����ϴ�.
        this.tartget.Hit(this.damage);
        //�̺�Ʈ �߻�

        this.OnAttackImpact(eAttackType.Attack02);
        yield return new WaitForSeconds(lenhth - impactTime);
       
        this.Idle();
        yield return new WaitForSeconds(this.attackDelay);
        this.OnAttackComplete(eAttackType.Attack02);
    }

    private float GetClipLength()
    {
        AnimatorClipInfo[] clipInfos = this.animator.GetCurrentAnimatorClipInfo(0);
        AnimationClip clip = clipInfos[0].clip;
        return clip.length;
    }

    private void OnDrawGizmos() //Ÿ�� ���� Ȯ�� �ϴ� �����
    {
        Gizmos.color = Color.red;
        float corners = 11;
        //float size = 10;
        Vector3 origin = transform.position;
        Vector3 startRotation = transform.right * this.attackRange;
        Vector3 lastPosition = origin + startRotation;
        float angle = 0;
        while (angle <= 360)
        {
            angle += 360 / corners;
            Vector3 nextPosition = origin + (Quaternion.Euler(0, angle,0 ) * startRotation);
            Gizmos.DrawLine(lastPosition, nextPosition);
            Gizmos.DrawSphere(nextPosition, 0.1f);

            lastPosition = nextPosition;
        }
         
    }
}
