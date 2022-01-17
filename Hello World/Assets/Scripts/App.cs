using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    public int damage;
    public float hp;
    public string myName;
    public bool isDie;

    public string[] arrNames;
    public GameObject playerGo;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("hello world");
        Vector2 stratpos = new Vector2(2.0f,1.0f);
        Vector2 endpos = new Vector2(8.0f, 5.0f);
        Vector2 dir = endpos - stratpos;
        Debug.Log(dir);
        float distance = dir.magnitude;
        Debug.Log(distance);

        Vector2 playerpos = new Vector2(2, 3);
        playerpos += new Vector2(8,5);
        Debug.Log(playerpos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
