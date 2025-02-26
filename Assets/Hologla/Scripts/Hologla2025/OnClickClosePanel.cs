using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// クリック時にパネルを非表示にするスクリプト。
/// パネルの親オブジェクトであるキャンバスにアタッチする。
/// </summary>
public class OnClickClosePanel : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
            gameObject.SetActive(false);
        } ;
    }
}
