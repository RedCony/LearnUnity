using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    private float jumpForce = 680f;
    private float walkForce = 30.0f;
    private float maxWalkSpeed = 2.0f;
    private float walkSpeed = 300f;
    // Start is called before the first frame update
    void Start()
    {
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigidbody2D.AddForce(transform.up * this.jumpForce);
        }

        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        float speedx = Mathf.Abs(this.rigidbody2D.velocity.x);

        if (speedx < this.maxWalkSpeed)
        {
            this.rigidbody2D.AddForce(this.transform.right * key * this.walkForce);
        }
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        this.animator.speed = speedx / 2.0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("°ñ");
    }
}
