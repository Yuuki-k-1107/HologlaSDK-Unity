using Hologla;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Hologla.HologlaCameraManager;

public sealed class SelectDecisionBlockForList5 : SelectDecisionBlockAbstract
{
    // これらは継承元のクラスで定義しているのでコメントアウト
    //[SerializeField] private InitializationManager _initializationManager;
    //[SerializeField] private GameObject decisionBlockNormal;
    //[SerializeField] private GameObject decisionBlockInit;
    [SerializeField]
    [Tooltip("1眼モード時に表示するスキップブロック。")]
    private GameObject decisionBlockSkip;
    private void OnEnable()
    {
        decisionBlockInit.SetActive(false);
        decisionBlockNormal.SetActive(false);
        decisionBlockSkip.SetActive(false);
        if (false == _initializationManager.IsInitializing)
        { // 初期設定でなく直接設定を選択したとき
            // トップメニューに戻るボタンを有効化する
            decisionBlockNormal.SetActive(true);
            return;
        }
        // 初期設定の場合は
        if (EyeMode.SingleEye == UserSettings.eyeMode)
        {
            // 1眼モードの時はIPD設定をスキップしAR/MR/VR設定を表示する。
            decisionBlockSkip.SetActive(true);
        }
        else
        {
            // 2眼モードの時はIPD設定に遷移するブロックを表示する。
            decisionBlockInit.SetActive(true);
        }
    }
    void Start()
    {
        if(null == _initializationManager)
        {
            _initializationManager = transform.root.GetComponent<InitializationManager>();
        }
    }
}
