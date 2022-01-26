using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterMain : MonoBehaviour
{
    public GameObject playerGo;
    public GameObject enemyGo;
    public Button btnAttack;
    // Start is called before the first frame update
    void Start()
    {
        this.btnAttack.onClick.AddListener(() => { });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
