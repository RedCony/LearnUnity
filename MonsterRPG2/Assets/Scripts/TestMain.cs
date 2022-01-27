using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMain : MonoBehaviour
{
    public GameObject playerGo;
    public Transform firePoint;
    public Button btn;
    public float range = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.btn.onClick.AddListener(() => {
            //ray 
            Ray ray = new Ray(this.firePoint.position, this.playerGo.transform.forward * range);
            Debug.DrawRay(ray.origin, ray.direction * range, Color.red, 5f);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, this.range))
            {
                Debug.Log(hit.collider.gameObject);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
