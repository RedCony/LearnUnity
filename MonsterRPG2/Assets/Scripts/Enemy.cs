using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    private Coroutine coroutine;
    
    public GameObject model;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = this.model.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit()
    {
        if (this.coroutine != null)
        {
            StopCoroutine(this.coroutine);
        }
        this.coroutine = StartCoroutine(this.HitRoutine());
    }

    private IEnumerator HitRoutine()
    {
        this.animator.Play("GetHit", -1, 0);
        yield return new WaitForSeconds(0.833f);
        this.animator.Play("IdleBattle", -1, 0);
    }
}
