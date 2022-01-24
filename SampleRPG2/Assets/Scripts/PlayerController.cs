using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 1.5f;
    private Coroutine coroutine;

    private Animator animator;

    public void Move(Vector3 pos)
    {
        if(this.coroutine != null)
        {
            StopCoroutine(this.coroutine);
        }
        this.coroutine = StartCoroutine(this.MoveCorutine(pos));
    }

    private IEnumerator MoveCorutine(Vector3 pos)
    {
        this.animator.SetTrigger("MoveTrigger");
        this.transform.LookAt(pos);
        while (true)
        {

            var dis = Vector3.Distance(this.transform.position, pos);
            if (dis <= 0.1f)
            {
                break;
            }

            this.transform.Translate(Vector3.forward * this.speed * Time.deltaTime);

            yield return null;
        }
        this.animator.ResetTrigger("MoveTrigger");
        this.animator.SetTrigger("IdleTrigger");
    }
    // Start is called before the first frame update
    void Start()
    {
        this.animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
