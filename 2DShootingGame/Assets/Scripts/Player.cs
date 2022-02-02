using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchLeft;
    public bool isTouchRight;

    public int life;
    public int score;

    public float speed;
    public float power;
    public float maxShotDelay;
    public float curShoDelay;
   

    public GameObject bulletPrefabA;
    public GameObject bulletPrefabB;

    public GameManager gameManager;

    public bool isHit;

    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Move();
        Fire();
        Reload();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1)) { h = 0; }
        float v = Input.GetAxisRaw("Vertical");
        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1)) { v = 0; }
        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal")) { animator.SetInteger("Input", (int)h); }
    }

    void Fire()
    {
        if (!Input.GetButton("Fire1")) { return; }
        if (curShoDelay < maxShotDelay) { return; }

        switch (power)
        {
            case 1:
                GameObject bulletGo = Instantiate(bulletPrefabA, transform.position, transform.rotation);
                Rigidbody2D rigidbody2D = bulletGo.GetComponent<Rigidbody2D>();
                rigidbody2D.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
            case 2:
                GameObject bulletGor = Instantiate(bulletPrefabA, transform.position+Vector3.right*0.25f, transform.rotation);
                GameObject bulletGol = Instantiate(bulletPrefabA, transform.position+Vector3.left*0.25f, transform.rotation);
                Rigidbody2D rigidbody2Dr = bulletGor.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidbody2Dl = bulletGol.GetComponent<Rigidbody2D>();
                rigidbody2Dr.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidbody2Dl.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
            case 3:
                GameObject bulletGorr = Instantiate(bulletPrefabA, transform.position + Vector3.right * 0.25f, transform.rotation);
                GameObject bulletGob = Instantiate(bulletPrefabB, transform.position, transform.rotation);
                GameObject bulletGoll = Instantiate(bulletPrefabA, transform.position + Vector3.left * 0.25f, transform.rotation);
                Rigidbody2D rigidbody2Drr = bulletGorr.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidbody2Db = bulletGob.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidbody2Dll = bulletGoll.GetComponent<Rigidbody2D>();
                rigidbody2Drr.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidbody2Db.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidbody2Dll.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
        }

        curShoDelay = 0;
    }

    void Reload()
    {
        curShoDelay += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;
            }
        }
        else if (collision.gameObject.tag == "Enemy"|| collision.gameObject.tag == "EnemyBullet")
        {
            if (isHit)
            {
                return;
            }
            isHit = true;
            life--;
            gameManager.UpdateLifeIcon(life);

            if (life == 0)
            {
                gameManager.GameOver();
            }
            else
            {
                gameManager.RespawnPlayer();
            }
            gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "Top":
                isTouchTop = false;
                break;
            case "Bottom":
                isTouchBottom = false;
                break;
            case "Right":
                isTouchRight = false;
                break;
            case "Left":
                isTouchLeft = false;
                break;
        }
    }
}
