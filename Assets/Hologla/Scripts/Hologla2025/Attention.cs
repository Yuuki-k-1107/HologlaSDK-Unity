using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// PlayerPrefs.Initial0をテストするためのスクリプト。
/// さらに、タイトル画面からの遷移もこのスクリプトで行う(実際のアプリの)。
/// Attentionシーンにアタッチする。
/// </summary>
public class Attention : MonoBehaviour
{
    [SerializeField] private float _waitTimer = 10f;
    [SerializeField] private string _nextScene;

    void Update()
    {
        _waitTimer -= Time.deltaTime;
        if(_waitTimer <= 0f)
        {
            LoadNextScene();
        }
    }

    void Start()
    {
#if UNITY_EDITOR
        Debug.Log($"現在のInitial0の値は{PlayerPrefs.GetInt("Initial0")}です。");
        PlayerPrefs.SetInt("Initial0", 0);
#endif
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene( _nextScene );
    }
}
