using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float speed=1.5f;

    Rigidbody rigidbody;
    Animator animator;

    private Vector3 tpos;
    private Vector3 startPos;
    private float totalDistance;
    private bool isMove = false;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isMove)
        {
            
            this.transform.Translate(Vector3.forward * this.speed * Time.deltaTime);
            var distance = Vector3.Distance(this.transform.position,this.tpos);
            if(distance <= 0.2f)
            {
                this.animator.ResetTrigger("movetrigger");
                this.animator.SetTrigger("idletrigger");
                this.isMove = false;
            }
        }
    }

    public void Move(Vector3 tpos)
    {
        this.animator.SetTrigger("movetrigger");
        //this.startPos = this.transform.position;
        this.tpos = tpos;
        this.transform.LookAt(tpos);
        this.isMove = true;
    }
}
