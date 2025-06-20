using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializationManager : MonoBehaviour
{
    public bool IsInitializing { get; set; }

    [Obsolete]
    public void SetInitialization(bool value) { 
        IsInitializing = value;
        Debug.LogError("旧式のメソッドから初期化フラグを呼び出しています。IsInitializingプロパティをご利用ください。");
    }
}
