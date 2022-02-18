using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHudText : MonoBehaviour
{
    public Text damageText;

    public void Init(float damage)
    {
        this.damageText.text = damage.ToString();
    }
}
