using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 初期設定用の遷移先を用意するための抽象クラス。
/// 基本は通常時と初期設定時の2つの遷移先を用意する。
/// </summary>
public abstract class SelectDecisionBlockAbstract : MonoBehaviour
{
    [SerializeField] protected InitializationManager _initializationManager;
    [SerializeField] protected GameObject decisionBlockNormal;
    [SerializeField] protected GameObject decisionBlockInit;
}

/// <summary>
/// 初期設定用の遷移先を用意するためのクラスの実装である。
/// 具体的には、InitializationManagerのIsInitializingプロパティを読みとって、その値に応じて遷移先を決定している。
/// </summary>
public class SelectDecisionBlock : SelectDecisionBlockAbstract
{
    private void OnEnable()
    {
        bool isInitializing = _initializationManager.IsInitializing;
        decisionBlockInit.SetActive(isInitializing);
        decisionBlockNormal.SetActive(!isInitializing);
    }
    void Start()
    {
        if(null == _initializationManager)
        {
            _initializationManager = transform.root.GetComponent<InitializationManager>();
        }
    }

    void Update()
    {
        
    }
}
