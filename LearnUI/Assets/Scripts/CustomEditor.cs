using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class CustomEditor : MonoBehaviour
{
   [MenuItem("DefaultCompany/PlayerPrefs/DeleteSettingInfo")]

   static void DeleteSettingInfo()
    {
        
        PlayerPrefs.DeleteKey("setting_info");
        Debug.Log("delete setting_info..");
    }
}
