using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    Animator animator;

    Coroutine coroutine;

    public float hp;
    public float speed;

    private float maxHp;
    private float radius;
    
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.maxHp = 10.0f;
        this.hp = this.maxHp;
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
