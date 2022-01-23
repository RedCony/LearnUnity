using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject playerBulletPrefab;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            var dir = Vector2.left * this.speed * Time.deltaTime;
            this.transform.Translate(dir.x, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            var dir = Vector2.right * this.speed * Time.deltaTime;
            this.transform.Translate(dir.x , 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bulletGo = Instantiate<GameObject>(this.playerBulletPrefab);
            bulletGo.transform.position = this.firePoint.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy") || collision.tag.Equals("EnemyABullet"))
        {
            Destroy(this.gameObject);
        }
    }
}
