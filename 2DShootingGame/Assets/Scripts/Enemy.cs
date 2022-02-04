using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public float speed;
    public int health;
    public int enemyScore;
   

    public Sprite[] sprites;

    public float maxShotDelay;
    public float curShoDelay;


    public GameObject enemybulletPrefabA;
    public GameObject enemybulletPrefabB;
    public GameObject player;

    SpriteRenderer spriteRenderer;
    //Rigidbody2D rigidbody;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    void OnHit(int dmg)
    {
        health -= dmg;
        spriteRenderer.sprite = sprites[1];
        Invoke("ReturnSprite", 0.1f);

        if (health <= 0)
        {
            Player playerLogic = player.GetComponent<Player>();
            playerLogic.score += enemyScore;
            Destroy(gameObject);
        }
    }

    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }
    void Update()
    {
        Fire();
        Reload();
    }
    void Fire()
    {
        if (curShoDelay < maxShotDelay) { return; }

        if (enemyName == "S")
        {
            GameObject bulletGo = Instantiate(enemybulletPrefabA, transform.position, transform.rotation);
            Rigidbody2D rigidbody2D = bulletGo.GetComponent<Rigidbody2D>();

            Vector3 dirVec = player.transform.position - transform.position;
            rigidbody2D.AddForce(dirVec.normalized *3, ForceMode2D.Impulse);
        }
        else if (enemyName == "L")
        {
            GameObject bulletGor = Instantiate(enemybulletPrefabB, transform.position + Vector3.right * 0.3f, transform.rotation);
            GameObject bulletGol = Instantiate(enemybulletPrefabB, transform.position + Vector3.left * 0.3f, transform.rotation);

            Rigidbody2D rigidbody2Dr = bulletGor.GetComponent<Rigidbody2D>();
            Rigidbody2D rigidbody2Dl = bulletGol.GetComponent<Rigidbody2D>();

            Vector3 dirVecr = player.transform.position - (transform.position + Vector3.right * 0.3f);
            Vector3 dirVecl = player.transform.position - (transform.position + Vector3.left * 0.3f);

            rigidbody2Dr.AddForce(dirVecr.normalized * 4, ForceMode2D.Impulse);
            rigidbody2Dl.AddForce(dirVecl.normalized * 4, ForceMode2D.Impulse);
        }
        curShoDelay = 0;
    }

    void Reload()
    {
        curShoDelay += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBullet") { Destroy(gameObject); }

        else if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit(bullet.dmg);
            Destroy(collision.gameObject);
        }
    }

}
