using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using UnityEngine.Events;

public class TestJsonMain : MonoBehaviour
{

    public GameObject slimePrefab;
    public Button btnDie;

    public int dropItemId = 100;
    public int sPawnid;

    private UnityAction dieAction;
    private BoxCollider area;

   

    // Start is called before the first frame update
    void Start()
    {
        slimePrefab = GameObject.FindGameObjectWithTag("Monster");
        sPawnid = Random.Range(100, 107);
        area = GetComponent<BoxCollider>();
        DataManager.GetInstance().LoadWeaponData();
        DataManager.GetInstance().LoadMonsterData();

        MonsterData monsterData = DataManager.GetInstance().GetMonsterData(sPawnid);
        GameObject prefab1 = Resources.Load<GameObject>(monsterData.prefabName);
        GameObject prefabClone1 = Instantiate<GameObject>(prefab1);
        prefabClone1.transform.position = this.slimePrefab.transform.position;

        this.dieAction = () => {
            WeaponData weaponData = DataManager.GetInstance().GetWeaponData(dropItemId);
            GameObject prefab = Resources.Load<GameObject>(weaponData.prefabName);
            GameObject prefabClone = Instantiate<GameObject>(prefab);
            prefabClone.transform.position = this.slimePrefab.transform.position;

            Destroy(prefabClone1);
        };

        this.btnDie.onClick.AddListener(() => {
            this.StartCoroutine(this.DieRoutine());
        
        });
    }
    private IEnumerator DieRoutine()
    {
        
        this.slimePrefab.GetComponent<Animator>().Play("Die");
        yield return new WaitForSeconds(1.333f);
        Debug.Log("die 애니메이션 종료");
        this.dieAction();
    }

    
    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;

        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.x + Random.Range(-size.y / 2f, size.y / 2f);
        float posZ = basePosition.x + Random.Range(-size.z / 2f, size.z / 2f);

        Vector3 spawnPos = new Vector3(posX, posY, posZ);

        return spawnPos;
    }

    private void Spawn()
    {

        int selection;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
