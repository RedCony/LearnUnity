using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILogin : MonoBehaviour
{
    public InputField inputEmail;
    public InputField inputPassword;
    public Button btnLogin;
    public Button btnSignUp;
    public Button btnClose;
    public Button btnForgotPassword;
    public Toggle toggle;
    void Start()
    {
        this.btnLogin.onClick.AddListener(() => {
            if (string.IsNullOrEmpty(inputEmail.text) || string.IsNullOrEmpty(inputPassword.text))
            {
                Debug.Log("이메일과 비밀 번호를 입력 해주세요");
            }
            else
            {
                Debug.Log(inputEmail.text);
                Debug.Log(inputPassword.text);
            }
           
        });

      
        this.btnSignUp.onClick.AddListener(() => {
            Debug.Log("signup");
        });
        this.btnForgotPassword.onClick.AddListener(() => {
            Debug.Log("forgot password");
        });

        //선택했다면 active : true 
        this.toggle.onValueChanged.AddListener((active) => {
            Debug.LogFormat("active: {0}", active);
        });
    }
    public void Open()
    {
        this.gameObject.SetActive(true);
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
