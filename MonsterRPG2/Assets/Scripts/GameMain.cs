using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    public Monster monster;

    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        this.monster = GetComponent<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.red, 2f);

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.collider.tag.Equals("Monster"))
                {
                    var monster = hit.collider.gameObject.GetComponent<Monster>();
                    monster.Attack01();

                    
                }
            }
        }
    }
}
