using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Animator animator;

    public int id;

    private Vector3 pos = new Vector3(0, 0, 2);
   
    // Start is called before the first frame update
    void Start()
    {
        //this.animator = GameObject.FindGameObjectWithTag("");
        //this.id = 1;
        //animator.Play("Die");
        //this.StartCoroutine(this.MoveRoutin());
    }

    
    public void Attack01()
    {
        animator.Play("Attack01");
        this.StartCoroutine(this.WaitForIDle(0.833f));
    }

    public void Die()
    {
        animator.Play("Die");
        this.StartCoroutine(WaitForDieAnimation(1.333f));
    }

    IEnumerator DoubleAttack()
    {

        yield return null;
    }

    IEnumerator WaitForIDle(float length )
    {
        yield return new WaitForSeconds(length);
        animator.Play("IdleNormal");
    }

    IEnumerator WaitForDieAnimation(float length)
    {
        yield return new WaitForSeconds(length);

        print("die animation complete!");
        Destroy(this.gameObject);
    }
    IEnumerator MoveRoutin()
    {
        while (true)
        {
            this.transform.Translate(Vector3.forward * 1.0f * Time.deltaTime);

            var dis = Vector3.Distance(this.pos, this.transform.position);

            if (dis < 0.1f)
            {
                break;
            }
            yield return null;
        }
        print("Move complete!");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
