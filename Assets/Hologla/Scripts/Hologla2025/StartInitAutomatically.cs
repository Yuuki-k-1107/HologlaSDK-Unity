using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 初期起動時に自動的に初期設定に遷移するためのスクリプト。
/// BlockListMenu1にアタッチする。
/// </summary>
public class StartInitAutomatically : MonoBehaviour
{
    [SerializeField] private Animator animator; // アニメーター
    [SerializeField] private DestinationHolder destinationHolder;
    [SerializeField] private GameObject rootObject; // 親オブジェクト(MenuListSampleInit)

    void Awake()
    {
        // 親オブジェクトおよびコンポーネントを取得
        rootObject = gameObject.transform.root.gameObject;
        if (null == animator)
        {
            animator = rootObject.GetComponent<Animator>();
        }
        if (null == destinationHolder)
        {
            destinationHolder = rootObject.GetComponent<DestinationHolder>();
        }
    }

    void Start()
    {
        CheckInit();
    }

    /// <summary>
    /// 初回起動時に自動的にInitに飛ぶようにする
    /// </summary>
    private void CheckInit()
    {
        var initial0 = PlayerPrefs.GetInt("Initial0");
        if (0 == initial0)
        {
            // 初期化フラグを折る処理は初期化終了時に移動
            // PlayerPrefs.SetInt("Initial0", 1);
            // ここにInit処理を書く
            #region animatorおよびdestinationHolderを用いた自動遷移
            if (null != animator && null != destinationHolder)
            {
                destinationHolder.SetInit(true);
                animator.SetTrigger("EyeModeMenuIn");
            }
            #endregion
        }
    }
}
