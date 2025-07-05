using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUninitialized : MonoBehaviour
{
    void Start()
    {
        var initial0 = PlayerPrefs.GetInt("Initial0");
        Debug.Log($"現在のInitial0の値は{initial0}です。");
#if UNITY_EDITOR || true // テスト用。
        //#if UNITY_EDITOR
        PlayerPrefs.SetInt("Initial0", 0);
#endif
    }

    void Update()
    {
        
    }
}
