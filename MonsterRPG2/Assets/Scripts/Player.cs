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

    public float attackDelay = 0.5f;
    public float impactOffset = 0.5f;

    public GameObject model;

    public UnityAction<eAttackType> OnAttackImpact; 
    // Start is called before the first frame update
    void Start()
    {
        this.animator = this.model.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        if(this.coroutine != null)
        {
            StopCoroutine(this.coroutine);
        }
        this.coroutine = StartCoroutine(this.AttackRoutine());
    }

    public IEnumerator AttackRoutine()
    {
        while (true)
        {
            this.animator.Play("Attack01", -1, 0);
            yield return null;
            var lenhth = this.GetClipLength();
            
            var impactTime = 0.533f - impactOffset;
            yield return new WaitForSeconds(impactTime);
            this.OnAttackImpact(eAttackType.Attack01);
            yield return new WaitForSeconds(lenhth-impactTime);

            this.animator.Play("Attack02", -1, 0);
            yield return null;
             lenhth = this.GetClipLength();
             impactTime = 0.399f - impactOffset;
            yield return new WaitForSeconds(impactTime);
            this.OnAttackImpact(eAttackType.Attack02);
            yield return new WaitForSeconds(lenhth - impactTime);

            this.animator.Play("Idle_Battle", -1, 0);
            yield return new WaitForSeconds(this.attackDelay);
        }
       
    }

    private float GetClipLength()
    {
        AnimatorClipInfo[] clipInfos = this.animator.GetCurrentAnimatorClipInfo(0);
        AnimationClip clip = clipInfos[0].clip;
        return clip.length;
    }
}
