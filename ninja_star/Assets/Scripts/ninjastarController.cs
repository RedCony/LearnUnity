using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ninjastarController : MonoBehaviour
{
    Vector2 startpos;
    Vector2 endpos;
    float rotSpeed;
    float speed;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.startpos = Input.mousePosition;
            
            rotSpeed = 10f;
        }
        transform.Rotate(0, 0, rotSpeed , Space.World);
        if (Input.GetMouseButtonUp(0))
        {
            var endpos = Input.mousePosition;
            float swipeLength = endpos.x - this.startpos.x;
            this.speed = swipeLength / 500.0f;

        }
       
        transform.Translate(Vector2.up, Space.World);
    }
}
