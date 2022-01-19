using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _rightBoundary = 8.0f;
    [SerializeField] private float _leftBoundary = -8.0f;
    [SerializeField] private float _speed = 3.0f;

    public GameObject player_;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Boundary();
            float _horizontalInput = Input.GetAxis("Horizontal");
            Vector3 _direction = new Vector3(_horizontalInput, 0, 0).normalized;
            player_.transform.Translate(-(_direction.x *_speed * Time.deltaTime), 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Boundary();
            float _horizontalInput = Input.GetAxis("Horizontal");
            Vector3 _direction = new Vector3(_horizontalInput, 0, 0).normalized;
            player_.transform.Translate(_direction.x * _speed * Time.deltaTime, 0, 0);
        }
    }

    public void LButtonDown()
    {
        Boundary();
        float _horizontalInput = Input.GetAxis("Horizontal");
        Vector3 _direction = new Vector3(_horizontalInput, 0, 0).normalized;
        player_.transform.Translate(-(_direction.x * _speed * Time.deltaTime), 0, 0);

    }

    public void RButtonDown()
    {
        Boundary();
        float _horizontalInput = Input.GetAxis("Horizontal");
        Vector3 _direction = new Vector3(_horizontalInput,0 , 0).normalized;
        player_.transform.Translate(_direction.x * _speed * Time.deltaTime, 0, 0);
    }

    public void Movement()
    {
        Boundary();
        float _horizontalInput = Input.GetAxis("Horizontal") ;
        Vector3 _direction = new Vector3(_horizontalInput, 0, 0).normalized;
        player_.transform.Translate(_direction.x * _speed * Time.deltaTime, 0,0);
    }

    public void Boundary()
    {
        float _xMovementClamp = Mathf.Clamp(player_.transform.position.x, _leftBoundary, _rightBoundary);
        player_.transform.position = new Vector3(_xMovementClamp, -3, 0);
    }
}
