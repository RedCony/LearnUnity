using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    GameObject director;

    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
     void OnTriggerEnter(Collider other)
    {
        Debug.Log("¿‚æ“¥Ÿ.");
        if (other.tag.Equals("Apple"))
        {
            Debug.Log("Tag=Apple");
            this.director.GetComponent<GameDirector>().GetApple();
            this.aud.PlayOneShot(this.appleSE);
        }
        else
        {
            Debug.Log("Tag=Bomb");
            this.director.GetComponent<GameDirector>().GetBomb();
            this.aud.PlayOneShot(this.bombSE);
        }
        Destroy(other.gameObject);
    }
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
        this.director =GameObject.Find("GameDirector");
        
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
