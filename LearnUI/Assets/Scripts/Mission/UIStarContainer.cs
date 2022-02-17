using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStarContainer : MonoBehaviour
{
    public GameObject[] arrstars;

    public void Init()
    {
        UpdateStars(0);
    }

    public void UpdateStars(int count)
    {
        foreach (var go in this.arrstars)
        {
            go.SetActive(false);
        }
        for(int i = 0; i < count; i++)
        {
            this.arrstars[i].SetActive(true);
        }
    }
}
