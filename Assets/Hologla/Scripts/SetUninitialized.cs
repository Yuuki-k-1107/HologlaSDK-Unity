using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 初期設定を行うフラグを立てるためのスクリプト。
/// </summary>
public class SetUninitialized : MonoBehaviour
{
    void Start()
    {
        var initial0 = PlayerPrefs.GetInt("Initial0");
        Debug.Log($"現在のInitial0の値は{initial0}です。");
#if true || UNITY_EDITOR // テスト用。
        //#if UNITY_EDITOR // 本番はこっちを使う。
        PlayerPrefs.SetInt("Initial0", 0);
#endif
    }
}
