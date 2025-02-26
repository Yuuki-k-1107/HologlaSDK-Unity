using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 説明パネルが表示されているときにテキストを隠すスクリプト。
/// 説明パネルの上にテキストが表示される不具合に対応。
/// テキストオブジェクトにアタッチする。
/// </summary>
public class HideTextWhenInstruction : MonoBehaviour
{
    [SerializeField] private GameObject instructionObject;
    [SerializeField] private TextMesh textMesh;
    // private string _originalText;
    private Color _originalColor, _hiddenColor;
    void Start()
    {
        if (null == textMesh)
        {
            textMesh = GetComponent<TextMesh>();
        }
        // _originalText = textMesh.text;
        _originalColor = textMesh.color;
        _hiddenColor = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0f);
    }
    
    void Update()
    {
        if (null != instructionObject && null != textMesh) {
            if (true == instructionObject.activeInHierarchy)
            {
                // textMesh.text = "";
                textMesh.color = _hiddenColor;
            }
            else
            {
                // textMesh.text = _originalText;
                textMesh.color = _originalColor;
            }
        }
    }
}
