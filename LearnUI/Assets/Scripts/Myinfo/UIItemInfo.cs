using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInfo : MonoBehaviour
{
    public UIItem uIItem;

    public Image image;

    public Text name;
    public Text description1;
    public Text description2;
    public Text description3;

    public void Init(string name,string spritename)
    {
        this.image = uIItem.GetComponent<Image>();

        this.name.text = name.ToString();
        this.description1.text = spritename.ToString();
    }

    public void Open()
    {
        this.uIItem.gameObject.SetActive(true);
    }

    public void Close()
    {
        this.uIItem.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        //this.image = uIItem.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
