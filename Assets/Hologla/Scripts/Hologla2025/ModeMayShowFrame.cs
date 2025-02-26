using Hologla;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// モードが一致しているときに外枠を表示するスクリプト。
/// </summary>
public class ModeMayShowFrame : MayShowSelectFrame
{
    void Update()
    {
        FrameCheck();
    }

    public override void FrameCheck() {
        // 0:AR 1:MR 2:VR
        if (null != selectFrameObject && (int)UserSettings.viewMode == value)
        {
            selectFrameObject.SetActive(true);
        }
        else
        {
            selectFrameObject.SetActive(false);
        }
    }
}
