using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 遷移先を保管するためのクラス。
/// </summary>
public class DestinationHolder : MonoBehaviour
{
    [SerializeField] private bool isInit;

    /// <summary>
    /// 初期設定かどうかを返す
    /// </summary>
    /// <returns>初期設定中ならtrue</returns>
    public bool IsInit()
    {
        return isInit;
    }

    /// <summary>
    /// プライベート変数isInitを変更する
    /// </summary>
    /// <param name="b">セットしたいbool変数</param>
    public void SetInit(bool b)
    {
        isInit = b;
    }

    /// <summary>
    /// 初期化フラグを折る
    /// </summary>
    public void UnsetInitial0Flag()
    {
        PlayerPrefs.SetInt("Initial0", 1);
    }
}
