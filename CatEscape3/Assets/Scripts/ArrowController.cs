using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Init(float speed,Vector3 initPos)
    {
        this.speed = speed;
        this.transform.position = initPos;
    }

    // Update is called once per frame
    void Update()
    {
        var dir = Vector2.down;
        var movement = dir * this.speed * Time.deltaTime;

        this.transform.Translate(movement);

        if (this.transform.position.y <= -5f)
        {
            Destroy(this.gameObject);
        }
    }
}
