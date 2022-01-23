using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour
{
    public float speed = 2.0f;
    private float delta;
    public GameObject enemyABulletPrefab;
    public Transform firepoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > 1.0f)
        {
            this.delta = 0;

            var enemyBulletgo = Instantiate<GameObject>(this.enemyABulletPrefab);
            enemyBulletgo.transform.position = this.firepoint.position;
        }

        var dir = Vector2.down * this.speed * Time.deltaTime;
        this.transform.Translate(dir);
        if(this.transform.position.y <= -5.2f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("PlayerBullet"))
        {
            Destroy(this.gameObject);
        }
    }
}
