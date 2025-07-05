using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 初期起動時に自動的に初期設定に遷移するためのスクリプト。
/// MenuSampleのMenuListSampleにアタッチする。
/// </summary>
[RequireComponent(typeof(InitializationManager))]
public class FirstLaunchManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("MenuListSampleのAnimatorをセットする。")]
    private Animator _animator;

    [SerializeField]
    [Tooltip("MenuListSampleにアタッチされているInitializationManagerインスタンスをセットする。もしアタッチされていないならばアタッチする。")]
    private InitializationManager _initializationManager;


    void Start()
    {
        if(null == _animator) _animator = GetComponent<Animator>();
        if(null == _initializationManager) _initializationManager = GetComponent<InitializationManager>();
        MayShowInitMenu();
    }

    /// <summary>
    /// （主に）アプリ起動時に初期設定を行ったかどうかをPlayerPrefs APIを利用して判定する。
    /// もし初期設定を行っていない場合は自動的に
    /// なお、初期設定を行ったかどうかを判定するキー
    /// </summary>
    public void MayShowInitMenu()
    {
        // 実体験：PlayerPrefsのキーは大文字と小文字を区別するっぽいです。
        // すなわち、"initial0"と"Initial0"は別物として扱われるようです。
        // 今回はキー名に大文字の"Initial0"を用いようと思います。
        var initial0 = PlayerPrefs.GetInt("Initial0", 0);
        Debug.Log($"キーInitial0の値は{initial0}です。");
        if (0 != initial0) 
        {
            Debug.Log("初期設定はすでに完了しています。");
            return;
        }
        Debug.Log("初期設定に自動的に移行します。");
        if (null != _initializationManager)
        {
            _initializationManager.IsInitializing = true;
        }
        if (null != _animator)
        {
            _animator.SetTrigger("EyeModeMenuIn");
        }
    }

    /// <summary>
    /// 初期設定が完了した際にインスペクターからイベント登録するためのメソッド。
    /// </summary>
    public void UnsetInitial0()
    {
        Debug.Log("UnsetInitial0 called");
        PlayerPrefs.SetInt("Initial0", 1);
        PlayerPrefs.Save();
    }
}
