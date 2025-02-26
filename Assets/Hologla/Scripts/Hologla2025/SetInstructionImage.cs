using Hologla;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 初期設定時、表示したい内容に合わせて画像を設定するスクリプト。
/// </summary>
public class SetInstructionImage : MonoBehaviour
{
    [SerializeField] private Sprite[] sprite = new Sprite[3];
    [SerializeField] private Sprite[] spriteTwin = new Sprite[3];
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private bool _isFromHelp;

    private float _width = 1f;

    void Awake()
    {
        _width = transform.localScale.x;
    }

    void Update()
    {
        // ゲームオブジェクトを非表示にする処理だが、新たに背面にBlockItemを追加しそちらにアタッチされているGazeInteractiveの方で行うこととした。
        // したがって、この部分をコメントアウトした。
        //if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(0)) {
        //    gameObject.SetActive(false);
        //};
    }

    /// <summary>
    /// インデックス番号に応じて画像を変更する。
    /// メニュー切り替え時に呼ばれることを想定している。
    /// </summary>
    /// <param name="index">インデックス番号</param>
    public void ChangeInstructionImage(int index)
    {
        // 条件判定(インデックスが配列内にあるか・sprite/SpriteRendererが存在するか)
        if (sprite.Length <= index || null == _renderer) return;
        // 二眼モード用のスプライトを貼る
        if (HologlaCameraManager.EyeMode.TwoEyes == UserSettings.eyeMode)
        {
            if (null == spriteTwin[index]) return;
            _renderer.sprite = spriteTwin[index];
            // ARモードの時に横つぶれしないようにARモード時に比率を1に設定しておく
            float widthRatio = (HologlaCameraManager.ViewMode.AR == UserSettings.viewMode) ? 1.5f : 1f;
            transform.localScale = new Vector3(_width*widthRatio, transform.localScale.y, transform.localScale.z);
        }
        //単眼モード用のスプライトを貼る
        else
        {
            if (null == sprite[index]) return;
            _renderer.sprite = sprite[index];
            transform.localScale = new Vector3(_width, transform.localScale.y, transform.localScale.z);
        }
    }

    /// <summary>
    /// 有効化した後、初期化中でなく、かつヘルプボタン経由でなければすぐにオブジェクトを無効化する
    /// </summary>
    private void OnEnable()
    {
        // Debug.Log("OnEnable() called");
        var initial0 = PlayerPrefs.GetInt("Initial0");
        if(0 != initial0 && false == _isFromHelp)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        // Debug.Log("OnDisable() called");
        _isFromHelp = false;
    }

    /// <summary>
    /// ヘルプボタンが押されたときにフラグを建てる
    /// </summary>
    public void CallOnHelp()
    {
        // Debug.Log("CallOnHelp() called");
        _isFromHelp = true;
    }
}
