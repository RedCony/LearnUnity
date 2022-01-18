using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.Translate(-3, 0, 0, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.Translate(3, 0, 0, Space.World);
        }
    }

    public void LButtonDown()
    {
        transform.Translate(-3, 0, 0, Space.World);
    }

    public void RButtonDown()
    {
        transform.Translate(3, 0, 0, Space.World);
    }
}
