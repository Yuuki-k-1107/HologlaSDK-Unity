using Hologla;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BlockMenuList6の説明パネルのマテリアルを設定するスクリプト。
/// </summary>
public class SetExplainPanel : MonoBehaviour
{
    [SerializeField] private Material[] materials = new Material[3];
    private void OnEnable()
    {
        int viewMode = (int)UserSettings.viewMode;
        if (null != materials[viewMode])
        {
            GetComponent<MeshRenderer>().material = materials[viewMode];
        }
    }
}
