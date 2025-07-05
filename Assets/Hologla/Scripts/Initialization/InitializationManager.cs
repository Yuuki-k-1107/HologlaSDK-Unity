using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 初期設定中かどうかを確認するプロパティを保管するクラス。
/// SetInitializationメソッドを残しているのはインスペクター上ですでに設定した関数でMissingになるのを避けるためである。
/// MenuListSampleにアタッチする。
/// </summary>
public class InitializationManager : MonoBehaviour
{
    public bool IsInitializing { get; set; }

    [Obsolete]
    public void SetInitialization(bool value) { 
        IsInitializing = value;
        Debug.LogError("旧式のメソッドから初期化フラグを呼び出しています。IsInitializingプロパティをご利用ください。");
    }
}
