using Hologla;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 初期化時に表示するメニューを変更するための抽象クラス。
/// </summary>
/// 
public abstract class MenuDestManagerAbstract : MonoBehaviour
{
    public abstract void ChangeMenuDest();
}

/// <summary>
/// 初期化時に表示するメニューを変更するためのスクリプト。
/// BlockListMenu2,3,5にアタッチする。
/// </summary>
/// 
public class MenuDestManager : MenuDestManagerAbstract
{

    [SerializeField] private GameObject objectInit; // 初期化時に呼ばれるオブジェクト
    [SerializeField] private GameObject objectNormal;　// 通常時(各メニュークリック時)に呼ばれるオブジェクト
    [SerializeField] private GameObject rootObject; // 親オブジェクト(MenuListSampleInit)

    void Update()
    {
        //
    }

    private void OnEnable()
    {
        ChangeMenuDest();
    }

    /// <summary>
    /// 表示するメニューをここで調整する
    /// </summary>
    public override void ChangeMenuDest() {
        if (null == rootObject)
        {
            rootObject = gameObject.transform.root.gameObject;
        }
        if (null != rootObject && true == rootObject.GetComponent<DestinationHolder>().IsInit( )) { 
            objectInit.SetActive(true);
            objectNormal.SetActive(false);
        } else
        {
            objectInit.SetActive(false);
            objectNormal.SetActive(true);
        }
    }
}
