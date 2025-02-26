using Hologla;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 画面サイズが一致しているときに外枠を表示するスクリプト。
/// </summary>
public class SizeMayShowFrame : MayShowSelectFrame
{
    void Update()
    {
        FrameCheck();
    }

    public override void FrameCheck()
    {
        // UserSettings.viewSizeのインデックスはサイズ番号より1小さい点に注意。
        // たとえばSize4の場合はsizeValueに3をセットする
        if (null != selectFrameObject && (int)UserSettings.viewSize == value)
        {
            selectFrameObject.SetActive(true);
        }
        else
        {
            selectFrameObject.SetActive(false);
        }
    }
}
