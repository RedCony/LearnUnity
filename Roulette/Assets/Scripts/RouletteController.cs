using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public enum eDir
    {
        LEFT = 1, RIGHT = -1
    }
    public float deceleration;

    public eDir dir;
    public float initRotSpeed = 10;
    float rotSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
       // this.rotSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            rotSpeed =this.initRotSpeed * (int)dir;
        }
        //회전 속도 만큰 룰렛을 회전 시킨다.
        this.transform.Rotate(0, 0, this.rotSpeed);

        //룰렛 속도를 감속시킨다.
        this.rotSpeed *= this.deceleration;
    }
}
