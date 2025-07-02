using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Attention : MonoBehaviour
{
    //シーン遷移までの秒数を指定
    [SerializeField] private float _waitTimer = 10.0f;
    [SerializeField] private string _nextScene;

    void Update()
    {

        //指定秒数を超えたら、メインシーンへ遷移
        _waitTimer -= Time.deltaTime;
        if (_waitTimer <= 0f)
        {
            LoadNextScene();
        }

    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(_nextScene);
    }


}
