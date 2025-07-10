using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 注意画面で、一定時間（10秒間）経過したときに自動的にタイトル画面に遷移する。
/// </summary>
public class Attention : MonoBehaviour
{
    [Tooltip("シーン遷移までの秒数を指定")]
    [SerializeField]
    private float _waitTimer = 10.0f;

    [Tooltip("メニュー画面のシーン名(デフォルトではMenuSample)を入力する。大文字小文字を正しく設定しないとエラーになるので注意。")]
    [SerializeField]
    private string _nextScene;

    void Update()
    {

        //指定秒数を超えたら、メインシーンへ遷移
        _waitTimer -= Time.deltaTime;
        if (_waitTimer <= 0f)
        {
            LoadNextScene();
        }

    }

    /// <summary>
    /// インスペクター上で設定した名前のシーンをロードする。
    /// </summary>
    public void LoadNextScene()
    {
        SceneManager.LoadScene(_nextScene);
    }


}
