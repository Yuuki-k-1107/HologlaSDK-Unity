using Hologla;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaySkipIPD : MenuDestManagerAbstract
{
    /// <summary>
    /// 単眼モードの時にIPDをスキップするためのスクリプト。
    /// 抽象クラスMenuDestManagerAbstractを実装することで冗長性を減らした。
    /// BlockListMenu5にアタッチする。
    /// </summary>
    /// 

    [SerializeField] private GameObject objectInit; // 初期化時に呼ばれるオブジェクト
    [SerializeField] private GameObject objectNormal;　// 通常時(各メニュークリック時)に呼ばれるオブジェクト
    [SerializeField] private GameObject objectSkip; // 単眼モード時に呼ばれるオブジェクト
    [SerializeField] private GameObject rootObject; // 親オブジェクト(MenuListSampleInit)

    void Start()
    {
        rootObject = gameObject.transform.root.gameObject;
    }

    void Update()
    {
        //
    }

    private void OnEnable()
    {
        ChangeMenuDest();
    }

    /// <summary>
    /// 初期化中、および単眼モードかどうかで遷移先を変更する。
    /// </summary>
    public override void ChangeMenuDest()
    {
        if (null != rootObject && true == rootObject.GetComponent<DestinationHolder>().IsInit())
        {
            // 単眼モードの時
            if (HologlaCameraManager.EyeMode.SingleEye == UserSettings.eyeMode)
            {
                Debug.Log("Single Eye Mode");
                objectSkip.SetActive(true);
                objectInit.SetActive(false);
                objectNormal.SetActive(false);
            }
            else
            {
                Debug.Log("Double Eye Mode");
                objectSkip.SetActive(false);
                objectInit.SetActive(true);
                objectNormal.SetActive(false);
            }
        }
        // 初期化状態でないとき
        else
        {
            Debug.Log("Not an initialization");
            objectSkip.SetActive(false);
            objectInit.SetActive(false);
            objectNormal.SetActive(true);
        }
    }
}
