using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHeroInfo : MonoBehaviour
{
    public Text textusername;
    public Text textlevel;
    public Text textattack;
    public Text textdefence;
    public Text texthealth;
    public Text textgold;
    public Text textgem;

    public void Init(string name,int level, float attack, float defense, float health, int gold, int gem)
    {
        this.textusername.text = name.ToString();
        this.textlevel.text = level.ToString();
        this.textattack.text = attack.ToString();
        this.textdefence.text = defense.ToString();
        this.texthealth.text = health.ToString();
        this.textgold.text = gold.ToString();
        this.textgem.text = gem.ToString();
    }

}
