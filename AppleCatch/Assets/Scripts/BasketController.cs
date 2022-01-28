using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
     void OnTriggerEnter(Collider other)
    {
        Debug.Log("¿‚æ“¥Ÿ.");
        if (other.tag.Equals("Apple"))
        {
            Debug.Log("Tag=Apple");
        }
        else
        {
            Debug.Log("Tag=Bomb");
        }
        Destroy(other.gameObject);
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * Time.deltaTime, Color.red, 2.5f);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
}
