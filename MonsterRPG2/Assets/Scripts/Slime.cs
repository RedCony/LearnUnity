using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;


public class Slime : MonoBehaviour
{
    Animator animator;

    Coroutine coroutine;

    public float hp { get; set; }
    public float speed { get; set; }
    public float maxHp;
    public float radius { get; set; }

    //public UnityAction OnHit;
    public UnityAction OnDie;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.maxHp = 10.0f;
        this.hp = this.maxHp;
        this.radius = 0.5f;
    }

    public void GetDie()
    {
        if (this.coroutine != null)
        {
            StopCoroutine(this.coroutine);
        }
        this.StartCoroutine(this.GetDieRoutine());
    }

    IEnumerator GetDieRoutine()
    {
        
        this.animator.Play("Die", -1, 0);
        yield return new WaitForSeconds(0.833f);
        this.animator.Play("IdleNormal", -1, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetHit()
    {
        if (this.coroutine != null)
        {
            StopCoroutine(this.coroutine);
        }
        this.StartCoroutine(this.GetHitRoutine());
    }

    IEnumerator GetHitRoutine()
    {
        
        this.animator.Play("GetHit", -1, 0);
        yield return new WaitForSeconds(0.833f);
        this.animator.Play("IdleNormal", -1, 0);
    }
}
