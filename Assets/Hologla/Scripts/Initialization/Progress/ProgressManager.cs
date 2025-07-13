using Hologla;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 画面左上に表示される進捗度合いを表すUIを管理するクラス。
/// 表示を更新したいときはインスペクターからSetProgress()メソッドを呼ぶ必要がある。
/// </summary>
public class ProgressManager : MonoBehaviour
{
    [Tooltip("進捗度合いを表すプレハブオブジェクト。")]
    [SerializeField]
    private GameObject progressPrefab;

    [Tooltip("1眼モード用のカメラキャンバス。")]
    [SerializeField]
    private GameObject cameraCanvasesSingle;

    [Tooltip("2眼モード用のカメラキャンバス。0番目に左のキャンバスをセットする。")]
    [SerializeField]
    private GameObject[] cameraCanvasesDouble = new GameObject[2];

    [Tooltip("MenuListSampleにアタッチされているHologlaCameraManagerインスタンス。")]
    [SerializeField]
    private HologlaCameraManager hologlaCameraManager;

    // 完了したステップの色（黒）
    private Color doneColor = new Color(0x20 / 255f, 0x20 / 255f, 0x20 / 255f, 1f);
    // 現在のステップの色（赤）
    private Color progressColor = new Color(0xEA / 255f, 0x68 / 255f, 0x68 / 255f, 1f);
    // まだ到達していないステップの色（グレー）
    private Color waitingColor = new Color(0x80 / 255f, 0x80 / 255f, 0x80 / 255f, 1f);

    [Tooltip("作成した初期設定UIのインスタンス。インスペクター上にはここには基本何も参照を入れない。")]
    [SerializeField] // テスト用にインスペクターに表示させる。
    private GameObject[] progressInstances = new GameObject[3];

    // UIとして表示されるテキストメッセージ
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
        for(int i = 1; i <= 2; i++)
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
    /// <param name="progress">進捗度合い（ステップ1～4で指定する。なお、1眼モードでも完了画面は4で指定する。）</param>
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
            Image[] progressImages = instance.GetComponentsInChildren<Image>();
            Text[] texts = instance.GetComponentsInChildren<Text>();
            // 進捗テキストを更新。ただし1眼かつステップ4の時は3/3と表示されるようにする。
            if (false == is2Eyes && 4 == progress)
            {
                texts[0].text = "3/3";
            }
            else
            {
                texts[0].text = $"{progress}/{wholeSteps}";
            }
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
                // 3つめのステップを表す円を「隠し」、あたかも円が3つだけ見えるように調整する。
                tempColor.a = 0;
                progressImages[3].color = tempColor;
                progressImages[2].rectTransform.anchoredPosition = new Vector2(75f, 45f);
            }
        }
    }
}
