using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _rightBoundary = 0f;
    [SerializeField] private float _leftBoundary = 0f;
    [SerializeField] private float _speed = 3.0f;

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
       
       
        
    }

    public void RButtonDown()
    {
        transform.Translate(_speed, 0, 0, Space.World);
    }

    public void Movement()
    {
        Boundary();
        float _horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 _direction = new Vector3(_horizontalInput, 0, 0).normalized;
        transform.Translate(_direction * _speed * Time.deltaTime, 0, 0);
    }

    public void Boundary()
    {
        float _xMovementClamp = Mathf.Clamp(transform.position.x, _leftBoundary, _rightBoundary);
        transform.position = new Vector3(_xMovementClamp, 0, 0);
    }
}
