using Hologla;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 画面サイズが一致しているときに外枠を表示するスクリプト。
/// BlockMenuList5にそのままアタッチする。
/// </summary>
public class SizeMayShowFrame : MonoBehaviour
{
    [SerializeField] private GameObject[] frameObjects;
    void Update()
    {
    }

    private void OnEnable()
    {
        FrameCheck();
    }

    public void FrameCheck()
    {
        var currentViewSize = (int)UserSettings.viewSize;
        for(int i=0; i<frameObjects.Length; i++)
        {
            if(null == frameObjects[i]) continue;
            frameObjects[i].SetActive(false);
            if(currentViewSize == i)
            {
                frameObjects[i].SetActive(true);
            }
        }
        Debug.Log($"viewsize = {UserSettings.viewSize}");
        //if (null != selectFrameObject)
        //{
        //    selectFrameObject.SetActive(false);
        //    // UserSettings.viewSizeのインデックスはサイズ番号より1小さい点に注意。
        //    // たとえばSize4の場合はsizeValueに3をセットする
        //    if ((int)UserSettings.viewSize == value)
        //    {
        //        selectFrameObject.SetActive(true);
        //    }
        //}
    }
}
