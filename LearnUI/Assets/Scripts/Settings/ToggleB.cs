using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ToggleB : MonoBehaviour
{
    public Button btnToggle;
    public GameObject onGo;
    public GameObject offGo;

    public GameObject onText;
    public GameObject offText;
    public GameObject onSp;
    public GameObject offSp;

    private int state ;   //0: off, 1: on
    public float toggleMoveSpeed = 0.5f;
    void Start()
    {
        if (state == 0)
        {
            this.onSp.SetActive(false);
            this.onText.SetActive(false);
        }
        else
        {
            this.offSp.SetActive(false);
            this.offText.SetActive(false);
        }
        this.btnToggle.onClick.AddListener(() => {

            if (this.state == 1)
            {
                this.onSp.SetActive(false);
                this.offSp.SetActive(true);
                this.onText.SetActive(false);
                this.offSp.transform.DOLocalMoveX(-48f, this.toggleMoveSpeed).SetEase(Ease.OutQuad).onComplete = () => {
                    this.offText.SetActive(true);

                    this.state = 0;
                };
                Debug.Log("Notice On");
            }
            else
            {

                this.offText.SetActive(false);
                this.offSp.transform.DOLocalMoveX(48f, this.toggleMoveSpeed).SetEase(Ease.OutQuad).onComplete = () => {
                    this.onSp.SetActive(true);
                    this.onText.SetActive(true);
                    this.state = 1;
                };
                Debug.Log("Notice Off");
            }

        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
