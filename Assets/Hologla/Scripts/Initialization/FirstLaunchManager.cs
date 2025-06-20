using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 初期起動時に自動的に初期設定に遷移するためのスクリプト。
/// MenuSampleのMenuListSampleにアタッチする。
/// </summary>
public class FirstLaunchManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private InitializationManager _initializationManager;
    void Start()
    {
        if(null == _animator) _animator = GetComponent<Animator>();
        if(null == _initializationManager) _initializationManager = GetComponent<InitializationManager>();
        MayShowInitMenu();
    }

    void Update()
    {
        
    }

    public void MayShowInitMenu()
    {
        // 実体験：PlayerPrefsのキーは大文字と小文字を区別するっぽいです。
        // すなわち、"initial0"と"Initial0"は別物として扱われるようです。
        // 今回はキー名に大文字の"Initial0"を用いようと思います。
        var initial0 = PlayerPrefs.GetInt("Initial0");
        Debug.Log(initial0);
        if (0 != initial0) return;
        if (null != _initializationManager)
        {
            _initializationManager.IsInitializing = true;
        }
        if (null != _animator)
        {
            _animator.SetTrigger("EyeModeMenuIn");
        }
    }

    public void UnsetInitial0()
    {
        Debug.Log("UnsetInitial0 called");
        PlayerPrefs.SetInt("Initial0", 1);
    }
}
