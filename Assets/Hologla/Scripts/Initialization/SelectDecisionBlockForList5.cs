using Hologla;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Hologla.HologlaCameraManager;

public sealed class SelectDecisionBlockForList5 : SelectDecisionBlockAbstract
{
    //[SerializeField] private InitializationManager _initializationManager;
    //[SerializeField] private GameObject decisionBlockNormal;
    //[SerializeField] private GameObject decisionBlockInit;
    [SerializeField] private GameObject decisionBlockSkip;
    private void OnEnable()
    {
        // 初期設定の時
        if(true == _initializationManager.IsInitializing)
        {
            // 1眼モードの時はIPD設定をスキップ
            if (EyeMode.SingleEye == UserSettings.eyeMode)
            {
                decisionBlockInit.SetActive(false);
                decisionBlockNormal.SetActive(false);
                decisionBlockSkip.SetActive(true);
            }
            else
            {
                decisionBlockInit.SetActive(true);
                decisionBlockNormal.SetActive(false);
                decisionBlockSkip.SetActive(false);
            }
        }
        else
        {
            decisionBlockInit.SetActive(false);
            decisionBlockNormal.SetActive(true);
            decisionBlockSkip.SetActive(false);
        }
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
