using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public enum eDir
    {
        LEFT = 1, RIGHT = -1
    }
    public float deceleration =0.96f;


    public eDir dir;
    public float initRotSpeed = 100.0f;
    float rotSpeed ;
    float timeSpan;
    float checkTime;
    
    // Start is called before the first frame update
    void Start()
    {
        // this.rotSpeed = 10;
        timeSpan = 0.0f;
        checkTime = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            rotSpeed = this.initRotSpeed * (int)dir;
           
        }

        timeSpan += Time.deltaTime;
        if (timeSpan > checkTime)
        {

            this.transform.Rotate(0, 0, this.rotSpeed);
            timeSpan = 0;

        }

        if (Input.GetMouseButtonDown(1))
        {
            this.rotSpeed *= this.deceleration;
        }
         
        //회전 속도 만큰 룰렛을 회전 시킨다.
        

        //룰렛 속도를 감속시킨다.
        
      
        

        //Pause();
    }

    private void Pause()
    {
        //Time.timeScale = (float)3;
        this.rotSpeed *= this.deceleration;
    }
}
