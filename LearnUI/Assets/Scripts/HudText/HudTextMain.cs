using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HudTextMain : MonoBehaviour
{
    public Button btn1;
    public Button btn2;

    public Animator anim1;   //player1 
    public Animator anim2;   //player2 

    public ParticleSystem fs;
    public Transform hudPivot;
    public GameObject hudPivotPrefab;
    public RectTransform canvasRectTrans;
    void Start()
    {
        var animEventReceiver1 = this.anim1.gameObject.GetComponent<AnimationEventReceiver>();
        animEventReceiver1.triggerAnimationEvent.AddListener((eventName) => {
            Debug.LogFormat("<color=yellow>eventName: {0}</color>", eventName);
            //Debug.LogErrorFormat("<color=yellow>eventName: {0}</color>", eventName);
            this.anim2.Play("GetHit", -1, 0); //reset and play 

            fs.Play();
        });

        var animEventReceiver2 = this.anim2.gameObject.GetComponent<AnimationEventReceiver>();
        animEventReceiver2.triggerAnimationEvent.AddListener((eventName) => {
            Debug.LogFormat("<color=yellow>eventName: {0}</color>", eventName);

            GameObject uiGo = Instantiate<GameObject>(this.hudPivotPrefab, this.canvasRectTrans);
            UIHudText uiHudText = uiGo.GetComponent<UIHudText>();

            uiHudText.Init(Random.Range(1, 100));

            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.hudPivot.position);
            var rectTrans = uiGo.GetComponent<RectTransform>();

            //init
            rectTrans.position = screenPos;
            rectTrans.localScale = Vector3.zero;

            rectTrans.DOScale(1.5f, 0.3f).onComplete = () => {
                rectTrans.DOScale(1f, 0.3f);
            };
            //move tween 
            rectTrans.DOLocalMoveY(200f, 0.6f).SetEase(Ease.InCubic).onComplete = () => {
                Debug.Log("complete!");
                Destroy(rectTrans.gameObject);  //hudText go 
            };


        });

        this.btn1.onClick.AddListener(() => {
            this.anim1.Play("Attack01", -1, 0); //reset and play 
        });

        this.btn2.onClick.AddListener(() => {
            this.anim2.Play("GetHit", -1, 0); //reset and play 
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
