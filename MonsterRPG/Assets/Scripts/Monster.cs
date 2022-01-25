using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
   
    public int id { get; set; }

    public Monster(int id)
    {
        this.id = id;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.id = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
