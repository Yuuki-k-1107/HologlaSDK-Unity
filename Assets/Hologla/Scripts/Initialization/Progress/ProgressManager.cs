using Hologla;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{
    [SerializeField] private GameObject progressPrefab;
    [SerializeField] private GameObject cameraCanvasesSingle;
    [SerializeField] private HologlaCameraManager hologlaCameraManager;
    [SerializeField] private GameObject[] cameraCanvasesDouble = new GameObject[2];
    private Color doneColor = new Color(0x20 / 255f, 0x20 / 255f, 0x20 / 255f, 1f);
    private Color progressColor = new Color(0xEA / 255f, 0x68 / 255f, 0x68 / 255f, 1f);
    private Color waitingColor = new Color(0x80 / 255f, 0x80 / 255f, 0x80 / 255f, 1f);
    [SerializeField] private GameObject[] progressInstances = new GameObject[3];
    private readonly string[] progressMessages = new string[5]{
        "", // 番兵(ダミー)
        "Eyemode Setting",
        "Screensize Setting",
        "IPD Setting",
        "AR/MR/VR Setting",
    };

    /// <summary>
    /// 進捗度合いを表すUIを画面の左上に作成する
    /// </summary>
    public void CreateProgress()
    {
        // 誤連射で複数個のUIインスタンスが生成されるのを防ぐため既存のUIインスタンスを破壊
        DestroyProgress();
        // 1眼用のUIをセット
        progressInstances[0] = Instantiate(progressPrefab, cameraCanvasesSingle.transform);
        // 2眼用のUIをセット
        for(int i = 1; i < 3; i++)
        {
            progressInstances[i] = Instantiate(progressPrefab, cameraCanvasesDouble[i-1].transform);
            progressInstances[i].transform.localScale = new Vector3(.7f, .7f, 1f);
        }
    }

    /// <summary>
    /// 進捗UIを消すメソッド。
    /// </summary>
    public void DestroyProgress()
    {
        foreach(GameObject instance in progressInstances)
        {
            if (null == instance) continue;
            Destroy(instance);
        }
    }

    /// <summary>
    /// 進捗UIを管理するメソッド。
    /// 現在のステップ数に応じて以下のように引数をとる。
    /// 1. 1眼/2眼設定
    /// 2. 画面サイズ設定
    /// 3. IPD設定(1眼モードはスキップ)
    /// 4. 完了画面
    /// </summary>
    /// <param name="progress">進捗度合い（）</param>
    public void SetProgress(int progress)
    {
        if (progress <= 0 || progress >= 5){
            Debug.LogError("不正なインデックス番号です");
            return;
        }
        bool is2Eyes = (HologlaCameraManager.EyeMode.TwoEyes == hologlaCameraManager.CurrentEyeMode);
        int wholeSteps = is2Eyes
            ? 4  // 2眼モード
            : 3; // 1眼モード
        foreach(GameObject instance in progressInstances)
        {
            if (null == instance) continue;
            int _progress = is2Eyes 
                ? progress 
                : ((progress >= 3) ? progress-1 : progress);
            Image[] progressImages = instance.GetComponentsInChildren<Image>();
            Text[] texts = instance.GetComponentsInChildren<Text>();
            // 進捗テキストを更新
            texts[0].text = $"{_progress}/{wholeSteps}";
            // 進捗メッセージ（今どのステップにいるか）を更新
            texts[1].text = progressMessages[progress];
            // 終わったステップを黒に
            for (int i=1; i<progress; i++)
            {
                progressImages[i].color = doneColor;
            }
            // 現在のステップを赤に
            progressImages[progress].color = progressColor;
            // これからのステップを灰色に
            for(int i = progress+1; i < progressImages.Length; i++)
            {
                progressImages[i].color = waitingColor;
            }
            // 1眼モードの時は3つ目のIPD設定はいらないので
            // UIを調整（3番目の円を非表示に・2番目の円の位置を左にずらす）
            Color tempColor = progressImages[3].color;
            if (true == is2Eyes)
            { // 2眼モード
                tempColor.a = 1;
                progressImages[3].color = tempColor;
                progressImages[2].rectTransform.anchoredPosition = new Vector2(0f, 45f);
            }
            else
            { // 1眼モード
                // 3つめのステップを表す円を「隠す」
                tempColor.a = 0;
                progressImages[3].color = tempColor;
                progressImages[2].rectTransform.anchoredPosition = new Vector2(75f, 45f);
            }
        }
    }
}
