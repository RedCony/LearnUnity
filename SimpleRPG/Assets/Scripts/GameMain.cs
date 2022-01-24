using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    public Playercontroller player;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin,ray.direction * 1000f, Color.red, 2.5f);
           
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit, 1000f))
            {
                Debug.Log(hit.point);
                Debug.Log(hit.collider.tag);
               
                this.player.Move(hit.point);
            }
            
        }
       
    }
}
