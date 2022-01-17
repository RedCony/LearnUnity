using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ninjastarController : MonoBehaviour
{
    Vector2 startpos;
    Vector2 endpos;
    float rotSpeed;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            rotSpeed = 10f;
            transform.Translate(Vector2.up * Time.deltaTime,Space.World);
            
        }
    }
}
