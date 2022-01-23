using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    private float delta;
    public GameObject enemyAPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > 1.0f)
        {
            this.delta = 0;

            GameObject enemyGo = Instantiate<GameObject>(this.enemyAPrefab);

            float randX = Random.Range(-2, 3);
            float posY = 5.76f;
            enemyGo.transform.position = new Vector3(randX, posY, 0);
        }
    }
}
