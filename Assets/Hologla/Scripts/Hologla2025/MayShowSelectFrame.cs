using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 設定と一致する場合に選択中を表す青色のフレームを表示させる抽象クラス。
/// </summary>
public abstract class MayShowSelectFrame : MonoBehaviour
{
    [SerializeField] protected int value;
    [SerializeField] protected GameObject selectFrameObject;

    public abstract void FrameCheck();
}
