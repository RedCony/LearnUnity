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

    // Update is called once per frame
    void Update()
    {
        var dir = Vector2.down;

        var movement = dir * this.speed * Time.deltaTime;

        this.transform.Translate(movement);

        if(this.transform.position.y <= -5.0f)
        {
            Destroy(this.gameObject);
        }
        
    }
}
