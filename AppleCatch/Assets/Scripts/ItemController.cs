using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float speed = -0.03f;
    void Start()
    {
        
    }

    
    void Update()
    {
        this.transform.Translate(0, this.speed, 0);
        if(transform.position.y < -1.0f)
        {
            Destroy(gameObject);
        }
    }
}
